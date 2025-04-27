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

const emit = defineEmits(['setTrue', 'setFalse'])

const onShowDetail = () => {
    emit('setTrue', true)
}

const onHiddenDetail: () => void = () => {
    emit('setFalse', false)
}

const openTaskDetail = async (courseid: number) => {
    onHiddenDetail();
    selectedTaskId.value = courseid;
    showDetail.value = true;
    await showLessons(courseid);
};

const backToList = () => {
    onShowDetail();
    showDetail.value = false;
    selectedTaskId.value = null;
};
const showCourse = async () => {
    try {
        const res = await getEnrollments(userid);
        const resdata = res.data;

        courses.value = resdata.map((course: any) => ({
            id: course.id,
            name: course.name,
        }));
    } catch (error) {

    }
}
const showLessons = async (courseid: number) => {
    try {
        const res = await getLessons(courseid);
        const resdata = res.data;

        lessons.value = resdata.map((lesson: any) => ({
            id: lesson.id,
            title: lesson.title,
            content: lesson.content,
            videoUrl: lesson.video_url,
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
                <CourseItem :name="course.name" @click="() => openTaskDetail(course.id)" />
            </div>
        </div>
        <ShowDetail v-if="showDetail" :lessons="lessons" @back="backToList" />
    </div>
</template>
