<script setup lang="ts">
import { ref } from 'vue';
import { defineProps, defineEmits, computed } from 'vue';
import Countdown from '@chenfengyuan/vue-countdown';

const props = defineProps<{
    show: boolean;
    amount: number;
}>();
const bankId = 'vietinbank';
const accountNumber = '104872505962';
const template = 'compact2';
const accountName = 'Nguyễn Đức Anh Tuấn';
const emit = defineEmits(['close']);
const qrUrl = computed(() => {
    const baseUrl = 'https://img.vietqr.io/image';
    const formattedAccountName = encodeURIComponent(accountName);

    return `${baseUrl}/${bankId}-${accountNumber}-${template}.jpg?amount=${props.amount}&addInfo='TOT2025'&accountName=${formattedAccountName}`;
});
const onCountdownEnd = () => {
    emit('close');
};
</script>

<template>
    <div class="container py-5">
        <h1 class="neon-title mb-5">🚀 Đăng ký khóa học TOEIC</h1>

        <div v-if="show" class="modal-backdrop">
            <div class="qr-box text-white text-center rounded-4 p-5">
                <img :src="qrUrl" alt="QR Code" class="qr-img mb-3 img-fluid" style="max-width: 280px;" />
                <p class="text-warning fw-semibold">Mã QR thanh toán tự động</p>
                <p class="small text-warning fst-italic">(Xác nhận tự động - Thường không quá 3’)</p>

                <!-- <div class="mt-3 text-start ms-4">
                    <p><strong>Số tiền:</strong> <span class="text-white">2.000.000đ</span></p>
                    <p><strong>Nội dung (bắt buộc):</strong> <span class="text-warning">TIME10064</span></p>
                    <p><strong>Người thụ hưởng:</strong> HUỲNH TRỌNG PHÚC</p>
                </div> -->

                <div class="text-warning mt-4 small">Đang chờ thanh toán</div>
                <Countdown :time="600000" @end="onCountdownEnd" v-slot="slotProps">
                    <div class="text-white fw-bold mt-1">
                        {{ String((slotProps as any).minutes).padStart(2, '0') }}:{{ String((slotProps as
                            any).seconds).padStart(2, '0') }}
                    </div>
                </Countdown>


                <button class="btn btn-outline-light mt-4 w-100" @click="emit('close')">HỦY THANH TOÁN</button>
            </div>
        </div>
    </div>
</template>

<style scoped>
.neon-title {
    color: #0ea5e9;
    font-weight: 600;
    text-align: center;
}

.modal-backdrop {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    background-color: rgba(0, 0, 0, 0.6);
    z-index: 1050;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 20px;
}

.qr-box {
    background: #544ec7;
    max-width: 360px;
    width: 100%;
    border: 1px solid #544ec7;
    box-shadow: 0 0 15px rgba(255, 255, 255, 0.05);
}

.qr-img {
    width: 100%;
    max-width: 240px;
    height: auto;
    border-radius: 12px;
    margin: 0 auto;
    display: block;
}
</style>
