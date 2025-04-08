<script setup lang="ts">
</script>

<template>
    <section id="page6" class="section-customer">
        <h1 class="section-title">LIÊN HỆ &amp; ĐÁNH GIÁ</h1>

        <div class="row g-4 px-5">
            <div class="col-md-6">
                <div class="mb-3">
                    <h5 class="text-primary fw-bold">Địa chỉ</h5>
                    <p>Trường Sư phạm Kỹ Thuật Nam Định</p>
                </div>
                <div class="mb-3">
                    <h5 class="text-primary fw-bold">Số điện thoại</h5>
                    <p>085 770 3356</p>
                </div>
                <div class="mb-3">
                    <h5 class="text-primary fw-bold">Email</h5>
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
                        <label for="comments" class="form-label">Nhận xét của bạn:</label>
                        <input type="text" id="comments"
                            class="form-control border-0 border-bottom border-dark rounded-0 shadow-none" required>
                    </div>
                    <button class="btn btn-primary rounded-pill px-4 py-2">Gửi</button>
                </form>
            </div>
        </div>
    </section>
</template>
