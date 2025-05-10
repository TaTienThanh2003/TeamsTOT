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
    labels: ['T1', 'T2', 'T3', 'T4', 'T5', 'T6'],
    datasets: [
        {
            label: 'Học viên mới',
            data: [120, 190, 300, 250, 320, 400],
            backgroundColor: '#0d6efd',
        },
    ],
}

const chartOptions = {
    responsive: true,
    plugins: {
        legend: {
            display: false,
        },
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
