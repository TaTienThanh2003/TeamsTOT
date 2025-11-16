<script setup lang="ts">
import { computed, onMounted, onUnmounted, ref, watch } from 'vue';
import NoteList from './DetailItem/NoteList.vue';
import CommentList from './DetailItem/CommentList.vue';
import ModelSchedule from './DetailItem/ModelSchedule.vue';
import DetailItem from '@/components/Home/Detail/DetailItem.vue';
import i18n from '@/i18n';
import { useYouTubePlayer } from '@/services/useYouTubePlayer';
import { useToast } from 'vue-toastification';
import { addUserLesson } from '@/services';
import { useLessonStatus } from '@/composables/useLessonStatus';

const props = defineProps<{
    sections: {
        title: string;
        lessons: {
            id: number;
            titleVI: string;
            titleEN: string;
            desVI: string;
            desEN: string;
            completed: boolean;
            current?: boolean;
            video_url: string;
        }[];
    }[];
    courseId?: number; // Thêm courseId prop
}>();

const emit = defineEmits(['back']);
const showNoteInput = ref(false)
const showCommentInput = ref(false)
const openScheduleModal = ref(false)
const currentLesson = ref<any>({});
const showSidebar = ref(true)
const locale = i18n.global.locale.toUpperCase();
const videoUrl = ref('');
let ytInstance: YT.Player | null = null;
const toast = useToast();

// Sử dụng composable để quản lý trạng thái lesson
const { isLoading, completedLessonIds, refreshLessonStatus, updateSectionsStatus, findFirstIncompleteLesson } = useLessonStatus();

// Thêm biến để theo dõi số lần tua video
const seekCount = ref(0);
const maxSeeks = 2; // Số lần tua tối đa cho phép

// Thêm biến để quản lý popup
const showSeekWarningModal = ref(false);

// Thêm biến để quản lý popup hoàn thành bài học
const showCompletionModal = ref(false);

// Thêm biến để theo dõi thời gian video
const currentVideoTime = ref('00:00:00');
const videoTimeInterval = ref<number | null>(null);

const isSectionCompleted = (section: typeof props.sections[number]) =>
    section.lessons.length > 0 && section.lessons.every(lesson => lesson.completed);

// Hàm format thời gian từ giây sang HH:MM:SS
const formatTime = (seconds: number): string => {
    const hours = Math.floor(seconds / 3600);
    const minutes = Math.floor((seconds % 3600) / 60);
    const secs = seconds % 60;
    return `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${secs.toString().padStart(2, '0')}`;
};

// Hàm cập nhật thời gian video
const updateVideoTime = () => {
    const player = (window as any).ytPlayer;
    if (player && typeof player.getCurrentTime === 'function') {
        try {
            const currentTime = player.getCurrentTime();
            const formattedTime = formatTime(Math.floor(currentTime));
            currentVideoTime.value = formattedTime;
            
            // Expose thời gian ra window để component khác có thể truy cập
            (window as any).currentVideoTime = formattedTime;
        } catch (err) {
            console.error('Lỗi cập nhật thời gian video:', err);
        }
    }
};

// Hàm bắt đầu theo dõi thời gian video
const startVideoTimeTracking = () => {
    if (videoTimeInterval.value) {
        clearInterval(videoTimeInterval.value);
    }
    // Cập nhật thời gian mỗi giây để đảm bảo chính xác
    videoTimeInterval.value = setInterval(updateVideoTime, 1000);
};

// Hàm dừng theo dõi thời gian video
const stopVideoTimeTracking = () => {
    if (videoTimeInterval.value) {
        clearInterval(videoTimeInterval.value);
        videoTimeInterval.value = null;
    }
};

const total = computed(() => props.sections.length);
const completed = computed(() =>
    props.sections.filter(isSectionCompleted).length
);
const toggleSidebar = () => {
    showSidebar.value = !showSidebar.value
}

