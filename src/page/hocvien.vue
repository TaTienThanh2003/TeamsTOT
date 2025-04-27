<script setup lang="ts">
import Header from '@/components/HocVien/Header.vue';
import Calender from '@/components/HocVien/Sesson/Calender.vue';
import Comments from '@/components/HocVien/Sesson/Comments/Comments.vue';
import Courses from '@/components/HocVien/Sesson/MyCourses/Courses.vue';
import Teacher from '@/components/HocVien/Sesson/MyTeacher/Teacher.vue';
import Overview from '@/components/HocVien/Sesson/Overview/Overview.vue';
import Tasks from '@/components/HocVien/Sesson/Tasks/Tasks.vue';
import User from '@/components/HocVien/Sesson/User.vue';
import Sidebar from '@/components/HocVien/Sidebar.vue';
import { ref } from 'vue';

const showDetail = ref(true);

const toggleHidden = () => {
    showDetail.value = false;
}
const toggleShow = () => {
    showDetail.value = true;
}
</script>

<template>
    <Header :showDetail="showDetail" />
    <div class="content d-flex">
        <Sidebar :showDetail="showDetail" @setTrue="toggleShow" />
        <div :class="['main-content flex-grow-1 py-5', showDetail ? 'expanded' : 'collapsed']">
            <div class="tab-content px-5">
                <Overview />
                <Courses @setFalse="toggleHidden" @setTrue="toggleShow" />
                <Teacher />
                <Calender />
                <Tasks @setFalse="toggleHidden" @setTrue="toggleShow" />
                <Comments />
                <User />
            </div>
        </div>
    </div>
</template>

<style scoped>
body {
    background-color: #F5F6FA;
}

.main-content {
    transition: margin-left 0.3s ease;
    width: 100%;
    padding: 20px;
    background: #f5f6fa;
    margin-top: 65px;
    height: calc(100vh - 65px);
    overflow-y: auto;
}

.main-content.expanded {
    margin-left: 220px;
}

.main-content.collapsed {
    margin-left: 60px;
}
</style>
