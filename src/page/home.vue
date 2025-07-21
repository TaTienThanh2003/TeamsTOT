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
import Catalog from '@/components/Home/Sesson/Catalog.vue';
import { onMounted, ref } from 'vue';
import { useLiveChat } from '@/components/useLiveChat';

onMounted(() => {
    useLiveChat();
})
</script>

<template>
    <div>
        <noscript><a href="https://www.livechat.com/chat-with/19214576/" rel="nofollow">Chat with us</a>, powered by <a
                href="https://www.livechat.com/?welcome" rel="noopener nofollow" target="_blank">LiveChat</a></noscript>

        <Header :isShow="true" />

        <Intro />
        <div data-aos="fade-up">
            <Trust />
        </div>
        <div data-aos="fade-up">
            <About />
        </div>
        <div data-aos="fade-up">
            <Catalog />
        </div>
        <div data-aos="zoom-in">
            <Course />
        </div>
        <div data-aos="zoom-in">
            <InTroOff />
        </div>
        <div data-aos="fade-up">
            <Gift />
        </div>
        <div data-aos="fade-up">
            <Teacher />
        </div>
        <div data-aos="flip-left">
            <Detail />
        </div>
        <div data-aos="fade-up">
            <Contact />
        </div>
        <Footer />
    </div>
</template>

<style scoped>
@keyframes floatUpDown {
    0% {
        transform: translateY(0px);
    }

    50% {
        transform: translateY(-10px);
    }

    100% {
        transform: translateY(0px);
    }
}

.position-fixed {
    z-index: 9999;
}


.animate-float {
    animation: floatUpDown 2s ease-in-out infinite;
    cursor: pointer;
    width: 68px;
    height: auto;
}

.animate-float.active {
    animation: none
}

.icon-btn {
    width: 60px;
    height: 60px;
    display: flex;
    justify-content: center;
    align-items: center;

    background-color: #f0f4ff;
    border: none;
    border-radius: 50%;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    transition: all 0.3s ease;
    color: #4b4b6b;
    margin-bottom: 10px;
}

.icon-btn:hover {
    background-color: #dbe6ff;
    transform: scale(1.1);
    color: #2c3e50;
}
</style>
