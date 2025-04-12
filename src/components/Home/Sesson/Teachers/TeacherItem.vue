<script setup lang="ts">
import { defineProps } from 'vue'

defineProps<{
    fullname: string
    image: string
}>()
</script>

<template>
    <div class="col">
        <div class="text-center">
            <div class="d-flex justify-content-center">
                <img :src="image" :alt="fullname" class="rounded-circle mb-3" width="150" height="150" />
            </div>
            <h2 class="h5 fw-semibold font-blue">{{ fullname }}</h2>
            <p class="text-muted mb-1">{{ $t('home.page4.role') }}</p>
            <p class="text-secondary small">{{ $t('home.page4.years') }}</p>
        </div>
    </div>
</template>
