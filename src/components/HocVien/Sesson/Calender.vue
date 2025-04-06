<template>
    <div class="tab-pane fade" id="schedule">
        <div id="calendar" style="height: 500px;"></div>
    </div>
</template>

<script setup lang="ts">
import '@/assets/css/main.min.css'
import '@/assets/js/main.min.js'
import { onMounted } from 'vue'

onMounted(() => {
    let calendar: any = null

    const tabLink = document.querySelector('a[href="#schedule"]')
    if (tabLink) {
        tabLink.addEventListener('shown.bs.tab', () => {
            const calendarEl = document.getElementById('calendar')
            if (calendarEl && !calendar) {
                // @ts-ignore vì FullCalendar là biến toàn cục (window.FullCalendar)
                calendar = new FullCalendar.Calendar(calendarEl, {
                    initialView: 'dayGridMonth',
                    locale: 'vi',
                    events: [
                        { title: 'Học React', start: '2025-04-01' },
                        { title: 'Họp nhóm', start: '2025-04-05' },
                    ],
                })
                calendar.render()
            }
        })
    }
})
</script>