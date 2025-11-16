<template>
    <div class="col-md-6 d-flex align-items-start mb-4">
        <div class="circle back-blue text-white d-flex justify-content-center align-items-center rounded-circle">
            {{ index < 10 ? '0' + index : index }} </div>
                <div class="ml-3">
                    <h2 class="h5 font-weight-bold font-blue mb-2">{{ title }}</h2>
                    <p>{{ description }}</p>
                </div>
        </div>
</template>

<script setup lang="ts">
defineProps<{
    index: number
    title: string
    description: string
}>()
</script>