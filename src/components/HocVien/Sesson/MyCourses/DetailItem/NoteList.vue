<script setup lang="ts">
import { getNotebylesson, addNote, deleteNote } from '@/services';
import { onMounted, ref, watch, computed, onUnmounted, nextTick } from 'vue';
import { useToast } from '@/composables/useToast';

const props = defineProps<{
    showNoteInput: boolean;
    lessonid: number;
    currentVideoTime?: string; // Thêm prop để nhận thời gian từ parent
}>();

const openSchedule = ref(false);
const emit = defineEmits(['setClose']);
const notes = ref<any>([]);
const noteText = ref('');
const currentVideoTime = ref('00:00:00');
const user = JSON.parse(localStorage.getItem("user") || "{}");
const userId = user.id;
const { success, error } = useToast();

// Thêm interval để cập nhật thời gian liên tục
let timeUpdateInterval: number | null = null;

const onCloseDetail = () => {
    emit('setClose', false);
}

// Hàm format thời gian từ giây sang HH:MM:SS
const formatTime = (seconds: number): string => {
    const hours = Math.floor(seconds / 3600);
    const minutes = Math.floor((seconds % 3600) / 60);
    const secs = seconds % 60;
    return `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${secs.toString().padStart(2, '0')}`;
};

// Computed để hiển thị thời gian video real-time
const displayVideoTime = computed(() => {
    // Nếu có currentVideoTime được set bởi forceRefreshTime, ưu tiên sử dụng
    if (currentVideoTime.value && currentVideoTime.value !== '00:00:00') {
        return currentVideoTime.value;
    }
    
    // Luôn lấy thời gian trực tiếp từ player để đảm bảo chính xác
    const player = (window as any).ytPlayer;
    if (player && typeof player.getCurrentTime === 'function') {
        try {
            const currentTime = player.getCurrentTime();
            if (currentTime !== undefined && currentTime >= 0) {
                const formattedTime = formatTime(Math.floor(currentTime));
                return formattedTime;
            }
        } catch (err) {
            console.error('Lỗi lấy thời gian từ player:', err);
        }
    }
    
    // Fallback: sử dụng window.currentVideoTime nếu player không có
    const windowTime = (window as any).currentVideoTime;
    if (windowTime && windowTime !== '00:00:00') {
        return windowTime;
    }
    
    // Fallback cuối: sử dụng prop từ parent
    if (props.currentVideoTime && props.currentVideoTime !== '00:00:00') {
        return props.currentVideoTime;
    }
    
    return '00:00:00';
});

// Hàm force refresh thời gian video
const forceRefreshTime = () => {
    const player = (window as any).ytPlayer;
    if (player && typeof player.getCurrentTime === 'function') {
        try {
            const currentTime = player.getCurrentTime();
            if (currentTime !== undefined && currentTime >= 0) {
                const formattedTime = formatTime(Math.floor(currentTime));
                currentVideoTime.value = formattedTime;
                
                // Reset currentVideoTime sau 1 giây để computed có thể lấy thời gian real-time
                setTimeout(() => {
                    currentVideoTime.value = '';
                }, 1000);
                
                return formattedTime;
            }
        } catch (err) {
            console.error('Lỗi force refresh time:', err);
        }
    }
    return '00:00:00';
};

// Hàm mở form ghi chú và lấy thời gian video ngay lập tức
const openNoteForm = () => {
    openSchedule.value = true;
    // Force refresh thời gian video ngay lập tức
    forceRefreshTime();
};

// Hàm lấy thời gian hiện tại của video (không dùng nữa, thay bằng computed)
const getCurrentVideoTime = (): string => {
    return displayVideoTime.value;
};

// Hàm lấy ghi chú theo lesson và user
const getNotes = async () => {
    try {
        const res = await getNotebylesson(props.lessonid, userId);
        const resdata = res.data;
        notes.value = resdata.map((note: any) => ({
            id: note.id,
            text: note.text,
            time: note.video_time,
            created_at: note.created_at
        }));
    } catch (err: any) {
        console.error('Lỗi lấy ghi chú:', err);
        error('Không thể tải ghi chú');
    }
};

