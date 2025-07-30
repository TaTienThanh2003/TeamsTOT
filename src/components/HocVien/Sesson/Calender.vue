<script setup lang="ts">
import { ref, onMounted, onUnmounted } from "vue";
import "@lbgm/pro-calendar-vue/style";
import { getSchedules } from '@/services';
import { useToast } from 'vue-toastification';

const toast = useToast();

const cfg = ref<any>({
    searchPlaceholder: "Nhập vào đây",
    closeText: "Hiển thị",
});

interface Appointment {
    id: string;
    date: string;
    name: string;
    keywords: string;
    comment?: string;
    createdAt?: string;
    updatedAt?: string;
}

const dayIndex: Record<string, number> = {
    'Sunday': 0,
    'Monday': 1,
    'Tuesday': 2,
    'Wednesday': 3,
    'Thursday': 4,
    'Friday': 5,
    'Saturday': 6,
};

const evts = ref<Appointment[]>([]);

// Load schedules from API
const loadSchedules = async () => {
    try {
        const user = JSON.parse(localStorage.getItem('user') || '{}');
        const userId = user.id;
        
        const response = await getSchedules(userId);
        
        // Convert API data to calendar events
        const apiEvents: Appointment[] = [];
        
        // Kiểm tra cấu trúc response và xử lý đúng
        let schedulesData = [];
        if (response.data && Array.isArray(response.data)) {
            schedulesData = response.data;
        } else if (response && Array.isArray(response)) {
            schedulesData = response;
        } else if (response && response.data && response.data.data && Array.isArray(response.data.data)) {
            schedulesData = response.data.data;
        }
        
        if (schedulesData.length === 0) {
            evts.value = [];
            return;
        }
        
        schedulesData.forEach((schedule: any, index: number) => {
            const days = schedule.dayOfWeek.split(',').map((d: string) => d.trim());
            const start = new Date(schedule.start_date);
            const end = new Date(schedule.end_date);
            days.forEach((day: string) => {
                const targetDay = dayIndex[day];
                for (let d = new Date(start); d <= end; d.setDate(d.getDate() + 1)) {
                    if (d.getDay() === targetDay) {
                        const eventDate = new Date(d);
                        const [hours, minutes] = schedule.timeLearn.split(':');
                        eventDate.setHours(parseInt(hours), parseInt(minutes), 0, 0);
                        apiEvents.push({
                            id: `${schedule.id}-${eventDate.toISOString().slice(0,10)}-${day}`,
                            date: eventDate.toISOString(),
                            name: `Học ${schedule.courses?.titleVI || 'TOEIC'} - ${day}`,
                            keywords: 'toeic, học'
                        });
                    }
                }
            });
        });
        
        // Cập nhật events
        evts.value = apiEvents;
        
    } catch (error) {
        console.error('Lỗi load schedules:', error);
        toast.error('Không thể tải lịch học');
    }
};

// Hàm để refresh calendar từ bên ngoài
const refreshCalendar = () => {
    loadSchedules();
};

// Event listener để lắng nghe khi có schedule mới được tạo
const handleSchedulesUpdated = () => {
    loadSchedules();
};

// Expose function để component cha có thể gọi
defineExpose({
    refreshCalendar
});

onMounted(() => {
    loadSchedules();
    // Lắng nghe event schedules-updated
    window.addEventListener('schedules-updated', handleSchedulesUpdated);
});

onUnmounted(() => {
    // Cleanup event listener
    window.removeEventListener('schedules-updated', handleSchedulesUpdated);
});
</script>

<template>
    <div class="tab-pane fade" id="schedule">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h4>Lịch học</h4>
            <button class="btn btn-outline-primary" @click="loadSchedules" title="Refresh lịch học">
                <i class="fas fa-sync-alt me-2"></i>
                Làm mới
            </button>
        </div>
        
        <div v-if="evts.length === 0" class="text-center py-4">
            <i class="fas fa-calendar-times fa-3x text-muted mb-3"></i>
            <p class="text-muted">Chưa có lịch học nào</p>
        </div>
        
        <pro-calendar v-else :events="evts" :config="cfg" @calendarClosed="void 0" />
    </div>
</template>

<style scoped>
/* Không cần modal styles nữa vì không có chức năng thêm */
</style>
