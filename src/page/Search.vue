<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import CourseItem from '@/components/Home/Sesson/Courses/CourseItem.vue';
import { getCourses, getCourseByName } from '@/services';
import { onMounted, ref } from 'vue';

import { useRoute } from 'vue-router';

const route = useRoute();
const courses = ref<any>([]);
const courseName = ref(route.params.courseName || '');
const showCourse = async () => {
    try {
        const res = await getCourses();
        const resdata = res.data;
        courses.value = resdata.map((course: any) => ({
            id: course.id,
            title: course.name,
            image: course.image || 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
            features: course.description.split('\n')
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};
const showCourseByName = async (name: string) => {
    try {
        const res = await getCourseByName(name);
        const resdata = res.data;
        courses.value = resdata.map((course: any) => ({
            id: course.id,
            title: course.name,
            image: course.image || 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
            features: course.description.split('\n')
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};
const handleEnter = () => {
    const name = typeof courseName.value === 'string' ? courseName.value.trim() : '';
    console.log(name);
    if (name) {
        showCourseByName(name);
    } else {
        showCourse();
    }
};
onMounted(() => {
    handleEnter();
});
</script>

<template>
    <Header />
    <div class="back-blue search-font">
        <h1 class="mt-5 fs-2 text-white text-center">HÃY LỰA CHỌN CHÚNG TÔI</h1>
        <div class="position-relative my-4">
            <input v-model="courseName" @keydown.enter="handleEnter"
                class="form-control form-control-lg p-3 pe-5 rounded-pill" :placeholder="$t('home.entersearch')"
                type="text" />
            <i class="fas fa-search search-icon"></i>
        </div>
    </div>
    <h1 class="fs-3 text-title">Danh sách khóa học</h1>
    <div class="courses-list">
        <div class="course-item-wrapper" v-for="(course, index) in courses" :key="index">
            <CourseItem :id="course.id" :title="course.title" :image="course.image" :features="course.features" />
        </div>
    </div>
    <h1 class="fs-3 text-title">Danh sách giảng vien</h1>
    <div class="courses-list">
        <div class="course-item-wrapper" v-for="(course, index) in courses" :key="index">
            <CourseItem :id="course.id" :title="course.title" :image="course.image" :features="course.features" />
        </div>
    </div>
</template>

<style scoped>
.search-font {
    padding: 4rem 16rem;
}

.search-icon {
    position: absolute;
    top: 50%;
    right: 6rem;
    transform: translateY(-50%);
    color: #a3a3a3;
    font-size: 1.5rem;
    padding-right: 1rem;
    pointer-events: none;
    z-index: 10;
}

.btn-group {
    position: absolute;
    top: -10px;
}

.text-title {
    padding: 2rem 10rem;
}

.courses-list {
    display: flex;
    flex-wrap: wrap;
    gap: 20px;
    padding: 0 10rem;
}

.course-item-wrapper {
    flex: 1 1 calc(33.33% - 20px);
    box-sizing: border-box;
}
</style>