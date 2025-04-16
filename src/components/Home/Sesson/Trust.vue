<script setup lang="ts"></script>

<template>
    <div class="trust-customer mb-5">
        <div class="title back-blue">
            <div class="title-text">{{$t('home.page7.title')}}</div>
        </div>
        <div class="container">
            <div class="row justify-content-between text-center">
                <!-- 2015 -->
                <div class="col-12 col-md-2 position-relative timeline-block top">
                    <div class="content">
                        <h6 class="fs-5 fw-bold">{{$t('home.page7.milestones[0].title')}}</h6>
                        <p class=" text-muted">{{$t('home.page7.milestones[0].description')}}</p>
                        <div class="year bg-success text-white">2019</div>
                        <div class="icon text-success mt-2"><i class="fas fa-rocket fa-2x"></i></div>
                    </div>
                </div>

                <!-- 2016 -->
                <div class="col-12 col-md-2 position-relative timeline-block bottom">
                    <div class="year bg-warning text-dark">2020</div>
                    <div class="content">
                        <div class="icon text-warning"><i class="fas fa-certificate fa-2x"></i></div>
                        <h6 class="fs-5 fw-bold mt-2">{{$t('home.page7.milestones[1].title')}}</h6>
                        <p class=" text-muted">{{$t('home.page7.milestones[1].description')}}</p>
                    </div>
                </div>

                <!-- 2017 -->
                <div class="col-12 col-md-2 position-relative timeline-block top">
                    <div class="year bg-danger text-white">2021</div>
                    <div class="content">
                        <h6 class="fs-5 fw-bold">{{$t('home.page7.milestones[2].title')}}</h6>
                        <p class=" text-muted">{{$t('home.page7.milestones[2].description')}}</p>
                        <div class="icon text-danger mt-2"><i class="fas fa-handshake fa-2x"></i></div>
                    </div>
                </div>

                <!-- 2018 -->
                <div class="col-12 col-md-2 position-relative timeline-block bottom">
                    <div class="year bg-primary text-white">2024</div>
                    <div class="content">
                        <div class="icon text-primary"><i class="fas fa-users fa-2x"></i></div>
                        <h6 class="fs-5 fw-bold mt-2">{{$t('home.page7.milestones[3].title')}}</h6>
                        <p class=" text-muted">{{$t('home.page7.milestones[3].description')}}</p>
                    </div>
                </div>

                <!-- 2019 -->
                <div class="col-12 col-md-2 position-relative timeline-block top">
                    <div class="year bg-dark text-white">2025</div>
                    <div class="content">
                        <h6 class="fs-5 fw-bold">{{$t('home.page7.milestones[4].title')}}</h6>
                        <p class=" text-muted">{{$t('home.page7.milestones[4].description')}}</p>
                        <div class="icon text-dark mt-2"><i class="fas fa-award fa-2x"></i></div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>
<style scoped>
.trust-customer {
    background-image: url('@/assets/images/back12.png');
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    width: 100%;
    height: 100%;
    border-radius: 12px;
    position: relative;
}
.title {
    position: absolute;
    bottom: -4%;
    left: 50%;
    transform: translateX(-50%);
    width: 160px;
    height: 160px;
    padding: 1rem;
    border-radius: 50%;
box-shadow: 0 0 20px rgba(123, 97, 255, 0.4);
border: 3px solid #fff;
    background: linear-gradient(135deg, #7B61FF, #6246EA);
    font-size: 1.1rem;
    color: #ffffff;
    font-weight: 600;
    z-index: 6;

    display: flex;
    align-items: center;
    justify-content: center;
    text-align: center;
    

    transition: transform 0.3s ease;
    animation: pulse 3s ease-in-out infinite;
}

.title:hover {
    transform: translateX(-50%) scale(1.05);
    box-shadow: 0 12px 24px rgba(98, 70, 234, 0.4);
}

@keyframes pulse {
    0%, 100% {
        transform: translateX(-50%) scale(1);
    }
    50% {
        transform: translateX(-50%) scale(1.05);
    }
}

.title-text {
    font-weight: bold;
    padding: 10px;
}

.container {
    padding-top: 14rem;
    padding-bottom: 4rem;
    position: relative;
    max-width: 900px;
}

.timeline-block .year {
    padding: 10px 4rem;
    margin-left: -4.8rem;
    clip-path: polygon(0 0, 85% 0, 100% 50%, 85% 100%, 0 100%);
    border-radius: 4px;
    font-weight: bold;
    display: inline-block;
    position: absolute;
    top: 24%;
    z-index: 3;
    display: inline-block;
    animation: expandAndShrink 4s infinite;
}

@keyframes expandAndShrink {
    0%, 100% {
        padding-right: 2rem;
    }

    50% {
        padding-right: 8rem;
    }
}

.bg-success {
    margin-left: 3.2rem !important;
}

.timeline-block .content {
    margin-top: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
}

.timeline-block .content p {
    width: 150%;
}

.timeline-block.bottom .content {
    margin-top: 8rem;
}

.timeline-block.top .content {
    margin-top: -120px;
}

.timeline-block .icon {
    background-color: #dbdadd;
    border-radius: 50%;
    padding: 10px;
    display: inline-block;
}
</style>