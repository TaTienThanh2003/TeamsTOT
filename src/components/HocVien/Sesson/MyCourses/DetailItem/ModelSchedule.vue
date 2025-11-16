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
                <div v-for="day in availableDays" :key="day.value" class="form-check">
                    <input type="checkbox" :id="day.value" :value="day.value" v-model="selectedDays" class="form-check-input" />
                    <label :for="day.value" class="form-check-label">{{ day.label }}</label>
                </div>
            </div>

            <label class="form-label fw-bold">Thời gian mỗi buổi học:</label>
            <select v-model="sessionTime" class="form-control mb-3 w-100">
                <option value="">Chọn thời gian</option>
                <option v-for="time in availableTimes" :key="time.value" :value="time.value">
                    {{ time.label }}
                </option>
            </select>

            <button class="btn btn-primary w-100" @click="confirmSchedule" :disabled="isLoading">
                <span v-if="isLoading" class="spinner-border spinner-border-sm me-2"></span>
                {{ isLoading ? 'Đang tạo...' : 'Xác nhận lịch học' }}
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, defineProps, defineEmits } from 'vue'
import { createSchedule, getSchedulesByCourse } from '@/services';
import { useToast } from 'vue-toastification';

const toast = useToast();

const props = defineProps<{
    openScheduleModal: boolean,
    courseId?: number // Thêm courseId từ parent
}>()

const emit = defineEmits(['confirm', 'setClose', 'scheduleCreated'])

const onCloseDetail = () => {
    emit('setClose', false)
}

const availableDays = [
    { value: 'Monday', label: 'Thứ 2' },
    { value: 'Tuesday', label: 'Thứ 3' },
    { value: 'Wednesday', label: 'Thứ 4' },
    { value: 'Thursday', label: 'Thứ 5' },
    { value: 'Friday', label: 'Thứ 6' },
    { value: 'Saturday', label: 'Thứ 7' },
    { value: 'Sunday', label: 'Chủ nhật' }
];

const availableTimes = [
    { value: '09:00', label: '09:00' },
    { value: '10:00', label: '10:00' },
    { value: '14:00', label: '14:00' },
    { value: '15:00', label: '15:00' },
    { value: '16:00', label: '16:00' },
    { value: '19:00', label: '19:00' },
    { value: '20:00', label: '20:00' }
];

const selectedDays = ref<string[]>([])
const sessionTime = ref('19:00')
const isLoading = ref(false)

async function confirmSchedule() {
    if (selectedDays.value.length === 0) {
        toast.error('Vui lòng chọn ít nhất một ngày học');
        return;
    }

    if (!sessionTime.value) {
        toast.error('Vui lòng chọn thời gian học');
        return;
    }

    isLoading.value = true;

    try {
        const user = JSON.parse(localStorage.getItem('user') || '{}');
        if (!user.id) {
            toast.error('Không tìm thấy thông tin người dùng');
            return;
        }
        // Lấy lịch học đã đăng ký cho course này
        let existedDays: string[] = [];
        if (props.courseId) {
            const existed = await getSchedulesByCourse(user.id, props.courseId);
            if (existed && existed.data && Array.isArray(existed.data)) {
                existedDays = existed.data
                    .filter((s: any) => s.timeLearn === sessionTime.value)
                    .flatMap((s: any) => s.dayOfWeek.split(',').map((d: string) => d.trim()));
            }
        }
        // Kiểm tra giao giữa các ngày đã chọn và đã đăng ký
        const duplicatedDays = selectedDays.value.filter(day => existedDays.includes(day));
        if (duplicatedDays.length > 0) {
            toast.error('Bạn đã đăng ký lịch học cho các ngày: ' + duplicatedDays.join(', '));
            isLoading.value = false;
            return;
        }
        // Gửi 1 request duy nhất
        const scheduleData = {
            studentId: user.id,
            courses_id: props.courseId || 1,
            dayOfWeek: selectedDays.value.join(','),
            timeLearn: sessionTime.value
        };
        const result = await createSchedule(scheduleData);
        toast.success('Đặt lịch học thành công!');
        selectedDays.value = [];
        sessionTime.value = '19:00';
        emit('setClose', false);
        emit('scheduleCreated', [result]);
        window.dispatchEvent(new CustomEvent('schedules-updated', { detail: { schedules: [result] } }));
    } catch (error: any) {
        console.error('Lỗi tạo lịch học:', error);
        let errorMessage = 'Không thể tạo lịch học. Vui lòng thử lại.';
        if (error.response) {
            if (error.response.status === 400) {
                errorMessage = 'Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.';
            } else if (error.response.status === 409) {
                errorMessage = 'Lịch học này đã tồn tại.';
            } else if (error.response.status === 500) {
                errorMessage = 'Lỗi server. Vui lòng thử lại sau.';
            }
        }
        toast.error(errorMessage);
    } finally {
        isLoading.value = false;
    }
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