// Hàm thêm lesson vào userLesson
const addLessonToUser = async (lessonId: number) => {
    try {
        const user = JSON.parse(localStorage.getItem('user') || '{}');
        const userId = user.id;
        
        await addUserLesson(userId, lessonId);
        
        // Refresh trạng thái lesson sau khi thêm thành công
        await refreshLessonStatus();
        updateSectionsStatus(props.sections);
        
        return true;
    } catch (error) {
        console.error('Lỗi thêm lesson vào userLesson:', error);
        return false;
    }
};

// Hàm xử lý khi tua video quá nhiều lần
const handleExcessiveSeeking = () => {
    seekCount.value++;
    if (seekCount.value > maxSeeks) {
        // Dừng video
        if (ytInstance) {
            ytInstance.pauseVideo();
        }
        // Hiển thị popup
        showSeekWarningModal.value = true;
    }
};

// Hàm xử lý khi user bấm OK trong popup
const handleSeekWarningConfirm = () => {
    showSeekWarningModal.value = false;
    // Reset seek count
    seekCount.value = 0;
    // Load lại video từ đầu
    if (ytInstance) {
        ytInstance.seekTo(0, true);
        ytInstance.playVideo();
    }
    toast.success('Video đã được load lại từ đầu.');
};

// Hàm xử lý khi user chọn tiếp tục bài học tiếp theo
const handleContinueToNextLesson = () => {
    showCompletionModal.value = false;
    OnNextVideo();
};

// Hàm xử lý khi user chọn ở lại bài học hiện tại
const handleStayInCurrentLesson = () => {
    showCompletionModal.value = false;
    // Không làm gì, user ở lại bài học hiện tại
};

const changeVideo = (lesson: any) => {
    props.sections.forEach(section => {
        section.lessons.forEach(l => {
            l.current = false;
        });
    });
    lesson.current = true;
    currentLesson.value = lesson;
    videoUrl.value = lesson.video_url;
    
    // Reset seek count khi chuyển bài học mới
    seekCount.value = 0;
    
    // Kiểm tra videoUrl có tồn tại không
    if (!lesson.video_url) {
        console.warn('Lesson video_url is empty:', lesson);
        alert('Bài học này chưa có video.');
        return;
    }
    
    // Khởi tạo lại player với video mới
    if (ytInstance) {
        ytInstance.destroy();
        ytInstance = null;
    }
    
    // Khởi tạo player mới
    useYouTubePlayer(videoUrl.value, 'yt-player', {
        maxSeekTime: 120, // Cho phép tua tối đa 2 phút
        enableSeekWarning: true, // Bật cảnh báo tua video
        onEnded: handleVideoEnded,
        onShowToast: handleShowToast,
        onSeek: handleExcessiveSeeking, // Thêm callback xử lý tua video
    }).then(player => {
        ytInstance = player;
        // Bắt đầu lại theo dõi thời gian video
        startVideoTimeTracking();
    }).catch(error => {
        console.error('Lỗi khởi tạo YouTube player:', error);
        alert('Không thể tải video. Vui lòng kiểm tra lại URL video.');
    });
}

const OnPrevVideo = () => {
    let found = false;
    for (let i = 0; i < props.sections.length; i++) {
        const section = props.sections[i];
        for (let j = 0; j < section.lessons.length; j++) {
            const l = section.lessons[j];
            if (l === currentLesson.value) {
                l.current = false;
                if (i === 0 && j === 0) return;
                if (j > 0) {
                    const prev = section.lessons[j - 1];
                    prev.current = true;
                    currentLesson.value = prev;
                    videoUrl.value = prev.video_url;
                } else {
                    const prevSection = props.sections[i - 1];
                    const prev = prevSection.lessons[prevSection.lessons.length - 1];
                    prev.current = true;
                    currentLesson.value = prev;
                    videoUrl.value = prev.video_url;
                }
                
                // Reset seek count khi chuyển bài học
                seekCount.value = 0;
                
                // Kiểm tra videoUrl có tồn tại không
                if (!videoUrl.value) {
                    console.warn('Previous lesson video_url is empty');
                    alert('Bài học trước chưa có video.');
                    return;
                }
                
                // Khởi tạo lại player với video mới
                if (ytInstance) {
                    ytInstance.destroy();
                    ytInstance = null;
                }
                
                useYouTubePlayer(videoUrl.value, 'yt-player', {
                    maxSeekTime: 120, // Cho phép tua tối đa 2 phút
                    enableSeekWarning: true, // Bật cảnh báo tua video
                    onEnded: handleVideoEnded,
                    onShowToast: handleShowToast,
                    onSeek: handleExcessiveSeeking, // Thêm callback xử lý tua video
                }).then(player => {
                    ytInstance = player;
                    // Bắt đầu lại theo dõi thời gian video
                    startVideoTimeTracking();
                }).catch(error => {
                    console.error('Lỗi khởi tạo YouTube player:', error);
                    alert('Không thể tải video. Vui lòng kiểm tra lại URL video.');
                });
                
                found = true;
                break;
            }
        }
        if (found) break;
    }
};

