<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()
const user = localStorage.getItem("user");

const handleClick = () => {
  if (user) {
    router.push('/hocvien')
  } else {
    router.push('/signin')
  }
}
</script>

<template>
    <section class="bg-light py-5">
        <div class="container text-center mb-5">
            <h2 class="fs-2 px-5 font-blue">
                {{ $t('home.page5.title') }}
            </h2>
        </div>
        <div class="container mb-5" data-aos="fade-left">
            <div class="row align-items-center bg-white rounded shadow p-4">
                <div class="col-md-6">
                    <img src="@/assets/images/intro1.png" alt="Skills" class="img-fluid rounded" />
                </div>
                <div class="col-md-6">
                    <h3 class="fs-5 fw-bold text-dark">{{ $t('home.page5.points.0.title') }}</h3>
                    <p class="my-3">
                        {{ $t('home.page5.points.0.description') }}
                    </p>
                    <button class="btn back-blue text-white" @click="handleClick">
                        <template v-if="user">
                            {{ $t('home.page5.btn') }}
                        </template>
                        <template v-else>
                            {{ $t('home.page1.register') }}
                        </template>
                    </button>
                </div>
            </div>
        </div>
        <div class="container mb-5" data-aos="fade-right">
            <div class="row align-items-center bg-white rounded shadow p-4 flex-md-row-reverse">
                <div class="col-md-6">
                    <img src="@/assets/images/intro2.png" alt="Test Your Level" class="img-fluid rounded" />
                </div>
                <div class="col-md-6">
                    <h3 class="fs-5 fw-bold text-dark">{{ $t('home.page5.points.1.title') }}</h3>
                    <p class="my-3">
                        {{ $t('home.page5.points.1.description') }}
                    </p>
                    <button class="btn back-blue text-white" @click="handleClick">
                        <template v-if="user">
                            {{ $t('home.page5.btn') }}
                        </template>
                        <template v-else>
                            {{ $t('home.page1.register') }}
                        </template>
                    </button>
                </div>
            </div>
        </div>
        <div class="container mb-5" data-aos="fade-left">
            <div class="row align-items-center bg-white rounded shadow p-4">
                <div class="col-md-6">
                    <img src="@/assets/images/intro3.png" alt="Vocabulary" class="img-fluid rounded" />
                </div>
                <div class="col-md-6">
                    <h3 class="fs-5 fw-bold text-dark">{{ $t('home.page5.points.2.title') }}</h3>
                    <p class="my-3">
                        {{ $t('home.page5.points.2.description') }}
                    </p>
                    <button class="btn back-blue text-white" @click="handleClick">
                        <template v-if="user">
                            {{ $t('home.page5.btn') }}
                        </template>
                        <template v-else>
                            {{ $t('home.page1.register') }}
                        </template>
                    </button>
                </div>
            </div>
        </div>
    </section>
</template>

<style scoped>
.img-fluid {
    width: 400px;
    height: 300px;
    object-fit: cover;
}

.btn.back-blue {
    background-color: #6C63FF !important;
    border-color: #6C63FF !important;
    color: white !important;
    font-weight: 500;
    transition: all 0.3s ease;
}

.btn.back-blue:hover {
    background-color: #5a52d5 !important;
    border-color: #5a52d5 !important;
    color: white !important;
    transform: translateY(-2px);
    box-shadow: 0 4px 8px rgba(108, 99, 255, 0.3);
}

.btn.back-blue:focus {
    background-color: #6C63FF !important;
    border-color: #6C63FF !important;
    color: white !important;
    box-shadow: 0 0 0 0.2rem rgba(108, 99, 255, 0.25);
}

.btn.back-blue:active {
    background-color: #5a52d5 !important;
    border-color: #5a52d5 !important;
    color: white !important;
}
</style>
