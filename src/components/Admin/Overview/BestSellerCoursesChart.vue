<script setup lang="ts">
import { Bar } from 'vue-chartjs'
import {
    Chart as ChartJS,
    Title,
    Tooltip,
    Legend,
    BarElement,
    CategoryScale,
    LinearScale
} from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)

const chartData = {
    labels: ['IELTS 6.5+', 'Giao tiếp cơ bản', 'TOEIC A+', 'Thiếu nhi', 'Starter Speaking'],
    datasets: [
        {
            label: 'Số lượt đăng ký',
            data: [320, 280, 150, 220, 180],
            backgroundColor: '#ffc107',
        }
    ]
}

const chartOptions = {
    responsive: true,
    plugins: {
        legend: {
            position: 'top' as const,
        },
        title: {
            display: true,
            text: 'Top khóa học bán chạy',
        }
    },
    scales: {
        y: {
            beginAtZero: true,
        },
    },
}
</script>

<template>
    <Bar :data="chartData" :options="chartOptions" />
</template>
