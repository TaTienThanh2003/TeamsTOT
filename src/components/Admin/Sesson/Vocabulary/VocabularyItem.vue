<template>
  <div class="container py-4">
    <div class="card shadow-sm p-3 mb-2">
      <h5 class="mb-3">
        {{ wordData.word }} <span class="text-muted">({{ wordData.type }})</span> /{{ wordData.phonetic }}/
      </h5>
      <p><strong>Định nghĩa:</strong> {{ wordData.definition }}</p>
      <p><strong>Ví dụ:</strong> <em>{{ wordData.example }}</em></p>
      <img :src="wordData.image" alt="illustration" class="img-fluid mt-3 rounded" style="max-height: 200px;" />
    </div>
    <div class="card shadow-sm p-3 mb-2">
      <h5 class="mb-3">
        {{ wordData.word }} <span class="text-muted">({{ wordData.type }})</span> /{{ wordData.phonetic }}/
      </h5>
      <p><strong>Định nghĩa:</strong> {{ wordData.definition }}</p>
      <p><strong>Ví dụ:</strong> <em>{{ wordData.example }}</em></p>
      <img :src="wordData.image" alt="illustration" class="img-fluid mt-3 rounded" style="max-height: 200px;" />
    </div>
  </div>
</template>

<script setup lang="ts">
const props = defineProps<{
  wordData: {
    word: string;
    type: string;
    phonetic: string;
    definition: string;
    example: string;
    image: string;
  };
}>();
</script>
