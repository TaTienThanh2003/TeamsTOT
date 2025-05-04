<script setup lang="ts">
import { defineProps } from 'vue'

defineProps<{
  name: string,
  img: string,
  status: string
}>()
</script>

<template>
  <div class="card shadow-sm rounded mx-3" style="width: 18rem; position: relative;">
    <span class="badge position-absolute top-0 start-0 m-2" :class="{
      'bg-success': status === 'Đang học',
      'bg-secondary': status === 'Đã kết thúc'
    }">
      {{ status }}
    </span>
    <img :src="img" class="img-courses" alt="Khóa học tiếng Anh online" />
    <div class="card-body">
      <h5 class="card-title">{{ name }}</h5>
      <div class="d-flex align-items-center">
        <span class="text-warning">★ ★ ★ ★ ☆</span>
        <span class="text-muted ms-2">(131)</span>
        <i class="far fa-calendar-alt ms-auto"></i>
      </div>
      <a v-if="status === 'Đang học'" href="#" class="btn btn-light border mt-3">
        Bắt đầu
      </a>
      <a v-else class="btn btn-outline-secondary mt-3 disabled">
        Hết hạn
      </a>
    </div>
  </div>
</template>
