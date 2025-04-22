<script setup lang="ts">
import { onMounted, ref } from 'vue';
import CourseItem from './CourseItem.vue';
import ShowDetail from './ShowDetail.vue';
import { getEnrollments, getLessons } from '@/services';

const showDetail = ref(false);
const selectedTaskId = ref<number | null>(null);
const courses = ref<any>([]);
const lessons = ref<any>([]);
const user = JSON.parse(localStorage.getItem("user") || "{}");
const userid = user.id;

const openTaskDetail = async (courseid: number) => {
    selectedTaskId.value = courseid;
    showDetail.value = true;
    await showLessons(courseid);
};

// Quay lại danh sách
const backToList = () => {
    showDetail.value = false;
    selectedTaskId.value = null;
};
const showCourse = async () => {
    try {
        const res = await getEnrollments(userid);
        const resdata = res.data;
        console.log(resdata);
        courses.value = resdata.map((course: any) => ({
            id: course.id,
            name: course.name,
        }));
    } catch (error) {

    }
}
const showLessons = async (courseid:number) => {
    try {
        const res = await getLessons(courseid);
        const resdata = res.data;
        console.log(resdata);
        lessons.value = resdata.map((lesson: any) => ({
            id: lesson.id,
            title: lesson.title,
            content: lesson.content,
            video_url: 'https://www.youtube.com/embed/md3HfH0SWOI',
            completed: false,
            current: false,
        }));
    } catch (error) {

    }
}
onMounted(() => {
    showCourse()
});
</script>

<template>
    <div class="tab-pane fade" id="my-courses">
        <div v-if="!showDetail" class="d-flex">
            <div v-for="(course, index) in courses" :key="index">
                <CourseItem :name="course.name"  @click="() => openTaskDetail(course.id)" />
            </div>
        </div>
        <ShowDetail v-if="showDetail" :lessons="lessons" @back="backToList" />
    </div>
</template>
