<script setup lang="ts">
import { defineProps } from 'vue'

defineProps<{
  title: string
  image: string
  features: string[]
}>()

</script>

<template>
  <div class="back-blue text-white p-3 hover-lift">
    <div class="d-flex justify-content-center mb-3">
      <img :src="image" alt="Course Image" class="rounded border border-white" width="150" height="150" />
    </div>
    <h2 class="h5 fw-bold text-center mb-2">{{ title }}</h2>
    <ul class="small">
      <li v-for="(feature, index) in features" :key="index">{{ feature }}</li>
    </ul>
    <div class="text-center">
      <router-link class="text-warning fw-bold text-decoration-none" to="/detail-course">
        {{ $t('home.page3.button') }}
      </router-link>
    </div>
  </div>
</template>

<style scoped>
.hover-lift {
  min-height: 24rem;
  width: 20rem;
  border-radius: 10px;
  margin-top: 10px;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.hover-lift:hover {
  transform: translateY(-6px);
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
}
</style>
