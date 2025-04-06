<script setup lang="ts">
import Header from '@/components/HocVien/Header.vue';
import Calender from '@/components/HocVien/Sesson/Calender.vue';
import Comments from '@/components/HocVien/Sesson/Comments/Comments.vue';
import Gift from '@/components/HocVien/Sesson/Gift.vue';
import Courses from '@/components/HocVien/Sesson/MyCourses/Courses.vue';
import Teacher from '@/components/HocVien/Sesson/MyTeacher/Teacher.vue';
import Notes from '@/components/HocVien/Sesson/Notes/Notes.vue';
import Overview from '@/components/HocVien/Sesson/Overview/Overview.vue';
import Tasks from '@/components/HocVien/Sesson/Tasks/Tasks.vue';
import User from '@/components/HocVien/Sesson/User.vue';
import Sidebar from '@/components/HocVien/Sidebar.vue';

</script>

<template>
    <Header />
    <div class="content row">
        <div class="sidebar col-3">
            <Sidebar />
        </div>
        <div class="main-content col-9 pt-5">
            <div class="tab-content px-5">
                <Overview />
                <Courses />
                <Teacher />
                <Calender />
                <Tasks />
                <Notes />
                <Gift />
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
</style>