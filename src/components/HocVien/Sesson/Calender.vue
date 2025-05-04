<script setup lang="ts">
import { ref } from "vue";
import "@lbgm/pro-calendar-vue/style";

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

const selectedDays = ['Monday', 'Wednesday', 'Friday'];
const dayIndex: Record<string, number> = {
    'Sunday': 0,
    'Monday': 1,
    'Tuesday': 2,
    'Wednesday': 3,
    'Thursday': 4,
    'Friday': 5,
    'Saturday': 6,
};

const startDate = new Date('2025-04-07'); // ngày bắt đầu
const weeks = 4;

function generateSchedule(start: Date, selectedDays: string[], weeks: number) {
    const events: Appointment[] = [];
    let id = 1;

    for (let week = 0; week < weeks; week++) {
        selectedDays.forEach(day => {
            const targetDay = dayIndex[day];
            const currentWeekStart = new Date(start);
            currentWeekStart.setDate(start.getDate() + week * 7);

            const diff = (targetDay - currentWeekStart.getDay() + 7) % 7;
            const eventDate = new Date(currentWeekStart);
            eventDate.setDate(currentWeekStart.getDate() + diff);
            eventDate.setHours(9, 0, 0); // học lúc 9h

            events.push({
                id: id++ + '',
                date: eventDate.toISOString(),
                name: `Học TOEIC - ${day}`,
                keywords: 'toeic, học'
            });
        });
    }

    return events;
}

const evts = ref(generateSchedule(startDate, selectedDays, weeks));
</script>

<template>
    <div class="tab-pane fade" id="schedule">
        <pro-calendar :events="evts" :config="cfg" @calendarClosed="void 0" />
    </div>
</template>

<style scoped></style>