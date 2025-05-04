<template>
    <div v-if="openScheduleModal" class="modal-backdrop">
        <div class="modal-content p-4 rounded shadow bg-white rounded-3" style="width: 600px; max-width: 90%;">
            <div class="d-flex justify-content-between align-items-center mb-4">
                <h4 class="fs-4">Thiết lập lịch học hàng tuần</h4>
                <button class="text-danger" @click="onCloseDetail">
                    <i class="fas fa-times"></i>
                </button>
            </div>

            <p class="text-muted">Chọn các ngày bạn muốn học. Hệ thống sẽ giúp ước lượng ngày hoàn thành và nhắc nhở
                bạn.</p>

            <label class="form-label fw-bold">Chọn các ngày học:</label>
            <div class="mb-3">
                <div v-for="day in days" :key="day" class="form-check">
                    <input type="checkbox" :id="day" :value="day" v-model="selectedDays" class="form-check-input" />
                    <label :for="day" class="form-check-label">{{ day }}</label>
                </div>
            </div>

            <label class="form-label fw-bold">Thời gian mỗi buổi học:</label>
            <input type="time" v-model="sessionTime" class="form-control mb-3 w-100" />

            <button class="btn btn-primary w-100" @click="confirmSchedule">Xác nhận lịch học</button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, defineProps, defineEmits } from 'vue'

defineProps<{
    openScheduleModal: boolean
}>()

const emit = defineEmits(['confirm', 'setClose'])

const onCloseDetail = () => {
    emit('setClose', false)
}

const days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday']
const selectedDays = ref<string[]>([])
const sessionTime = ref('19:00')

function confirmSchedule() {
    emit('confirm', {
        selectedDays: selectedDays.value,
        sessionTime: sessionTime.value,
    })
}
</script>

<style scoped>
.modal-backdrop {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    background: rgba(0, 0, 0, 0.5);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 1000;
}
</style>