<script setup lang="ts">
import { Swiper, SwiperSlide } from 'swiper/vue';
import 'swiper/swiper-bundle.css';
import { Navigation } from 'swiper/modules';
import CourseItem from './CourseItem.vue';
import { getCourses } from '@/services';
import { onMounted, ref } from 'vue';

const modules = [Navigation];
const courses = ref<any>([]);

const showCourse = async () => {
    try {
        const res = await getCourses();
        courses.value = res.map((course: any) => ({
            title: course.name,
            image: course.image || 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
            features: course.description.split('\n')
        }));
    } catch (err: any) {
        console.log("Lỗi api khoa học" + err)
    }
};

onMounted(() => {
    showCourse();
});
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
