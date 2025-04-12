<script setup lang="ts">
import { Swiper, SwiperSlide } from 'swiper/vue';
import 'swiper/swiper-bundle.css';
import { Navigation } from 'swiper/modules';
import CourseItem from './CourseItem.vue';

const modules = [Navigation];
// Danh sách khóa học
const courses = [
    {
        title: 'Khóa học Giao tiếp thực tế',
        image: 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
        features: [
            'Dành cho người mất gốc hoặc muốn cải thiện phản xạ nói.',
            'Phương pháp phản xạ tự nhiên, thực hành ngay tại lớp.',
            'Tự tin giao tiếp trong công việc và cuộc sống.'
        ]
    },
    {
        title: 'Khóa học Giao tiếp thực tế',
        image: 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
        features: [
            'Dành cho người mất gốc hoặc muốn cải thiện phản xạ nói.',
            'Phương pháp phản xạ tự nhiên, thực hành ngay tại lớp.',
            'Tự tin giao tiếp trong công việc và cuộc sống.'
        ]
    },
    {
        title: 'Khóa học Giao tiếp nâng cao',
        image: 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
        features: [
            'Nâng cao phản xạ và kỹ năng thuyết trình.',
            'Tình huống mô phỏng thực tế.',
            'Phù hợp với người đã có nền tảng cơ bản.'
        ]
    },
    {
        title: 'Khóa học Phát âm chuẩn',
        image: 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
        features: [
            'Chỉnh sửa phát âm từng âm cơ bản.',
            'Ứng dụng IPA để luyện phát âm.',
            'Giảng viên chỉnh sửa trực tiếp từng học viên.'
        ]
    }
];
</script>

<template>
    <section id="page3" class="section-customer">
        <h1 class="section-title">
            {{ $t('home.page3.title') }}
        </h1>

        <div class="relative swiper-custmer">
            <Swiper :slides-per-view="3" :modules="modules" navigation class="!pb-8">
                <SwiperSlide v-for="(course, index) in courses" :key="index">
                    <CourseItem :title="course.title" :image="course.image" :features="course.features" />
                </SwiperSlide>
            </Swiper>
        </div>
    </section>
</template>


<style scoped>
.swiper-custmer {
    padding: 0 5rem;
    margin-top: -1rem;
}

.swiper {
    position: unset;
}

:deep(.swiper-button-prev) {
    left: 2rem !important;
}

:deep(.swiper-button-next) {
    right: 4rem !important;
}
</style>
