<template>
    <section id="page1" class="section-customer back-blue">
        <div class="d-flex flex-column flex-md-row align-items-center justify-content-center text-white">
            <div class="w-100 w-md-50 p-4 text-center">
                <div class="position-relative">
                    <input class="form-control form-control-lg p-3 pe-5 rounded-pill" :placeholder="$t('home.search')"
                        type="text" />
                    <i class="fas fa-search position-absolute top-50 end-0 translate-middle-y text-primary fs-4 pe-3"
                        style="pointer-events: none;"></i>
                </div>
                <h1 class="fs-2 fw-bold mt-5">
                    {{ $t('home.page1.title') }}
                </h1>
                <p class="fs-5 mt-3">
                    {{ $t('home.page1.title2') }}
                </p>
                <router-link class="my-5 btn btn-warning text-dark fw-bold py-3 px-5 rounded-pill fs-5" to="/signin">
                    {{ $t('home.page1.register') }}
                </router-link>
            </div>
            <div class="w-100 w-md-50 p-4">
                <DotLottieVue style="height: 500px; width: 500px" autoplay loop
                    src="https://lottie.host/c737534b-c300-4560-aed5-18ba418c75f8/naORkESB7T.lottie" />
            </div>
        </div>
    </section>
</template>

<script lang="ts">
import { DotLottieVue } from '@lottiefiles/dotlottie-vue'

export default {
    name: 'Intro',
    components: {
        DotLottieVue
    }
}
</script>


<style scoped>
#page1 {
    padding: 9.8rem 4rem 3.8rem;
}

#page1 h1 {
    font-size: 2.5rem;
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