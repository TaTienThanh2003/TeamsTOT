<template>
    <div class="trust-customer">
        <div class="title back-blue">
            <div class="title-text">Lịch sử phát triển của chúng tôi</div>
        </div>
        <div class="container">
            <div class="row justify-content-between text-center">
                <!-- 2015 -->
                <div class="col-12 col-md-2 position-relative timeline-block top">
                    <div class="content">
                        <h6 class="fs-5 fw-bold">Thành lập</h6>
                        <p class=" text-muted">Trung tâm chính thức thành lập, bắt đầu hành trình đào tạo Anh ngữ
                            chất
                            lượng.</p>
                        <div class="year bg-success text-white">2015</div>
                        <div class="icon text-success mt-2"><i class="fas fa-rocket fa-2x"></i></div>
                    </div>
                </div>

                <!-- 2016 -->
                <div class="col-12 col-md-2 position-relative timeline-block bottom">
                    <div class="year bg-warning text-dark">2016</div>
                    <div class="content">
                        <div class="icon text-warning"><i class="fas fa-certificate fa-2x"></i></div>
                        <h6 class="fs-5 fw-bold mt-2">Được cấp phép</h6>
                        <p class=" text-muted">Nhận giấy phép hoạt động từ Sở GD&ĐT, triển khai chương trình đầu
                            tiên.
                        </p>
                    </div>
                </div>

                <!-- 2017 -->
                <div class="col-12 col-md-2 position-relative timeline-block top">
                    <div class="year bg-danger text-white">2017</div>
                    <div class="content">
                        <h6 class="fs-5 fw-bold">Đối tác IIG</h6>
                        <p class=" text-muted">Hợp tác cùng IIG Việt Nam, trở thành đơn vị giảng dạy TOEIC uy tín.
                        </p>
                        <div class="icon text-danger mt-2"><i class="fas fa-handshake fa-2x"></i></div>
                    </div>
                </div>

                <!-- 2018 -->
                <div class="col-12 col-md-2 position-relative timeline-block bottom">
                    <div class="year bg-primary text-white">2018</div>
                    <div class="content">
                        <div class="icon text-primary"><i class="fas fa-users fa-2x"></i></div>
                        <h6 class="fs-5 fw-bold mt-2">5000+ học viên</h6>
                        <p class=" text-muted">Hơn 5000 học viên tốt nghiệp, 96% đạt kết quả mong muốn trong 3
                            tháng.
                        </p>
                    </div>
                </div>

                <!-- 2019 -->
                <div class="col-12 col-md-2 position-relative timeline-block top">
                    <div class="year bg-dark text-white">2019</div>
                    <div class="content">
                        <h6 class="fs-5 fw-bold">Chứng nhận Cambridge</h6>
                        <p class=" text-muted">Được Cambridge English chứng nhận là đối tác đạt chuẩn quốc tế.</p>
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
    left: 45%;
    width: 12%;
    height: 24%;
    padding: 1rem 0;
    border-radius: 50%;
    font-size: 1.2rem;
    color: #fff;
    font-weight: 450;
    margin-top: 4rem;
    z-index: 6;

    display: flex;
    align-items: center;
    justify-content: center;
    text-align: center;
    animation: rotate 5s linear infinite;
}

.title-text {
    font-weight: bold;
    padding: 10px;
    transform: rotate(-360deg);
    animation: counter-rotate 5s linear infinite;
}

@keyframes rotate {
    0% {
        transform: rotate(0deg);
    }

    100% {
        transform: rotate(360deg);
    }
}

@keyframes counter-rotate {
    0% {
        transform: rotate(0deg);
    }

    100% {
        transform: rotate(-360deg);
    }
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
    0% {
        padding-right: 2rem;
    }

    50% {
        padding-right: 8rem;
    }

    100% {
        padding-right: 2rem;
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