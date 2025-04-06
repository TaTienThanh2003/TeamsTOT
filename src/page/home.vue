<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import About from '@/components/Home/Sesson/About/About.vue';
import Contact from '@/components/Home/Sesson/Contact/Contact.vue';
import Course from '@/components/Home/Sesson/Courses/Course.vue';
import Detail from '@/components/Home/Sesson/Detail/Detail.vue';
import Introduce from '@/components/Home/Sesson/Intro/Introduce.vue'
import Teacher from '@/components/Home/Sesson/Teachers/Teacher.vue';
</script>

<template>
    <Header />
    <Introduce />
    <About />
    <Course />
    <Teacher />
    <Detail />
    <Contact />
</template>
