<script setup lang="ts">
import { ref } from 'vue';
import NoteList from './DetailItem/NoteList.vue';
import CommentList from './DetailItem/CommentList.vue';

const props = defineProps<{
    lessons: {
        id: number;
        title: string;
        description: string;
        completed: boolean;
        current?: boolean;
        videoUrl: string;
    }[];
}>();

const emit = defineEmits(['back']);
const showNoteInput = ref(false)
const showCommentInput = ref(false)
const currentLesson = ref<any>({});

const changeVideo = (lesson: typeof props.lessons[0]) => {
    currentLesson.value = lesson;
}
const toggleCloseNote = () => {
    showNoteInput.value = false;
}
const toggleCloseComment = () => {
    showCommentInput.value = false;
}
</script>


<template>
    <div class="course-detail row">
        <div class="col-md-8">
            <div class="course-header mb-4">
                <iframe class="video-player" :src="currentLesson.videoUrl" title="Giới thiệu khóa học" frameborder="0"
                    allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                    allowfullscreen></iframe>
            </div>
            <div class="d-flex justify-content-between align-items-center mb-4">
                <div class="course-info">
                    <div class="courset-s">
                        <div class="d-flex align-items-center gap-2">
                            <button class="btn p-0 border-0 bg-transparent" @click="emit('back')"
                                style="font-size: 20px;">
                                &lt;
                            </button>
                            <h2 class="course-title m-0">{{ currentLesson.title }}</h2>
                        </div>
                    </div>
                </div>
                <div class="progress-container">
                    <div class="icon-label">
                        <i class="fas fa-check-circle"></i> 37/37 bài học
                    </div>
                    <div class="icon-label" @click="showNoteInput = !showNoteInput">
                        <i class="fas fa-pen"></i> Ghi chú
                    </div>
                    <div class="icon-label" @click="showCommentInput = !showCommentInput">
                        <i class="fas fa-comment"></i> Bình luận
                    </div>
                </div>

                <NoteList :showNoteInput="showNoteInput" @setClose="toggleCloseNote" />
                <CommentList :showCommentInput="showCommentInput" @setClose="toggleCloseComment" />
            </div>
            <div class="lesson-details">
                <p class="lesson-content">{{ currentLesson.content }}</p>
            </div>
            <button class="btn btn-sm btn-outline-primary mt-3" @click="showNoteInput = !showNoteInput">+ Thêm ghi
                chú</button>
            <div class="mt-3" v-if="showNoteInput">
                <div class="border rounded-3 p-3 bg-white">
                    <div class="mb-3">
                        <input class="form-control border-0 shadow-none border-bottom" placeholder="Tiêu đề"></input>
                        <input class="form-control border-0 shadow-none" placeholder="Nội dung ghi chú..."></input>
                    </div>

                    <div class="d-flex justify-content-end gap-2">
                        <button class="btn btn-primary btn-lg rounded-pill">
                            <i class="fas fa-sticky-note"></i>
                        </button>
                        <button class="btn btn-outline-primary btn-lg rounded-pill" @click="showNoteInput = false">
                            <i class="fas fa-times"></i>
                        </button>
                    </div>
                </div>
            </div>

        </div>

        <div class="col-md-4">
            <div class="lesson-list-scrollable">
                <h1 class="fs-4 p-3">Khóa học TOIEC</h1>
                <ul>
                    <li v-for="lesson in lessons" :key="lesson.id" class="lesson-card p-3" @click="changeVideo(lesson)"
                        :class="{ watching: lesson.current, completed: lesson.completed }">
                        <div class="lesson-status">
                            <i v-if="lesson.completed" class="fas fa-check-circle text-primary status-icon"
                                title="Hoàn thành"></i>
                            <i v-else-if="lesson.current" class="fas fa-play-circle text-warning status-icon"
                                title="Đang học"></i>
                            <i v-else class="far fa-circle text-secondary status-icon" title="Chưa học"></i>
                        </div>

                        <div class="lesson-content">
                            <div class="lesson-index"><span class="lesson-title">{{ lesson.title }}</span></div>
                            <div class="lesson-desc">{{ lesson.description }}</div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>

    </div>
</template>
<style scoped>
.courset-s {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.progress-container {
    display: flex;
    align-items: center;
    gap: 20px;
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

.lesson-list-scrollable,
.note-panel {
    background-color: #fff;
    height: calc(100% - 65px);
    overflow-y: auto;
    padding-right: 10px;
    text-align: left;
    position: fixed;
    top: 65px;
    right: 0;
    width: 30%;
    z-index: 100;
}

.lesson-list-scrollable {
    direction: rtl;
}

.note-panel {
    z-index: 200;
    right: -100%;
}

.note-panel.active {
    right: 0;
}

.course-header {
    flex-grow: 1;
}

.video-player {
    width: 100%;
    height: 360px;
    border-radius: 16px;
    border: none;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
}

.course-title {
    font-size: 22px;
    font-weight: 700;
}

.instructor {
    font-size: 16px;
    color: #6c757d;
}

.lesson-card {
    background: white;
    border-radius: 12px;
    border-left: 4px solid #dee2e6;
    margin-bottom: 12px;
    margin-left: 8px;
    display: flex;
    align-items: flex-start;
    gap: 12px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.04);
    transition: all 0.2s ease;
    cursor: pointer;
}

.lesson-card:hover {
    transform: translateY(-2px);
    background-color: #eeedff;
    box-shadow: 0 4px 16px rgba(0, 0, 0, 0.08);
}

.lesson-card.watching {
    border-left: 6px solid #eef125;
    background-color: #f8fcdb;
}

.lesson-card.completed {
    border-left: 6px solid #4176e9;
}

.lesson-status .badge {
    font-size: 12px;
    padding: 4px 8px;
    border-radius: 999px;
    font-weight: 500;
}


.badge.completed {
    background-color: #4176e9;
    color: white;
}

.badge.watching {
    background-color: #eef125;
    color: white;
}

.badge.not-started {
    background-color: #dee2e6;
    color: #495057;
}

.lesson-content {
    flex: 1;
}

.lesson-index {
    font-weight: bold;
    margin-bottom: 4px;
    color: #343a40;
}

.lesson-title {
    font-size: 16px;
    font-weight: 600;
    margin-bottom: 4px;
}

.lesson-desc {
    font-size: 14px;
    color: #6c757d;
}

.status-icon {
    font-size: 20px;
    margin-right: 8px;
}

.note-section {
    background-color: #fff;
    padding: 20px;
    border-radius: 16px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.05);
}

.note-item:hover {
    background-color: #f9f9f9;
}

textarea:focus {
    outline: none;
}

.border-bottom {
    border-bottom: 1px solid #ccc;
}
</style>