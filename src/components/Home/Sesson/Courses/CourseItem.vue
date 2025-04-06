<script setup lang="ts">
import { defineProps } from 'vue'

defineProps<{
  title: string
  image: string
  features: string[]
}>()

</script>

<template>
  <div class="bg-primary text-white rounded p-3" style="width: 20rem;">
    <div class="d-flex justify-content-center mb-3">
      <img :src="image" alt="Course Image" class="rounded border border-white" width="150" height="150" />
    </div>
    <h2 class="h5 fw-bold text-center mb-2">{{ title }}</h2>
    <ul class="small">
      <li v-for="(feature, index) in features" :key="index">{{ feature }}</li>
    </ul>
    <div class="text-center">
      <a href="#" class="text-warning fw-bold text-decoration-none">Xem thêm &gt;&gt;&gt;</a>
    </div>
  </div>
</template>
