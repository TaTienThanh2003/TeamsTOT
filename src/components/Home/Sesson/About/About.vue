<script setup lang="ts">
</script>

<template>
    <section id="page2" class="section-customer">
        <h1 class="section-title">
            {{ $t('home.page2.title') }}
        </h1>
        <div class="row">
            <div class="col-md-7 d-flex align-items-center">
                <div class="row">
                    <div class="col-md-6 d-flex align-items-start">
                        <div
                            class="circle bg-primary text-white d-flex justify-content-center align-items-center rounded-circle">
                            01
                        </div>
                        <div class="ml-3">
                            <h2 class="h5 font-weight-bold text-primary mb-2">{{ $t('home.page2.reasons[0].title') }}</h2>
                            <p>{{ $t('home.page2.reasons[0].description') }}</p>
                        </div>
                    </div>
                    <div class="col-md-6 d-flex align-items-start mb-4">
                        <div
                            class="circle bg-primary text-white d-flex justify-content-center align-items-center rounded-circle">
                            02
                        </div>
                        <div class="ml-3">
                            <h2 class="h5 font-weight-bold text-primary mb-2">{{ $t('home.page2.reasons[1].title') }}</h2>
                            <p>{{ $t('home.page2.reasons[1].description') }}</p>
                        </div>
                    </div>
                    <div class="col-md-6 d-flex align-items-start mb-4">
                        <div
                            class="circle bg-primary text-white d-flex justify-content-center align-items-center rounded-circle">
                            03
                        </div>
                        <div class="ml-3">
                            <h2 class="h5 font-weight-bold text-primary mb-2">{{ $t('home.page2.reasons[2].title') }}</h2>
                            <p>{{ $t('home.page2.reasons[2].description') }}</p>
                        </div>
                    </div>
                    <div class="col-md-6 d-flex align-items-start mb-4">
                        <div
                            class="circle bg-primary text-white d-flex justify-content-center align-items-center rounded-circle">
                            04
                        </div>
                        <div class="ml-3">
                            <h2 class="h5 font-weight-bold text-primary mb-2">{{ $t('home.page2.reasons[3].title') }}</h2>
                            <p>{{ $t('home.page2.reasons[3].description') }}</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-5">
                <img src="@/assets/images/vatc.jpg" class="decorative-img" alt="Decorative Image">
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

.decorative-img {
    height: 30rem;
    border-radius: 30px 0 30px 0;
    overflow: hidden;
    border: 5px;
}
</style>