// Hàm thêm ghi chú mới với thời gian thực của video
const addNewNote = async () => {
    if (!noteText.value.trim()) {
        error('Vui lòng nhập nội dung ghi chú');
        return;
    }

    try {
        // Lấy thời gian thực của video đang chạy từ computed
        const videoTime = displayVideoTime.value;
        
        await addNote(props.lessonid, userId, noteText.value.trim(), videoTime);
        
        success('Thêm ghi chú thành công!');
        noteText.value = '';
        openSchedule.value = false;
        
        // Refresh lại danh sách ghi chú
        await getNotes();
    } catch (err: any) {
        console.error('Lỗi thêm ghi chú:', err);
        error('Không thể thêm ghi chú');
    }
};

// Hàm xóa ghi chú
const deleteNoteItem = async (noteId: number) => {
    // Kiểm tra noteId hợp lệ
    if (!noteId || noteId <= 0) {
        error('ID ghi chú không hợp lệ');
        return;
    }
    
    try {
        await deleteNote(noteId);
        success('Xóa ghi chú thành công!');
        await getNotes();
    } catch (err: any) {
        console.error('Lỗi xóa ghi chú:', err);
        
        if (err.response?.status === 400) {
            error('Dữ liệu không hợp lệ hoặc ID ghi chú không tồn tại');
        } else if (err.response?.status === 401) {
            error('Không có quyền xóa ghi chú này');
        } else if (err.response?.status === 404) {
            error('Không tìm thấy ghi chú để xóa');
        } else {
            error('Không thể xóa ghi chú: ' + (err.response?.data?.message || err.message));
        }
    }
};

// Hàm format thời gian hiển thị
const formatDisplayTime = (time: string): string => {
    if (!time) return '00:00:00';
    return time;
};

// Hàm chuyển đến thời điểm ghi chú trong video
const seekToTime = (time: string) => {
    const player = (window as any).ytPlayer;
    if (player && typeof player.seekTo === 'function') {
        const timeParts = time.split(':');
        const seconds = parseInt(timeParts[0]) * 3600 + parseInt(timeParts[1]) * 60 + parseInt(timeParts[2]);
        player.seekTo(seconds, true);
    }
};

// Hàm lấy thời gian thực để lưu ghi chú
const getRealTimeForNote = (): string => {
    return getCurrentVideoTime();
};

// Hàm bắt đầu cập nhật thời gian liên tục
const startTimeUpdate = () => {
    
    // Thêm event listener để lắng nghe khi video thay đổi trạng thái
    const player = (window as any).ytPlayer;
    if (player && typeof player.addEventListener === 'function') {
        player.addEventListener('onStateChange', (event: any) => {
            // console.log('Video state changed:', event.data); // Removed debug
        });
    }
};

// Hàm dừng cập nhật thời gian
const stopTimeUpdate = () => {
    // console.log('Dừng cập nhật thời gian video'); // Removed debug
};

onMounted(() => {
    if (props.lessonid) {
        getNotes();
        startTimeUpdate(); // Bắt đầu cập nhật thời gian khi component được mount
    }
});

watch(() => props.lessonid, (newId) => {
    if (newId) {
        getNotes();
        startTimeUpdate(); // Bắt đầu lại cập nhật thời gian khi lesson thay đổi
    }
});

// Watch currentVideoTime prop để cập nhật
watch(() => props.currentVideoTime, (newTime) => {
    if (newTime) {
        currentVideoTime.value = newTime;
    }
});

onUnmounted(() => {
    stopTimeUpdate(); // Dừng cập nhật khi component unmount
});
</script>

