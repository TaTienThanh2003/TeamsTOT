<script setup lang="ts">
import { ref } from "vue";
import "@lbgm/pro-calendar-vue/style";

interface Appointment {
    id: string;
    date: string;
    name: string;
    keywords: string;
    comment?: string;
    createdAt?: string;
    updatedAt?: string;
}


const evts = ref<Appointment[]>([
    {
        id: "1",
        date: "2025-04-07T09:00:00",
        name: "Cuộc họp nhóm",
        keywords: "họp, nhóm"
    },
    {
        id: "2",
        date: "2025-04-08T14:30:00",
        name: "Họp dự án A",
        keywords: "dự án, họp"
    }
]);
</script>

<template>
    <div class="tab-pane fade" id="schedule">
        <pro-calendar :events="evts" />
    </div>
</template>