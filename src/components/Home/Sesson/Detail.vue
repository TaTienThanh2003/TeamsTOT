<script setup lang="ts">
const user = localStorage.getItem("user");
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
                    <button class="btn back-blue text-white">
                        <template v-if="user">
                            <router-link to="/hocvien">
                                {{ $t('home.page5.btn') }}
                            </router-link>
                        </template>
                        <template v-else>
                            <router-link to="/signin">
                                {{ $t('home.page1.register') }}
                            </router-link>
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
                    <button class="btn back-blue text-white">
                        <template v-if="user">
                            <router-link to="/hocvien">
                                {{ $t('home.page5.btn') }}
                            </router-link>
                        </template>
                        <template v-else>
                            <router-link to="/signin">
                                {{ $t('home.page1.register') }}
                            </router-link>
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
                    <button class="btn back-blue text-white">
                        <template v-if="user">
                            <router-link to="/hocvien">
                                {{ $t('home.page5.btn') }}
                            </router-link>
                        </template>
                        <template v-else>
                            <router-link to="/signin">
                                {{ $t('home.page1.register') }}
                            </router-link>
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
</style>
