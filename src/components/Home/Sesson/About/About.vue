<script setup lang="ts">
import AboutItem from './AboutItem.vue';

const reasons = [
    {
        title: 'home.page2.reasons[0].title',
        description: 'home.page2.reasons[0].description'
    },
    {
        title: 'home.page2.reasons[1].title',
        description: 'home.page2.reasons[1].description'
    },
    {
        title: 'home.page2.reasons[2].title',
        description: 'home.page2.reasons[2].description'
    },
    {
        title: 'home.page2.reasons[3].title',
        description: 'home.page2.reasons[3].description'
    }
]
</script>

<template>
    <section id="page2" class="section-customer">
        <h1 class="section-title shine-text">
            {{ $t('home.page2.title') }}
        </h1>
        <div class="row">
            <div class="col-md-7 d-flex align-items-center">
                <div class="row">
                    <AboutItem v-for="(item, idx) in reasons" :key="idx" :index="idx + 1" :title="$t(item.title)"
                        :description="$t(item.description)" />
                </div>
            </div>
            <div class="col-md-5">
                <div class="decorative-wrapper">
                    <img src="@/assets/images/coso3.png" class="decorative-img img3" alt="Layer 3">
                    <img src="@/assets/images/coso2.png" class="decorative-img img2" alt="Layer 2">
                    <img src="@/assets/images/coso1.png" class="decorative-img img1" alt="Layer 1">
                </div>

            </div>
        </div>
    </section>
</template>

<style scoped>
.circle {
    width: 50px;
    height: 50px;
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    color: white;
    font-weight: bold;
    padding: 20px;
    margin: 0 20px 0;
}

.decorative-wrapper {
    position: relative;
    display: inline-block;
    width: 18rem;
    height: 28rem;
    margin-left: 2rem;
}

.decorative-wrapper::before {
    content: "";
    position: absolute;
    top: -0.8rem;
    right: -0.8rem;
    width: calc(100% - 0.2rem);
    height: calc(100% - 0.2rem);
    border-top: 2rem solid #938dfc;
    border-right: 2rem solid #938dfc;
    border-radius: 30px;
    z-index: 1;
}

.decorative-wrapper::after {
    content: "";
    position: absolute;
    top: -1.6rem;
    right: -1.6rem;
    width: calc(100% - 0.4rem);
    height: calc(100% - 0.4rem);
    border-top: 2rem solid #d9d7ff;
    border-right: 2rem solid #d9d7ff;
    border-radius: 30px;
    z-index: 0;
}

.decorative-img {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    border-radius: 30px;
    object-fit: cover;
    opacity: 0;
    transform: translateY(50px);
    transform: translateY(10px);
}

.img1 {
    z-index: 3;
    animation: show1 12s ease-in-out infinite;
}

.img2 {
    z-index: 2;
    animation: show2 12s ease-in-out infinite;
}

.img3 {
    z-index: 1;
    animation: show3 12s ease-in-out infinite;
}

@keyframes show1 {

    0%,
    32% {
        opacity: 1;
        transform: translateY(0);
    }

    33%,
    100% {
        opacity: 0;
        transform: translateY(-10px);
    }
}

@keyframes show2 {

    0%,
    32% {
        opacity: 0;
        transform: translateY(10px);
    }

    33%,
    65% {
        opacity: 1;
        transform: translateY(0);
    }

    66%,
    100% {
        opacity: 0;
        transform: translateY(-10px);
    }
}

@keyframes show3 {

    0%,
    65% {
        opacity: 0;
        transform: translateY(10px);
    }

    66%,
    100% {
        opacity: 1;
        transform: translateY(0);
    }
}
</style>