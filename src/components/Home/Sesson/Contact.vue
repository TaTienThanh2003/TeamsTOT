<script setup lang="ts">
</script>

<template>
    <section id="page6" class="section-customer">
        <h1 class="section-title">{{ $t('home.page6.title') }}</h1>

        <div class="row g-4 px-5">
            <div class="col-md-6">
                <div class="mb-3">
                    <h5 class="font-blue fw-bold">{{ $t('home.page6.address') }}</h5>
                    <p>Trường Sư phạm Kỹ Thuật Nam Định</p>
                </div>
                <div class="mb-3">
                    <h5 class="font-blue fw-bold">{{ $t('home.page6.phone') }}</h5>
                    <p>085 770 3356</p>
                </div>
                <div class="mb-3">
                    <h5 class="font-blue fw-bold">Email</h5>
                    <p>oanhta20032003@gmail.com</p>
                </div>
            </div>

            <!-- Cột phải: Form đánh giá -->
            <div class="col-md-6">
                <form>
                    <div class="mb-3">
                        <label for="email" class="form-label">Email</label>
                        <input type="email" id="email"
                            class="form-control border-0 border-bottom border-dark rounded-0 shadow-none" required>
                    </div>
                    <div class="mb-3">
                        <label for="comments" class="form-label">{{ $t('home.page6.feedback') }}</label>
                        <input type="text" id="comments"
                            class="form-control border-0 border-bottom border-dark rounded-0 shadow-none" required>
                    </div>
                    <button class="btn back-blue text-white rounded-pill px-4 py-2">Gửi</button>
                </form>
            </div>
        </div>
    </section>
</template>
