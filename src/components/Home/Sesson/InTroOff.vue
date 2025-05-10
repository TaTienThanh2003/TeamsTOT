<template>
    <div class="section-customer">
        <h2 class="section-title">KHÓA HỌC TRỰC TIẾP</h2>
        <div class="course-list-wrapper">
            <div v-for="(course, index) in upcomingCourses" :key="index" class="course-card back-blue">
                <h3 class="course-title text-warning">{{ course.name }}</h3>
                <p class="course-time text-white">{{ course.time }} · {{ course.schedule }}</p>
                <p class="course-date text-white">
                    <span class="font-medium">Ngày khai giảng:</span>
                    <span class="text-blue-600 font-semibold">
                        {{ course.openingDate }}
                    </span>
                </p>
                <span class="course-status btn btn-warning" data-bs-toggle="modal" data-bs-target="#consultModal">
                    {{ course.status }}
                </span>
            </div>
        </div>
        <div class="mt-4 text-center">
            <RouterLink to="/detail-off" class="fs-5">
                Xem tất cả &rarr;
            </RouterLink>
        </div>
    </div>
    <EnrollModel />
</template>
<script setup lang="ts">
import EnrollModel from '@/components/Model/EnrollModel.vue';

const upcomingCourses = [
    {
        name: 'Nền tảng TOEIC',
        time: '20h15–21h45',
        schedule: 'Thứ 2, 4, 6',
        openingDate: '05/08/2024',
        status: 'Tuyển sinh',
    },
    {
        name: 'TOEIC L&R - 450+',
        time: '18h30–20h00',
        schedule: 'Thứ 3, 5',
        openingDate: '22/08/2024',
        status: 'Tuyển sinh',
    },
    {
        name: 'TOEIC S&W - Cơ bản',
        time: '20h15–21h45',
        schedule: 'Thứ 2, 4',
        openingDate: '07/08/2024',
        status: 'Tuyển sinh',
    },
    {
        name: 'TOEIC L&R - 650+',
        time: '20h15–21h45',
        schedule: 'Thứ 3, 6',
        openingDate: '30/08/2024',
        status: 'Dự kiến',
    },
];
</script>
<style scoped>
.course-list-wrapper {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 1.5rem;
}

.course-card {
    padding: 1rem 1.25rem;
    border-radius: 1rem;
    max-width: 250px;
    width: 100%;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.08);
    text-align: center;
}

.course-title {
    font-weight: 600;
    font-size: 1rem;
    margin-bottom: 0.5rem;
}

.course-time {
    font-size: 0.95rem;
}

.course-date {
    margin-top: 0.5rem;
    font-size: 0.9rem;
}

.course-status {
    display: inline-block;
    margin-top: 0.75rem;
    padding: 0.25rem 0.75rem;
    border-radius: 999px;
    font-size: 0.75rem;
    font-weight: 500;
}
</style>