const OnNextVideo = () => {
    let found = false;
    for (let i = 0; i < props.sections.length; i++) {
        const section = props.sections[i];
        for (let j = 0; j < section.lessons.length; j++) {
            const l = section.lessons[j];
            if (l === currentLesson.value) {
                l.current = false;
                if (j < section.lessons.length - 1) {
                    const next = section.lessons[j + 1];
                    next.current = true;
                    currentLesson.value = next;
                    videoUrl.value = next.video_url;
                } else if (i < props.sections.length - 1) {
                    const nextSection = props.sections[i + 1];
                    if (nextSection.lessons.length > 0) {
                        const next = nextSection.lessons[0];
                        next.current = true;
                        currentLesson.value = next;
                        videoUrl.value = next.video_url;
                    }
                }
                
                // Reset seek count khi chuyển bài học
                seekCount.value = 0;
                
                // Kiểm tra videoUrl có tồn tại không
                if (!videoUrl.value) {
                    console.warn('Next lesson video_url is empty');
                    alert('Bài học tiếp theo chưa có video.');
                    return;
                }
                
                // Khởi tạo lại player với video mới
                if (ytInstance) {
                    ytInstance.destroy();
                    ytInstance = null;
                }
                
                useYouTubePlayer(videoUrl.value, 'yt-player', {
                    maxSeekTime: 120, // Cho phép tua tối đa 2 phút
                    enableSeekWarning: true, // Bật cảnh báo tua video
                    onEnded: handleVideoEnded,
                    onShowToast: handleShowToast,
                    onSeek: handleExcessiveSeeking, // Thêm callback xử lý tua video
                }).then(player => {
                    ytInstance = player;
                    // Bắt đầu lại theo dõi thời gian video
                    startVideoTimeTracking();
                }).catch(error => {
                    console.error('Lỗi khởi tạo YouTube player:', error);
                    alert('Không thể tải video. Vui lòng kiểm tra lại URL video.');
                });
                
                found = true;
                break;
            }
        }
        if (found) break;
    }
};

// Hàm xử lý khi video kết thúc
const handleVideoEnded = async () => {
    // Dừng video
    if (ytInstance) {
        ytInstance.pauseVideo();
    }
    
    // Call API thêm lesson vào userLesson
    if (currentLesson.value && currentLesson.value.id) {
        const success = await addLessonToUser(currentLesson.value.id);
        if (success) {
            // Hiển thị popup hoàn thành bài học
            showCompletionModal.value = true;
        } else {
            toast.error('Có lỗi xảy ra khi cập nhật trạng thái bài học.');
        }
    }
};

// Hàm xử lý khi schedule được tạo thành công
const handleScheduleCreated = (createdSchedules: any[]) => {
    // Có thể emit event để parent component biết và refresh calendar
    // Hoặc sử dụng global event bus để thông báo cho calendar component
    window.dispatchEvent(new CustomEvent('schedules-updated', { 
        detail: { schedules: createdSchedules } 
    }));
};

const toggleCloseNote = () => {
    showNoteInput.value = false;
}
const toggleCloseComment = () => {
    showCommentInput.value = false;
}
const toggleCloseModel = () => {
    openScheduleModal.value = false;
}

const handleShowToast = (message: string, type: 'warning' | 'error' | 'success' = 'warning') => {
    if (type === 'warning') toast.warning(message);
    else if (type === 'error') toast.error(message);
    else if (type === 'success') toast.success(message);
    else toast.info(message);
};

