<script setup lang="ts">
import TeacherItem from './TeacherItem.vue';
import { getTeacher } from '@/services';
import { onMounted, ref } from 'vue';
import { Swiper, SwiperSlide } from 'swiper/vue';
import { Navigation } from 'swiper/modules';
import 'swiper/swiper-bundle.css';

const modules = [Navigation];
const teachers = ref<any>([]);
const showteacher = async () => {
    try {
        const res = await getTeacher();
        const resdata = res.data;
        teachers.value = resdata.map((teacher: any) => ({
            id: teacher.id,
            FullName: teacher.fullName,
            image: 'https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg',
        }));
    } catch (error) {
        console.log("Lỗi api giáo viên" + error)
    }
}
onMounted(() => {
    showteacher();
});
</script>

<template>
    <section id="page4" class="section-customer">
        <h1 class="section-title shine-text">
            {{ $t('home.page4.title') }}
        </h1>
        <h4 class="text-center section-subtitle">
            {{ $t('home.page4.description') }}
        </h4>

        <div class="relative swiper-custmer">
            <Swiper :slides-per-view="4" :modules="modules" navigation class="!pb-8">
                <SwiperSlide v-for="(teacher, index) in teachers" :key="index">
                    <TeacherItem :fullname="teacher.FullName" :image="teacher.image" />
                </SwiperSlide>
            </Swiper>
        </div>
    </section>
</template>
<style scoped>
.section-title {
    margin-bottom: 2rem !important;
}

.section-subtitle {
    margin-bottom: 8rem;
}
</style>