<template>
    <div v-if="showNoteInput" :class="showNoteInput ? 'note-panel active' : 'note-panel'">
        <div class="note-content">
            <div class="d-flex justify-between align-items-center mb-3 p-0">
                <h3 class="fs-5 bold">Ghi chú của bạn</h3>
                <button class="fs-5" @click="onCloseDetail()">
                    <i class="fas fa-times"></i>
                </button>
            </div>
            
            <div v-if="!openSchedule" class="d-flex justify-content-between align-items-center mb-3">
                <button class="btn btn-sm btn-outline-primary" @click="openNoteForm">
                    <i class="fas fa-plus me-1"></i> Ghi chú
                </button>
                <div class="text-muted small d-flex align-items-center gap-2">
                    <i class="fas fa-clock me-1"></i>
                    Thời gian hiện tại: <span class="fw-bold text-primary">{{ displayVideoTime }}</span>
                    <button 
                        class="btn btn-sm btn-outline-secondary ms-2" 
                        @click="forceRefreshTime"
                        title="Cập nhật thời gian"
                        style="padding: 0.1rem 0.3rem; font-size: 0.7rem;"
                    >
                        <i class="fas fa-sync-alt"></i>
                    </button>
                </div>
            </div>

            <div v-if="openSchedule" class="mb-3">
                <div class="mb-2">
                    <label class="form-label small text-muted">
                        <i class="fas fa-clock me-1"></i>
                        Thời gian video hiện tại:
                    </label>
                    <div class="input-group">
                        <span class="input-group-text">
                            <i class="fas fa-play"></i>
                        </span>
                        <input 
                            type="text" 
                            class="form-control" 
                            :value="displayVideoTime" 
                            readonly
                            placeholder="00:00:00"
                            style="font-family: monospace; font-weight: bold; color: #007bff;"
                        />
                        <button 
                            class="btn btn-outline-secondary" 
                            @click="forceRefreshTime"
                            title="Cập nhật thời gian hiện tại"
                        >
                            <i class="fas fa-sync-alt"></i>
                        </button>
                    </div>
                </div>
                
                <div class="mb-3">
                    <label class="form-label small text-muted">
                        <i class="fas fa-edit me-1"></i>
                        Nội dung ghi chú:
                    </label>
                    <textarea 
                        v-model="noteText"
                        class="form-control" 
                        placeholder="Nhập nội dung ghi chú..." 
                        rows="3"
                        style="width: 100%;"
                    ></textarea>
                </div>

                <div class="d-flex justify-content-end gap-2">
                    <button class="btn btn-secondary btn-sm" @click="openSchedule = false; noteText = ''">
                        Hủy
                    </button>
                    <button class="btn btn-primary btn-sm" @click="addNewNote">
                        <i class="fas fa-paper-plane me-1"></i> Gửi
                    </button>
                </div>
            </div>
        </div>
        
        <div class="note-list-container">
            <div v-if="notes.length === 0" class="text-center py-4 text-muted">
                <i class="fas fa-sticky-note fa-2x mb-2"></i>
                <p>Chưa có ghi chú nào</p>
            </div>
            
            <ul v-else class="note-list px-2">
                <li v-for="(note, index) in notes" :key="note.id || index" class="note-item">
                    <div class="note-content-wrapper">
                        <div class="note-text">📌 {{ note.text }}</div>
                        <div class="note-actions">
                            <button 
                                class="btn btn-sm btn-outline-primary me-1" 
                                @click="seekToTime(note.time)"
                                title="Chuyển đến thời điểm này"
                            >
                                <i class="fas fa-play"></i>
                                {{ formatDisplayTime(note.time) }}
                            </button>
                            <button 
                                class="btn btn-sm btn-outline-danger" 
                                @click="deleteNoteItem(note.id)"
                                title="Xóa ghi chú"
                            >
                                <i class="fas fa-trash"></i>
                            </button>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</template>

<style scoped>
.note-content {
    padding: 16px;
    font-family: 'Segoe UI', sans-serif;
}

.note-list-container {
    max-height: 400px;
    overflow-y: auto;
}

.note-list {
    list-style: none;
    padding: 0;
    margin: 0;
    display: flex;
    flex-direction: column;
    gap: 12px;
}

.note-item {
    background: #fdfdfd;
    border-left: 4px solid #dee2e6;
    padding: 12px 16px;
    border-radius: 8px;
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.05);
}

.note-content-wrapper {
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
    margin-bottom: 8px;
}

.note-text {
    font-size: 14px;
    color: #333;
    flex: 1;
    margin-right: 10px;
}

.note-actions {
    display: flex;
    gap: 5px;
    flex-shrink: 0;
}

.note-time {
    font-size: 12px;
    color: #888;
    text-align: right;
}

.input-group-text {
    background-color: #f8f9fa;
    border-color: #dee2e6;
}

.form-control:read-only {
    background-color: #f8f9fa;
}

.btn-sm {
    padding: 0.25rem 0.5rem;
    font-size: 0.875rem;
}

.note-item:hover {
    border-left-color: #6C63FF;
    background-color: #f8f9ff;
}
</style>