onMounted(async () => {
    // Đợi composable load xong
    await refreshLessonStatus();
    
    // Cập nhật trạng thái cho sections
    updateSectionsStatus(props.sections);

    if (props.sections.length > 0 && props.sections[0].lessons.length > 0) {
        // Tìm lesson đầu tiên chưa hoàn thành
        const firstIncompleteLesson = findFirstIncompleteLesson(props.sections);
        
        currentLesson.value = firstIncompleteLesson;
        currentLesson.value.current = true;
        videoUrl.value = currentLesson.value.video_url;

        // Kiểm tra videoUrl có tồn tại không
        if (!currentLesson.value.video_url) {
            console.warn('Selected lesson video_url is empty:', currentLesson.value);
            alert('Bài học này chưa có video.');
            return;
        }

        try {
            ytInstance = await useYouTubePlayer(videoUrl.value, 'yt-player', {
                maxSeekTime: 120, // Cho phép tua tối đa 2 phút
                enableSeekWarning: true, // Bật cảnh báo tua video
                onEnded: handleVideoEnded, // Thay đổi callback để xử lý khi video kết thúc
                onShowToast: handleShowToast,
                onSeek: handleExcessiveSeeking, // Thêm callback xử lý tua video
            });
            
            // Bắt đầu theo dõi thời gian video sau khi player được khởi tạo
            startVideoTimeTracking();
        } catch (error) {
            console.error('Lỗi khởi tạo YouTube player:', error);
            alert('Không thể tải video. Vui lòng kiểm tra lại URL video.');
        }
    }
});

onUnmounted(() => {
    // Dừng theo dõi thời gian video
    stopVideoTimeTracking();
    // Xóa completedLessonIds khỏi localStorage khi component bị hủy
    localStorage.removeItem('completedLessonIds');
});
</script>

