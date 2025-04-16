<script setup lang="ts">
import { defineProps } from 'vue'

defineProps<{
    title: string
}>()

</script>
<template>
    <div class="card mb-3 p-3">
        <div class="d-flex justify-content-between">
            <div>
                <p>{{ title }}</p>
                <small>🎥 Video - 6:00</small>
            </div>
            <a href="#" class="btn btn-outline-warning align-self-center">Xem miễn phí</a>
        </div>
    </div>
</template>