<script setup lang="ts">
import { defineProps } from 'vue'

defineProps<{
    fullname: string
    image: string
    des: string
}>()
</script>

<template>
    <div class="col">
        <div class="text-center">
            <img :src="image" :alt="fullname" class="rounded-circle mb-3" width="150" height="150" />
            <h2 class="h5 fw-semibold text-primary">{{ fullname }}</h2>
            <p class="text-muted mb-1">Giảng viên {{ des }}</p>
            <p class="text-secondary small">4 năm kinh nghiệm</p>
        </div>
    </div>
</template>