<template>
    <div v-if="!isLoading">
        <div class="course-detail row">
            <div :class="['col-md-8', showSidebar ? 'transition-show' : 'transition-hide']">
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <div class="course-info">
                        <div class="courset-s">
                            <div class="d-flex align-items-center gap-2">
                                <button class="btn p-0 border-0 bg-transparent" @click="emit('back')"
                                    style="font-size: 18px;">
                                    <i class="fas fa-chevron-left"></i>
                                </button>
                                <h2 class="course-title m-0 fs-4">{{ locale === 'VI' ? currentLesson.titleVI :
                                    currentLesson.titleEN }}</h2>
                            </div>
                        </div>
                    </div>
                    <div class="d-flex gap-2 align-items-center">
                        <button type="button"
                            :class="['btn', 'btn-primary', 'rounded-circle', 'btn-customer', { 'btn-active': showNoteInput }]"
                            style="width: 40px; height: 40px;" @click="showNoteInput = !showNoteInput" title="Ghi chú">
                            <i class="fas fa-pen text-primary"></i>
                        </button>
                        <button type="button"
                            :class="['btn', 'btn-primary', 'rounded-circle', 'btn-customer', { 'btn-active': showCommentInput }]"
                            style="width: 40px; height: 40px;" @click="showCommentInput = !showCommentInput"
                            title="Bình luận">
                            <i class="fas fa-comment text-primary"></i>
                        </button>
                        <button type="button"
                            class="btn btn-outline-primary rounded-circle"
                            style="width: 40px; height: 40px;" @click="refreshLessonStatus" title="Refresh trạng thái">
                            <i class="fas fa-sync-alt"></i>
                        </button>
                    </div>
                </div>

                <div class="course-header mb-3">
                    <div class="video-wrapper">
                         <div id="yt-player" class="video-player" style="width: 100%; height: 100%;"></div>
                         <div v-if="!videoUrl" class="video-placeholder">
                             <i class="fas fa-play-circle fa-3x text-muted"></i>
                             <p class="text-muted mt-2">Chưa có video</p>
                         </div>
                    </div>
                </div>

                <div class="d-flex justify-content-center gap-2 mb-2">
                    <button class="btn btn-outline-primary p-2" @click="OnPrevVideo">Bài học trước</button>
                    <button class="btn btn-outline-primary p-2" @click="OnNextVideo">Bài học tiếp</button>
                </div>

                <NoteList 
                    :lessonid="currentLesson.id" 
                    :showNoteInput="showNoteInput" 
                    :currentVideoTime="currentVideoTime"
                    @setClose="toggleCloseNote" 
                />
                <CommentList :lessonid="currentLesson.id" :showCommentInput="showCommentInput"
                    @setClose="toggleCloseComment" />

                <div class="lesson-details">
                    <p class="lesson-content mb-5 fs-5 fw-bold">{{ locale === 'VI' ? currentLesson.desVI :
                        currentLesson.desEN }}</p>
                    <div class="center-info">
                        <h3 class="fs-6 mb-3">Tham gia cộng đồng học tập...</h3>
                        <p>📘 Nhóm học tập: <a href="https://www.facebook.com/groups/ten-nhom"
                                target="_blank">https://www.facebook.com/groups/ten-nhom</a></p>
                        <p>📞 Liên hệ: 0909 999 999</p>
                        <p>📧 Email: support@trungtam.vn</p>
                    </div>
                </div>
            </div>

            <div :class="['col-md-4', showSidebar ? 'transition-show' : 'transition-hide']">
                <div :class="['lesson-list-scrollable pt-3', showSidebar ? 'transition-show' : 'transition-hide']">
                    <div class="d-flex justify-between">
                        <button @click="toggleSidebar" :class="[showSidebar ? 'icon-show' : 'icon-hide']">
                            <i class="fas fa-bars"></i>
                        </button>
                    </div>
                    <div v-show="showSidebar">
                        <div class="d-flex justify-content-between align-items-center mb-2">
                            <h1 class="fs-4 py-3">Khóa học TOIEC</h1>
                            <div class="icon-label" @click="toggleSidebar">
                                <i class="fas fa-bars"></i>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between align-items-center mb-2">
                            <small class="text-muted">{{ completed }}/{{ total }} Hoàn thành</small>
                            <div class="d-flex align-items-center gap-1" style="cursor: pointer;"
                                @click="openScheduleModal = true">
                                <i class="fas fa-trophy text-warning"></i>
                                <small class="text-muted">Đặt lịch học</small>
                            </div>
                        </div>

                        <div class="d-flex gap-1 mb-3">
                            <div v-for="(section, index) in props.sections" :key="index"
                                :class="['flex-fill', isSectionCompleted(section) ? 'bg-primary' : 'bg-secondary-subtle']"
                                style="height: 4px; border-radius: 2px;"></div>
                        </div>

                        <DetailItem v-for="(section, index) in props.sections" :key="index" :title="section.title"
                            :lessons="section.lessons" :isLocked="false" @play="changeVideo" />
                    </div>
                </div>
            </div>
        </div>
        <ModelSchedule :openScheduleModal="openScheduleModal" @setClose="toggleCloseModel" :courseId="props.courseId" @scheduleCreated="handleScheduleCreated" />
        
        <!-- Popup cảnh báo tua video -->
        <div v-if="showSeekWarningModal" class="modal-overlay">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">
                        <i class="fas fa-exclamation-triangle text-warning me-2"></i>
                        Cảnh báo tua video
                    </h5>
                </div>
                <div class="modal-body">
                    <p>Bạn đã tua video quá nhiều lần. Để đảm bảo chất lượng học tập, vui lòng xem lại video từ đầu.</p>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" @click="handleSeekWarningConfirm">
                        <i class="fas fa-redo me-2"></i>
                        Xem lại từ đầu
                    </button>
                </div>
            </div>
        </div>

        <!-- Popup hoàn thành bài học -->
        <div v-if="showCompletionModal" class="modal-overlay">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">
                        <i class="fas fa-check-circle text-success me-2"></i>
                        Hoàn thành bài học
                    </h5>
                </div>
                <div class="modal-body">
                    <p>Bạn đã hoàn thành bài học này. Bạn muốn tiếp tục bài học tiếp theo hay ở lại bài học hiện tại?</p>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" @click="handleStayInCurrentLesson">
                        Ở lại bài học hiện tại
                    </button>
                    <button class="btn btn-primary" @click="handleContinueToNextLesson">
                        Tiếp tục bài học tiếp theo
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div v-else>
        <div class="d-flex justify-content-center align-items-center" style="height: 100vh;">
            <div class="text-center">
                <div class="spinner-border text-primary" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
                <p class="mt-3">Đang tải dữ liệu...</p>
            </div>
        </div>
    </div>
