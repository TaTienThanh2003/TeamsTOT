<script setup lang="ts">
import TeacherItem from '@/components/Home/Sesson/Teachers/TeacherItem.vue';
import Header from '@/components/Home/Header.vue';
import CourseItem from '@/components/Home/Sesson/Courses/CourseItem.vue';
import { getCourses, getCourseByName } from '@/services';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import { getTeacher } from '@/services';
import i18n from '@/i18n';

const route = useRoute();
const courses = ref<any>([]);
const teachers = ref<any>([]);
const courseName = ref(route.params.courseName || '');

const showCourse = async () => {
    try {
        const res = await getCourses();
        const resdata = res.data;
        
        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        const desKey = `des${locale}`;
        
        courses.value = resdata.map((course: any) => ({
            id: course.id,
            title: course[nameKey] || course.titleVI || course.titleEN || '',
            image: course.img || 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
            features: (course[desKey] || course.desVI || course.desEN || '')?.split('. ') || []
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};

const showCourseByName = async (name: string) => {
    try {
        const res = await getCourseByName(name);
        const resdata = res.data;
        
        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        const desKey = `des${locale}`;
        
        courses.value = resdata.map((course: any) => ({
            id: course.id,
            title: course[nameKey] || course.titleVI || course.titleEN || '',
            image: course.img || 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
            features: (course[desKey] || course.desVI || course.desEN || '')?.split('. ') || []
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};

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

const handleEnter = () => {
    const name = typeof courseName.value === 'string' ? courseName.value.trim() : '';
    console.log(name);
    if (name) {
        showCourseByName(name);
    } else {
        showCourse();
        showteacher();
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
                class="form-control form-control-lg p-3 rounded-pill" :placeholder="$t('home.entersearch')"
                type="text" style="padding-right: 5rem;" />
            <button 
                @click="handleEnter"
                class="btn position-absolute end-0 top-50 translate-middle-y me-3"
                style="z-index: 10; background-color: white; border-color: #dee2e6; color: #6C63FF;"
            >
                <i class="fas fa-search"></i>
            </button>
        </div>
    </div>
    <h1 class="fs-3 text-title">Danh sách khóa học</h1>
    <div class="courses-list">
        <div class="course-item-wrapper" v-for="(course, index) in courses" :key="index">
            <CourseItem :id="course.id" :title="course.title" :image="course.image" :features="course.features" />
        </div>
    </div>
    <h1 class="fs-3 text-title">Danh sách giảng viên</h1>
    <div class="teachers-list">
        <div class="teacher-item-wrapper" v-for="(teacher, index) in teachers" :key="index">
            <TeacherItem :fullname="teacher.FullName" :image="teacher.image"/>
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
    max-height: 600px;
    overflow-y: auto;
}

.course-item-wrapper {
    flex: 1 1 calc(33.33% - 20px);
    box-sizing: border-box;
}

.teachers-list {
    display: flex;
    flex-wrap: wrap;
    gap: 20px;
    padding: 0 10rem;
    max-height: 400px;
    overflow-y: auto;
}

.teacher-item-wrapper {
    flex: 1 1 calc(25% - 20px);
    box-sizing: border-box;
}

/* Custom scrollbar for lists */
.courses-list::-webkit-scrollbar,
.teachers-list::-webkit-scrollbar {
    width: 8px;
}

.courses-list::-webkit-scrollbar-track,
.teachers-list::-webkit-scrollbar-track {
    background: #f1f1f1;
    border-radius: 4px;
}

.courses-list::-webkit-scrollbar-thumb,
.teachers-list::-webkit-scrollbar-thumb {
    background: #6C63FF;
    border-radius: 4px;
}

.courses-list::-webkit-scrollbar-thumb:hover,
.teachers-list::-webkit-scrollbar-thumb:hover {
    background: #5a52d5;
}
</style>