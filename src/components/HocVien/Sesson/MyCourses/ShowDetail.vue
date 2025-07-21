<script setup lang="ts">
import { computed, onMounted, ref, watch } from 'vue';
import NoteList from './DetailItem/NoteList.vue';
import CommentList from './DetailItem/CommentList.vue';
import ModelSchedule from './DetailItem/ModelSchedule.vue';
import DetailItem from '@/components/Home/Detail/DetailItem.vue';
import i18n from '@/i18n';
import { useYouTubePlayer } from '@/services/useYouTubePlayer';
import { useToast } from 'vue-toastification';

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

const isSectionCompleted = (section: typeof props.sections[number]) =>
    section.lessons.length > 0 && section.lessons.every(lesson => lesson.completed);

const total = computed(() => props.sections.length);
const completed = computed(() =>
    props.sections.filter(isSectionCompleted).length
);
const toggleSidebar = () => {
    showSidebar.value = !showSidebar.value
}

const changeVideo = (lesson: any) => {
    console.log('Changing to lesson:', lesson);
    props.sections.forEach(section => {
        section.lessons.forEach(l => {
            l.current = false;
        });
    });
    lesson.current = true;
    currentLesson.value = lesson;
    videoUrl.value = lesson.video_url;
    
    // Kiểm tra videoUrl có tồn tại không
    if (!lesson.video_url) {
        console.warn('Lesson video_url is empty:', lesson);
        alert('Bài học này chưa có video.');
        return;
    }
    
    console.log('Initializing player with videoUrl:', videoUrl.value);
    
    // Khởi tạo lại player với video mới
    if (ytInstance) {
        ytInstance.destroy();
        ytInstance = null;
    }
    
    // Khởi tạo player mới
    useYouTubePlayer(videoUrl.value, 'yt-player', {
        maxSeekTime: 120, // Cho phép tua tối đa 2 phút
        enableSeekWarning: true, // Bật cảnh báo tua video
        onEnded: () => OnNextVideo(),
        onShowToast: handleShowToast,
    }).then(player => {
        ytInstance = player;
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
                    onEnded: () => OnNextVideo(),
                    onShowToast: handleShowToast,
                }).then(player => {
                    ytInstance = player;
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
                    onEnded: () => OnNextVideo(),
                    onShowToast: handleShowToast,
                }).then(player => {
                    ytInstance = player;
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
    console.log('Sections data:', props.sections);
    if (props.sections.length > 0 && props.sections[0].lessons.length > 0) {
        currentLesson.value = props.sections[0].lessons[0];
        console.log('First lesson:', currentLesson.value);
        currentLesson.value.current = true;
        videoUrl.value = currentLesson.value.video_url;

        // Kiểm tra videoUrl có tồn tại không
        if (!currentLesson.value.video_url) {
            console.warn('First lesson video_url is empty:', currentLesson.value);
            alert('Bài học đầu tiên chưa có video.');
            return;
        }

        console.log('Initializing with videoUrl:', videoUrl.value);
        try {
            ytInstance = await useYouTubePlayer(videoUrl.value, 'yt-player', {
                maxSeekTime: 120, // Cho phép tua tối đa 2 phút
                enableSeekWarning: true, // Bật cảnh báo tua video
                onEnded: () => OnNextVideo(),
                onShowToast: handleShowToast,
            });
        } catch (error) {
            console.error('Lỗi khởi tạo YouTube player:', error);
            alert('Không thể tải video. Vui lòng kiểm tra lại URL video.');
        }
    }
});
</script>

<template>
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

            <NoteList :lessonid="currentLesson.id" :showNoteInput="showNoteInput" @setClose="toggleCloseNote" />
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
    <ModelSchedule :openScheduleModal="openScheduleModal" @setClose="toggleCloseModel" />
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
</style>