</template>
<style scoped>
.video-wrapper {
  position: relative;
  width: 100%;
  max-width: 100%;
  aspect-ratio: 16 / 9;
  border-radius: 8px;
  overflow: hidden;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  background-color: black;
}

.video-player {
  width: 100%;
  height: 100%;
  position: absolute;
  top: 0;
  left: 0;
}

.video-placeholder {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background-color: #f8f9fa;
  color: #6c757d;
}

.lesson-card.completed {
  background: #4caf50 !important;
  color: #fff !important;
  pointer-events: none;
  opacity: 1;
}
.icon-check {
  margin-right: 8px;
  color: #fff;
}

.modal-overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(255,255,255,0.25);
    backdrop-filter: blur(2px);
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 9999;
}

.modal-content {
    background: white;
    border-radius: 8px;
    padding: 0;
    max-width: 500px;
    width: 90%;
    box-shadow: 0 8px 32px rgba(0,0,0,0.25);
}

.modal-header {
    padding: 1rem 1.5rem;
    border-bottom: 1px solid #dee2e6;
    background-color: #f8f9fa;
    border-radius: 8px 8px 0 0;
}

.modal-title {
    margin: 0;
    font-size: 1.1rem;
    font-weight: 600;
}

.modal-body {
    padding: 1.5rem;
}

.modal-footer {
    padding: 1rem 1.5rem;
    border-top: 1px solid #dee2e6;
    display: flex;
    justify-content: flex-end;
    gap: 0.5rem;
}

/* Chỉ áp dụng style cho button trong modal */
.modal-footer .btn {
    padding: 0.5rem 1rem;
    border-radius: 6px;
    font-weight: 500;
    transition: all 0.2s;
}

.modal-footer .btn-primary {
    background-color: #007bff;
    border-color: #007bff;
}

.modal-footer .btn-primary:hover {
    background-color: #0056b3;
    border-color: #0056b3;
}

.modal-footer .btn-secondary {
    background-color: #6c757d;
    border-color: #6c757d;
}

.modal-footer .btn-secondary:hover {
    background-color: #545b62;
    border-color: #545b62;
}
.icon-show {
    display: none;
}

.icon-hide {
    display: block;
}

.courset-s {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.lesson-list-scrollable.transition-show {
    right: 0;
}

.lesson-list-scrollable.transition-hide {
    right: -26%;
    background-color: #fff;
    height: calc(100% - 65px);
}

.transition-hide.col-md-8 {
    width: 100% !important;
    transition: width 0.3s ease;
}

.transition-hide.col-md-4 {
    width: 0% !important;
    transition: width 0.3s ease;
}

.btn-customer i {
    transition: color 0.2s ease;
}


.btn-customer:hover i {
    color: #fff !important;
}

.btn-active {
    background-color: #2237fa;
}

.btn-active i {
    color: #fff !important;
}

.icon-label {
    color: #6c757d;
    display: flex;
    align-items: center;
    gap: 5px;
    cursor: pointer;
}

.icon-label i {
    font-size: 16px;
}

.bg-custom-light {
    background-color: #e8eff8;
}


.lesson-list-scrollable,
.note-panel {
    background-color: #fff;
    height: calc(100% - 65px);
    overflow-y: auto;
    padding: 10px 20px;
    text-align: left;
    position: fixed;
    top: 65px;
    right: 0;
    width: 30%;
    z-index: 1;
}

.note-panel {
    z-index: 200;
    right: -100%;
}

.note-panel.active {
    right: 0;
}

.course-header {
    display: flex;
    justify-content: center;
    background-color: #fff;
    border-radius: 16px;
    width: 100%;
}

</style>
