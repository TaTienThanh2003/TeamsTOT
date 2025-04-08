<script setup lang="ts">
</script>

<template>
    <section id="page5" class="section-customer back-blue">
        <div class="row align-items-center">
            <div class="col-md-6 d-flex align-items-center justify-content-center">
                <h1 class="display-6 fw-bold text-warning">
                    {{ $t('home.page5.title') }}
                </h1>
            </div>

            <div class="col-md-6">
                <div class="row g-4 text-white">
                    <!-- Box 1 -->
                    <div class="col-6 d-flex flex-column align-items-center text-center">
                        <i class="fas fa-user-graduate fa-3x text-warning mb-3"></i>
                        <h2 class="h3 fw-semibold mb-3">{{ $t('home.page5.points[0].title') }}</h2>
                        <p>
                            {{ $t('home.page5.points[0].description') }}
                        </p>
                    </div>

                    <!-- Box 2 -->
                    <div class="col-6"></div>

                    <!-- Box 3 -->
                    <div class="col-6"></div>

                    <!-- Box 4 -->
                    <div class="col-6 d-flex flex-column align-items-center text-center">
                        <i class="fas fa-tools fa-3x text-warning mb-3"></i>
                        <h2 class="h3 fw-semibold mb-3">{{ $t('home.page5.points[1].title') }}</h2>
                        <p>
                            {{ $t('home.page5.points[1].description') }}
                        </p>
                    </div>

                    <!-- Box 5 -->
                    <div class="col-6 d-flex flex-column align-items-center text-center">
                        <i class="fas fa-user-check fa-3x text-warning mb-3"></i>
                        <h2 class="h3 fw-semibold mb-3">{{ $t('home.page5.points[2].title') }}</h2>
                        <p>
                            {{ $t('home.page5.points[2].description') }}
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>
