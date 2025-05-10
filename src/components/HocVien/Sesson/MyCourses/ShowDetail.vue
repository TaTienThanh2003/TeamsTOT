<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import NoteList from './DetailItem/NoteList.vue';
import CommentList from './DetailItem/CommentList.vue';
import ModelSchedule from './DetailItem/ModelSchedule.vue';
import DetailItem from '@/components/Home/Detail/DetailItem.vue';
import i18n from '@/i18n';

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
            videoUrl: string;
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

    props.sections.forEach(section => {
        section.lessons.forEach(l => {
            l.current = false;
        });
    });
    lesson.current = true;
    currentLesson.value = lesson;
}

const OnPrevVideo = () => {
    let found = false;

    for (let i = 0; i < props.sections.length; i++) {
        const section = props.sections[i];
        for (let j = 0; j < section.lessons.length; j++) {
            const l = section.lessons[j];

            if (l === currentLesson.value) {
                l.current = false;

                if (i === 0 && j === 0) return; // Đang ở bài đầu tiên
                if (j > 0) {
                    const prev = section.lessons[j - 1];
                    prev.current = true;
                    currentLesson.value = prev;
                } else {
                    const prevSection = props.sections[i - 1];
                    const prev = prevSection.lessons[prevSection.lessons.length - 1];
                    prev.current = true;
                    currentLesson.value = prev;
                }

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
                } else if (i < props.sections.length - 1) {
                    const nextSection = props.sections[i + 1];
                    if (nextSection.lessons.length > 0) {
                        const next = nextSection.lessons[0];
                        next.current = true;
                        currentLesson.value = next;
                    }
                }

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
onMounted(() => {
    if (props.sections.length > 0 && props.sections[0].lessons.length > 0) {
        currentLesson.value = props.sections[0].lessons[0];
        currentLesson.value.current = true;
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
                            <h2 class="course-title m-0 fs-4">{{ locale === 'vi' ? currentLesson.titleVI : currentLesson.titleEN }}</h2>
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
                    <iframe class="video-player" :src="currentLesson.video_url" title="Giới thiệu khóa học"
                        frameborder="0"
                        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                        allowfullscreen></iframe>
                </div>
            </div>
            <div class="d-flex justify-content-center gap-2 mb-2">
                <button class="btn btn-outline-primary p-2" @click="OnPrevVideo">
                    Bài học trước
                </button>
                <button class="btn btn-outline-primary  p-2" @click="OnNextVideo">
                    Bài học tiếp
                </button>
            </div>

            <NoteList :lessonid="currentLesson.id" :showNoteInput="showNoteInput" @setClose="toggleCloseNote" />
            <CommentList :lessonid="currentLesson.id" :showCommentInput="showCommentInput" @setClose="toggleCloseComment" />

            <div class="lesson-details">
                <p class="lesson-content mb-5 fs-5 fw-bold">{{ locale === 'vi' ? currentLesson.desVI : currentLesson.desEN }}</p>

                <div class="center-info">
                    <h3 class="fs-6 mb-3">Tham gia cộng đồng học tập để trao đổi, hỏi đáp và cập nhật thông tin mới nhất
                        từ trung tâm.</h3>
                    <p>
                        📘 Nhóm học tập:
                        <a href="https://www.facebook.com/groups/ten-nhom" target="_blank" rel="noopener noreferrer">
                            https://www.facebook.com/groups/ten-nhom
                        </a>
                    </p>
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

                    <DetailItem v-for="(section, index) in sections" :key="index" :title="section.title"
                        :lessons="section.lessons" :isLocked="false" @play="changeVideo" />
                </div>
            </div>
        </div>
    </div>
    <ModelSchedule :openScheduleModal="openScheduleModal" @setClose="toggleCloseModel" />
</template>
<style scoped>
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

.video-wrapper {
    position: relative;
    width: 100%;
    max-width: 800px;
    aspect-ratio: 16 / 9;
    border-radius: 4px;
    overflow: hidden;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
}

.video-wrapper iframe {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    border: none;
}


.course-title {
    font-size: 22px;
    font-weight: 600;
    color: #333;
}

.lesson-content {
    flex: 1;
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

.lesson-details {
    background-color: #fff;
    padding: 20px;
    border-radius: 8px;
}
</style>