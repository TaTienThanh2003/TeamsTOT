<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import Footer from '@/components/Home/Footer.vue';
import About from '@/components/Home/Sesson/About/About.vue';
import Contact from '@/components/Home/Sesson/Contact.vue';
import Course from '@/components/Home/Sesson/Courses/Course.vue';
import Detail from '@/components/Home/Sesson/Detail.vue';
import Teacher from '@/components/Home/Sesson/Teachers/Teacher.vue';
import Intro from '@/components/Home/Sesson/Intro.vue';
import Trust from '@/components/Home/Sesson/Trust.vue';
import Gift from '@/components/Home/Sesson/Gift.vue';
import InTroOff from '@/components/Home/Sesson/InTroOff.vue';
</script>

<template>
    <Header :isShow="true" />
    <Intro />
    <Trust />
    <About />
    <Course />
    <InTroOff />
    <Gift />
    <Teacher />
    <Detail />
    <Contact />
    <Footer />
</template>
