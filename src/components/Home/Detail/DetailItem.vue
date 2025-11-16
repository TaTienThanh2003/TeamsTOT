<script setup lang="ts">
import { ref } from 'vue';
import i18n from '@/i18n';

const props = defineProps<{
  title: string;
  isLocked: boolean;
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
}>();

const emit = defineEmits<{
  (e: 'play', lesson: any): void;
}>();

const locale = i18n.global.locale.toUpperCase();
const showLessons = ref(false);

const changeVideo = (lesson: any) => {
  emit('play', lesson);
};
</script>

<template>
  <div class="card mb-3 p-3">
    <div class="d-flex justify-content-between align-items-center" @click="showLessons = !showLessons"
      style="cursor: pointer;">
      <p class="mb-0 fw-bold">{{ title }}</p>
      <span style="font-size: 1.2rem;">
        <i :class="showLessons ? 'fas fa-chevron-up' : 'fas fa-chevron-down'"></i>
      </span>
    </div>

    <ul v-if="showLessons" class="mt-3 list-group">
      <li v-for="lesson in lessons" :key="lesson.id" class="lesson-card p-3 list-group-item"
        @click="changeVideo(lesson)" :class="{ completed: lesson.completed, watching: lesson.current }"
        style="cursor: pointer;">
        <div class="lesson-status me-3">
          <i v-if="lesson.current" class="fas fa-pause-circle text-warning status-icon" title="Đang học"></i>
          <i v-else-if="lesson.completed" class="fas fa-check-circle text-primary status-icon" title="Hoàn thành"></i>
          <i v-else-if="isLocked" class="fas fa-lock text-muted"></i>
          <i v-else class="far fa-play-circle text-secondary status-icon" title="Chưa học"></i>
        </div>

        <div class="lesson-content">
          <div class="lesson-title fw-semibold">
            {{ locale === 'VI' ? lesson.titleVI : lesson.titleEN }}
          </div>
        </div>
      </li>
    </ul>
  </div>
</template>

<style scoped>
.lesson-card {
  display: flex;
  align-items: center;
  background-color: #f8f9fa;
  border: none;
  border-radius: 12px;
  margin-bottom: 0.5rem;
  box-shadow: 0 1px 4px rgba(0, 0, 0, 0.04);
  padding: 12px 16px;
  transition: background-color 0.2s ease;
}

.lesson-card:hover {
  background-color: #f1f3f5;
}

.lesson-card.watching {
  background-color: #fff8e1;
}

.lesson-status {
  min-width: 24px;
}

.lesson-title {
  font-weight: 500;
}

.video-player {
  width: 100%;
  height: 360px;
  border-radius: 16px;
  border: none;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.08);
}

.status-icon {
  font-size: 1.2rem;
}

.fade-enter-active,
.fade-leave-active {
  transition: all 0.3s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
  transform: translateY(-5px);
}
</style>
