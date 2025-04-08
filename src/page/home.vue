<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import About from '@/components/Home/Sesson/About/About.vue';
import Contact from '@/components/Home/Sesson/Contact.vue';
import Course from '@/components/Home/Sesson/Courses/Course.vue';
import Detail from '@/components/Home/Sesson/Detail.vue';
import Teacher from '@/components/Home/Sesson/Teachers/Teacher.vue';
import Intro from '@/components/Home/Sesson/Intro.vue';
</script>

<template>
    <Header />
    <Intro />
    <About />
    <Course />
    <Teacher />
    <Detail />
    <Contact />
</template>
