<template>
    <section id="page1" class="section-customer back-blue">
        <div class="d-flex flex-column flex-md-row align-items-center justify-content-center text-white">
            <div class="w-100 w-md-50 p-4 text-center">
                <Search />
                <h1 class="fs-2 fw-bold mt-5">
                    {{ $t('home.page1.title') }}
                </h1>
                <p class="fs-5 mt-3">
                    {{ $t('home.page1.title2') }}
                </p>
                <template v-if="user">
                    <router-link class="my-5 btn btn-warning text-dark fw-bold py-3 px-5 rounded-pill fs-5"
                        to="/hocvien">
                        Bắt đầu ngay!
                    </router-link>
                </template>
                <template v-else>
                    <router-link class="my-5 btn btn-warning text-dark fw-bold py-3 px-5 rounded-pill fs-5"
                        to="/signin">
                        {{ $t('home.page1.register') }}
                    </router-link>
                </template>
            </div>
            <div class="w-100 w-md-50 p-4">
                <DotLottieVue style="height: 500px; width: 500px" autoplay loop
                    src="https://lottie.host/c737534b-c300-4560-aed5-18ba418c75f8/naORkESB7T.lottie" />
            </div>
        </div>
        <div class="wave-bottom">
            <svg viewBox="0 0 1440 120" preserveAspectRatio="none">
                <path d="M0,60 
           C120,0 240,120 360,60 
           C480,0 600,120 720,60 
           C840,0 960,120 1080,60 
           C1200,0 1320,120 1440,60 
           L1440,120 L0,120 Z" fill="#ffffff" />
            </svg>
        </div>
    </section>
</template>

<script setup lang="ts">
import { DotLottieVue } from '@lottiefiles/dotlottie-vue'
import Search from './Search.vue';
const user = localStorage.getItem("user");
</script>


<style scoped>
#page1 {
    position: relative;
    /* background: linear-gradient(to bottom, #6C63FF, #d2d0ff); */
    z-index: 1;
    overflow: hidden;
}

#page1::before {
    content: "";
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-image: url('@/assets/images/back_nen.png');
    background-size: cover;
    background-repeat: no-repeat;
    background-position: center -10px;
    opacity: 1;
    z-index: -1;
}


#page1 h1 {
    font-size: 2.5rem;
}

.section-customer {
    position: relative;
}

.wave-bottom {
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    overflow: hidden;
    line-height: 0;
}

.wave-bottom svg {
    display: block;
    width: 100%;
    height: 100px;
}


#page1 p {
    font-size: 1.25rem;
}

button {
    font-size: 1.2rem;
}

input.form-control {
    background-color: #f4f4f4;
}
</style>