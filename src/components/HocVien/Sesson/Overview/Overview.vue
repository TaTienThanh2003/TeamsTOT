<script setup lang="ts">
import { onMounted, ref, computed } from 'vue';
import { useRoute } from 'vue-router';
import { getUserLessons } from '@/services';
import i18n from '@/i18n';
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

const router = useRoute();
const id = parseInt(router.params.id as string);
const user = JSON.parse(localStorage.getItem("user") || "{}");
const userid = user.id;
const points = ref<any>([]);
const score = ref(0);
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
function getLevel(score: number): string | number {
  if (score >= 200) return '10++';
  return Math.floor(score / 20) + 1;
}

// Thêm hàm tính điểm còn lại để lên cấp
function getPointsToNextLevel(score: number): number {
  
  const currentLevel = Math.floor(score / 20) + 1;
  const pointsForNextLevel = currentLevel * 20;
  const pointsNeeded = pointsForNextLevel - score;
  
  return Math.max(0, pointsNeeded);
}

// Thêm hàm tính phần trăm tiến độ
function getProgressPercentage(score: number): number {
  if (score >= 200) return 100;
  
  const currentLevel = Math.floor(score / 20) + 1;
  const levelStartPoints = (currentLevel - 1) * 20;
  const levelEndPoints = currentLevel * 20;
  const levelRange = levelEndPoints - levelStartPoints;
  const progressInLevel = score - levelStartPoints;
  
  return Math.round((progressInLevel / levelRange) * 100);
}

const showpoints = async () => {
  try {
    // Lấy lesson hoàn thành
    const res = await getUserLessons(userid);
    const lessons = res.data || [];
    // Đếm số lesson hoàn thành
    const completedCount = lessons.filter((l: any) => l.isComplete).length;
    score.value = completedCount * 5;
    points.value = [
      {
        score: score.value,
        level: getLevel(score.value),
        pointsToNextLevel: getPointsToNextLevel(score.value),
        progressPercentage: getProgressPercentage(score.value)
      }
    ];
  } catch (error) {
    console.error("Lỗi lấy điểm:", error);
  }
};

onMounted(() => {
    showpoints();
});
</script>

<template>
    <div class="tab-pane fade show active" id="overview">
        <!-- Stats -->
        <div v-for="(point,index) in points" :key="index" class="stats row mb-5">
            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                {{ $t('hv.page1.level') }}
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                {{ $t('hv.page1.level') }} {{ point.level }}
                            </p>
                        </div>
                        <i class="fas fa-medal fa-2x text-purple"></i>
                    </div>
                    <!-- Progress bar -->
                    <div class="progress mb-2" style="height: 8px;">
                        <div class="progress-bar bg-success" 
                             :style="{ width: point.progressPercentage + '%' }"
                             role="progressbar">
                        </div>
                    </div>
                    <p class="stat-change text-success mt-2 mb-0 small">
                        <i class="fas fa-arrow-up"></i>
                        {{ point.pointsToNextLevel }} điểm để lên cấp {{ point.level === '10++' ? '' : Number(point.level) + 1 }}
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
                                {{ point.score }}
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
