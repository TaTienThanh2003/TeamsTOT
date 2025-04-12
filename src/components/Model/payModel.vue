<script setup lang="ts">
import { ref } from 'vue';
import { defineProps, defineEmits, watch } from 'vue';

const selectedTab = ref('card');

defineProps({
    show: Boolean
});

const emit = defineEmits(['close']);

</script>

<template>
    <div class="container py-5">
        <h1 class="neon-title mb-5">🚀 Đăng ký khóa học TOEIC</h1>


        <!-- Modal thanh toán -->
        <div v-if="show" class="modal-backdrop">
            <div class="payment-modal bg-white rounded shadow p-4">
                <div class="d-flex justify-content-between align-items-center mb-5">
                    <h5 class="fw-bold fs-5">Thanh toán khóa học</h5>
                    <button class="btn-close" @click="emit('close')"></button>
                </div>

                <div class="row h-100">

                    <div class="col-md-5 text-center border-end pe-md-4 mb-4 mb-md-0">
                        <img src="https://img.vietqr.io/image/970422-123456789-compact2.jpg?amount=1200000&addInfo=TOEIC240129XYZ"
                            alt="QR Code" class="qr-img" />
                        <p class="text-muted mt-2 mb-1">Mã đơn hàng: <strong>TOEIC240129XYZ</strong></p>
                        <p class="text-danger fs-5 fw-bold">1.200.000 VNĐ</p>
                        <a href="#" class="text-decoration-underline small">Hướng dẫn thanh toán?</a>
                    </div>

                    <!-- Ngân hàng -->
                    <div class="col-md-7">
                        <ul class="nav nav-tabs mb-3">
                            <li class="nav-item">
                                <a class="nav-link" :class="{ active: selectedTab === 'card' }" href="#"
                                    @click.prevent="selectedTab = 'card'">Thẻ</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" :class="{ active: selectedTab === 'account' }" href="#"
                                    @click.prevent="selectedTab = 'account'">Tài khoản</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" :class="{ active: selectedTab === 'username' }" href="#"
                                    @click.prevent="selectedTab = 'username'">Tên đăng nhập</a>
                            </li>
                        </ul>

                        <form v-if="selectedTab === 'card'">
                            <div class="mb-3">
                                <input type="text" class="form-control" placeholder="Số thẻ" />
                            </div>
                            <div class="mb-3">
                                <input type="text" class="form-control" placeholder="Tên chủ thẻ (không dấu)" />
                            </div>
                            <div class="mb-3">
                                <select class="form-select">
                                    <option>BIDV</option>
                                    <option>Vietcombank</option>
                                    <option>VietinBank</option>
                                </select>
                            </div>
                            <button class="btn btn-primary w-100"><router-link to="/history">XÁC
                                    THỰC</router-link></button>
                        </form>

                        <form v-else-if="selectedTab === 'account'">
                            <div class="mb-3">
                                <input type="text" class="form-control" placeholder="Số tài khoản" />
                            </div>
                            <div class="mb-3">
                                <input type="text" class="form-control" placeholder="Tên chủ tài khoản (không dấu)" />
                            </div>
                            <button class="btn btn-primary w-100">XÁC THỰC</button>
                        </form>

                        <form v-else-if="selectedTab === 'username'">
                            <div class="mb-3">
                                <input type="text" class="form-control" placeholder="Tên đăng nhập" />
                            </div>
                            <div class="mb-3">
                                <input type="password" class="form-control" placeholder="Mật khẩu" />
                            </div>
                            <button class="btn btn-primary w-100">XÁC THỰC</button>
                        </form>

                        <div class="text-center text-muted mt-2 small">Hoặc</div>
                        <button type="button" class="btn btn-light border w-100 mt-2"
                            @click="emit('close')">HỦY</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
body {
    font-family: 'Orbitron', sans-serif;
    background-color: #f9fbfc;
    color: #0f172a;
}

.neon-title {
    color: #0ea5e9;
    font-weight: 600;
    text-align: center;
}

.qr-img {
    width: 100%;
    max-width: 260px;
    height: auto;
    border: 2px dashed #38bdf8;
    padding: 10px;
    border-radius: 12px;
    display: block;
    margin: 0 auto;
}

.modal-backdrop {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    background-color: rgba(0, 0, 0, 0.4);
    z-index: 1050;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 20px;
}

.payment-modal {
    width: 90vw;
    height: 90vh;
    overflow-y: auto;
    background-color: #fff;
    border-radius: 16px;
    padding: 20px;
    display: flex;
    flex-direction: column;
    justify-content: center;
}
</style>
