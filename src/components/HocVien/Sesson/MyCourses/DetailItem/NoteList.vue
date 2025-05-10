<script setup lang="ts">
import { getNotebylesson } from '@/services';
import { onMounted, ref, watch } from 'vue';

const props = defineProps<{
    showNoteInput: boolean;
    lessonid: number;
}>();
const openSchedule = ref(false)
const emit = defineEmits(['setClose']);
const notes = ref<any>([]);
const user = JSON.parse(localStorage.getItem("user") || "{}");
const userId = user.id;

const onCloseDetail = () => {
    emit('setClose', false)
}
// const notes = ref([
//     { text: 'Ghi nhớ mẫu câu chào hỏi cơ bản', date: '2025-04-15' },
//     { text: 'Từ vựng về gia đình và bạn bè', date: '2025-04-17' },
//     { text: 'Luyện nghe bài 3: Daily routine', date: '2025-04-20' },
//     { text: 'Ngữ pháp: thì hiện tại tiếp diễn', date: '2025-04-21' }
// ])
const getNotes = async () => {
    try {
        const res = await getNotebylesson(props.lessonid, userId);
        const resdata = res.data;
        notes.value = resdata.map((note: any) => ({
            text: note.text,
            time: note.video_time
        }));
    } catch (error) {

    }
}
onMounted(() => {
    if (props.lessonid) {
        getNotes();
    }
});

watch(() => props.lessonid, (newId) => {
    if (newId) {
        getNotes();
    }
});
</script>

<template>
    <div v-if="showNoteInput" :class="showNoteInput ? 'note-panel active' : 'note-panel'">
        <div class="note-content">
            <div class="d-flex justify-between align-items-center mb-3 p-0">
                <h3 class="fs-5 bold">Ghi chú của bạn</h3>
                <button class="fs-5" @click="onCloseDetail()">
                    <i class="fas fa-times"></i>
                </button>
            </div>
            <div v-if="!openSchedule" class="d-flex justify-content-between">
                <button class="btn btn-sm btn-outline-primary" @click="openSchedule = true">
                    + Ghi chú
                </button>
                <select class="form-select w-auto">
                    <option value="all">Tất cả bài học</option>
                    <option value="current">Bài học hiện tại</option>
                </select>
            </div>

            <div v-if="openSchedule" class="mb-3">
                <textarea id="note" class="form-control" placeholder="Nhập nội dung ghi chú..." rows="3"
                    style="width: 100%;"></textarea>

                <div class="d-flex justify-content-end mt-2 gap-2">
                    <button class="btn btn-secondary btn-sm" @click="openSchedule = false">
                        Hủy
                    </button>
                    <button class="btn btn-primary btn-sm">
                        <i class="fas fa-paper-plane me-1"></i> Gửi
                    </button>
                </div>
            </div>
        </div>
        <ul class="note-list px-2">
            <li v-for="(note, index) in notes" :key="index" class="note-item">
                <div class="note-text">📌 {{ note.text }}</div>
                <div class="note-time">{{ note.time }}</div>
            </li>
        </ul>
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