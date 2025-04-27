<script setup lang="ts">
import { ref } from 'vue';

defineProps<{
    showNoteInput: boolean;
}>();

const emit = defineEmits(['setClose']);

const onCloseDetail = () => {
    emit('setClose', false)
}
const notes = ref([
    { text: 'Ghi nhớ mẫu câu chào hỏi cơ bản', date: '2025-04-15' },
    { text: 'Từ vựng về gia đình và bạn bè', date: '2025-04-17' },
    { text: 'Luyện nghe bài 3: Daily routine', date: '2025-04-20' },
    { text: 'Ngữ pháp: thì hiện tại tiếp diễn', date: '2025-04-21' }
])
</script>

<template>
    <div v-if="showNoteInput" :class="showNoteInput ? 'note-panel active' : 'note-panel'">
        <div class="note-content">
            <div class="d-flex justify-between align-items-center mb-4">
                <h3 class="fs-5 bold">Ghi chú của bạn</h3>
                <button class="fs-5" @click="onCloseDetail()">
                    <i class="fas fa-times"></i>
                </button>
            </div>
            <input type="text" placeholder="Tìm ghi chú..." class="note-search" />
            <ul class="note-list">
                <li v-for="(note, index) in notes" :key="index" class="note-item">
                    <div class="note-text">📌 {{ note.text }}</div>
                    <div class="note-time">{{ note.date }}</div>
                </li>
            </ul>
        </div>

    </div>
</template>
<style scoped>
.note-content {
    padding: 16px;
    font-family: 'Segoe UI', sans-serif;
}

.note-search {
    width: 100%;
    padding: 8px 12px;
    margin-bottom: 14px;
    border: 1px solid #ccc;
    border-radius: 6px;
    font-size: 14px;
}

.note-list {
    list-style: none;
    padding: 0;
    margin: 0;
    display: flex;
    flex-direction: column;
    gap: 12px;
}

.note-item {
    background: #fdfdfd;
    border-left: 4px solid #dee2e6;
    padding: 12px 16px;
    border-radius: 8px;
    box-shadow: 0 1px 4px rgba(0, 0, 0, 0.05);
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.note-text {
    font-size: 14px;
    color: #333;
}

.note-time {
    font-size: 12px;
    color: #888;
}
</style>