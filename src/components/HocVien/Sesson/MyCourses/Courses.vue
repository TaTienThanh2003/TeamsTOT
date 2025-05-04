<script setup lang="ts">
import { onMounted, ref } from 'vue';
import CourseItem from './CourseItem.vue';
import ShowDetail from './ShowDetail.vue';
import { getEnrollments, getLessons } from '@/services';
import i18n from '@/i18n';

const showDetail = ref(false);
const selectedTaskId = ref<number | null>(null);
const enrollments = ref<any>([]);
const sections = ref<any>([]);
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

        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        enrollments.value = resdata.map((enrollment: any) => {
            const today = new Date();
            const endDate = new Date(enrollment.end_date);
            const status = endDate >= today ? "Đang học" : "Đã kết thúc";

            return {
                id: enrollment.courses.id,
                img: enrollment.courses.img,
                name: enrollment.courses[nameKey],
                status: status
            };
        });

    } catch (error) {

    }
}
const showLessons = async (courseid: number) => {
    try {
        const res = await getLessons(courseid);
        const resdata = res.data;

        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        sections.value = resdata.map((section: any) => ({
            title: section[nameKey],
            lessons: section.lessons
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};
onMounted(() => {
    showCourse()
});
</script>

<template>
    <div class="tab-pane fade" id="my-courses">
        <div v-if="!showDetail" class="d-flex">
            <div v-for="(course, index) in enrollments" :key="index">
                <CourseItem :img="course.img" :name="course.name" :status="course.status"
                    @click="() => openTaskDetail(course.id)" />
            </div>
        </div>
        <ShowDetail v-if="showDetail" :sections="sections" @back="backToList" />
    </div>
</template>
