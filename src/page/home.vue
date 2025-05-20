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
import { ref } from 'vue';

const showIcon = ref(false);
</script>

<template>
    <div class="position-fixed bottom-0 end-0 p-3">
        <div v-if="showIcon" class="d-flex flex-column">
            <div class="btn icon-btn">
                <i class="fa fa-phone" style="font-size: 30px;"></i>
            </div>

            <div class="btn icon-btn">
                <i class="fa fa-comment" style="font-size: 30px;"></i>
            </div>
        </div>

        <img src="@/assets/images/cu.png" :class="['animate-float', showIcon ? 'active' : '']"
            @click="showIcon = !showIcon" />
    </div>

    <Header :isShow="true" />
    <Intro />
    <Trust />
    <About />
    <Catalog />
    <Course />
    <InTroOff />
    <Gift />
    <Teacher />
    <Detail />
    <Contact />
    <Footer />
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
