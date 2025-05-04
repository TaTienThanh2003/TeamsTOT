<script setup lang="ts">
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
    type ChartOptions
} from 'chart.js'
import { Line } from 'vue-chartjs'

// Đăng ký các thành phần ChartJS
ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
)

// Dữ liệu biểu đồ
const data = {
    labels: ['Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6', 'Thứ 7', 'CN'],
    datasets: [
        {
            label: 'Bài học đã hoàn thành',
            backgroundColor: '#42A5F5',
            borderColor: '#1E88E5',
            data: [3, 5, 2, 8, 7, 4, 2, 1],
            fill: false,
        }
    ]
}

const options: ChartOptions<'line'> = {
    responsive: true,
    plugins: {
        legend: {
            position: 'top' as const,
        },
        title: {
            display: true,
            // text: 'Tiến độ học tập',
        },
    },
}
</script>

<template>
    <div class="tab-pane fade show active" id="overview">
        <!-- Stats -->
        <div class="stats row mb-5">
            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                {{ $t('hv.page1.level') }}
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                {{ $t('hv.page1.level') }} 1
                            </p>
                        </div>
                        <i class="fas fa-medal fa-2x text-purple"></i>
                    </div>
                    <p class="stat-change text-success mt-2 mb-0 small">
                        <i class="fas fa-arrow-up">
                        </i>
                        10d để lên cấp
                    </p>
                </div>
            </div>
            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                {{ $t('hv.page1.experience') }}
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                10293
                            </p>
                        </div>
                        <i class="fas fa-cube fa-2x text-warning">
                        </i>
                    </div>
                    <p class="stat-change text-success mt-2 mb-0 small">
                        <i class="fas fa-arrow-up">
                        </i>
                        1.3% Up from past week
                    </p>
                </div>
            </div>

            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                {{ $t('hv.page1.time') }}
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                $89,000
                            </p>
                        </div>
                        <i class="fas fa-chart-line fa-2x text-success">
                        </i>
                    </div>
                    <p class="stat-change text-danger mt-2 mb-0 small">
                        <i class="fas fa-arrow-down">
                        </i>
                        4.3% Down from yesterday
                    </p>
                </div>
            </div>
            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                {{ $t('hv.page1.timetoday') }}
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                2040
                            </p>
                        </div>
                        <i class="fas fa-clock fa-2x text-orange">
                        </i>
                    </div>
                    <p class="stat-change text-success mt-2 mb-0 small">
                        <i class="fas fa-arrow-up">
                        </i>
                        1.8% Up from yesterday
                    </p>
                </div>
            </div>
        </div>
        <!-- Chart -->
        <div class="chart bg-white rounded shadow-sm p-4 mt-5">
            <div class="d-flex justify-content-between align-items-center">
                <h2 class="chart-title h6 font-weight-bold">
                    {{ $t('hv.page1.diary') }}
                </h2>
                <div class="form-group mb-0">
                    <select class="form-control bg-light border-0">
                        <option>
                            October
                        </option>
                    </select>
                </div>
            </div>
            <div class="mt-4">
                <Line :data="data" :options="options" />
            </div>
        </div>
    </div>
</template>
