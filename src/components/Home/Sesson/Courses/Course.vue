<script setup lang="ts">
import { Swiper, SwiperSlide } from 'swiper/vue';
import 'swiper/swiper-bundle.css';
import { Navigation } from 'swiper/modules';
import CourseItem from './CourseItem.vue';
import { getCourses } from '@/services';
import { onMounted, ref, watch } from 'vue';
import i18n from '@/i18n';

const modules = [Navigation];
const courses = ref<any>([]);

const showCourse = async () => {
    try {
        const res = await getCourses();
        const resdata = res.data;

        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        const desKey = `des${locale}`;
        courses.value = resdata.map((course: any) => ({
            id: course.id,
            title: course[nameKey],
            image: course.img,
            features: course[desKey]?.split('. ') || []
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};

watch(() => i18n.global.locale, () => {
    showCourse();
});

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
                    <CourseItem :id="course.id" :title="course.title" :image="course.image"
                        :features="course.features" />
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
