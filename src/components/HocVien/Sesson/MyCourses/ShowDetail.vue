<script setup lang="ts">

defineProps<{
    lessons: {
        id: number;
        title: string;
        description: string;
        completed: boolean;
        current?: boolean; // bài đang học
        videoUrl?: string;
    }[];
}>();

const emit = defineEmits(['back']);

</script>


<template>
    <div class="course-detail row">
        <!-- Video + Info -->
        <div class="course-info">
            <h2 class="course-title">Khóa học TOIEC</h2>
            <!-- <p class="instructor">Giảng viên: {{ course.teacher.name }} - {{ course.teacher.title }}</p> -->
        </div>

        <div class="course-header col-md-6">
            <iframe class="video-player" src="https://www.youtube.com/embed/md3HfH0SWOI?si=Jz-ce3qM3NhZXoc7"
                title="Giới thiệu khóa học" frameborder="0"
                allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                allowfullscreen></iframe>
        </div>

        <!-- Bài học -->
        <div class="lesson-list col-md-6">
            <button class="btn btn-sm btn-outline-secondary mb-3" @click="emit('back')">← Back to list</button>
            <ul>
                <li v-for="(lesson, index) in lessons" :key="lesson.id" class="lesson-card"
                    :class="{ watching: lesson.current, completed: lesson.completed }">
                    <div class="lesson-status">
                        <span v-if="lesson.completed" class="badge completed">Hoàn thành</span>
                        <span v-else-if="lesson.current" class="badge watching">Đang học</span>
                        <span v-else class="badge not-started">Chưa học</span>
                    </div>
                    <div class="lesson-content">
                        <div class="lesson-index"><span class="lesson-title">{{ lesson.title
                        }}</span></div>
                        <div class="lesson-desc">{{ lesson.description }}</div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</template>
<style scoped>
.course-detail {
    padding: 20px;
    background: #f8f9fa;
    border-radius: 12px;
    box-shadow: 0 8px 24px rgba(0, 0, 0, 0.05);
}

.course-header {
    display: flex;
    flex-direction: column;
    gap: 16px;
    margin-bottom: 32px;
}

.video-player {
    width: 100%;
    aspect-ratio: 16 / 9;
    border-radius: 16px;
    border: none;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
}

.course-title {
    font-size: 24px;
    font-weight: 700;
    margin-bottom: 4px;
}

.instructor {
    font-size: 16px;
    color: #6c757d;
}

.lesson-list ul {
    list-style: none;
    padding: 0;
    margin: 0;
}

.lesson-card {
    background: white;
    border-radius: 12px;
    padding: 16px;
    margin-bottom: 12px;
    display: flex;
    align-items: flex-start;
    gap: 12px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.04);
    transition: all 0.2s ease;
}

.lesson-card:hover {
    transform: translateY(-2px);
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
</style>