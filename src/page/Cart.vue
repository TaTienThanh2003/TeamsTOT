<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import { ref, computed } from 'vue';

const selectedTab = ref('card');
const showModal = ref(false);

// Dữ liệu khóa học không có số lượng
const cartItems = ref([
    {
        name: 'Khóa học TOEIC Cơ bản',
        price: 990000,
        image: 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
        description: 'Dành cho người mới bắt đầu làm quen với TOEIC'
    },
    {
        name: 'Khóa học TOEIC Nâng cao',
        price: 1290000,
        image: 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
        description: 'Tập trung luyện đề và chiến lược làm bài'
    }
]);

const subtotal = computed(() =>
    cartItems.value.reduce((sum, item) => sum + item.price, 0)
);

const remove = (index: number) => {
    cartItems.value.splice(index, 1);
};
</script>

<template>
    <Header />
    <div class="container py-5 mt-5">
        <h1 class="neon-title fs-4 mb-5">Giỏ hàng của bạn</h1>

        <div class="row mt-4">
            <div class="col-md-8">
                <div v-for="(item, index) in cartItems" :key="index"
                    class="d-flex align-items-center mb-4 border-bottom pb-3">
                    <img :src="item.image" class="me-4"
                        style="width: 80px; height: 80px; object-fit: cover; border-radius: 4px;" />
                    <div class="flex-grow-1">
                        <h5 class="mb-1">{{ item.name }}</h5>
                        <small class="text-muted">{{ item.description }}</small>
                    </div>
                    <div class="me-3 fw-bold">{{ item.price.toLocaleString('vi-VN') }}đ</div>
                    <button class="btn btn-outline-danger btn-sm" @click="remove(index)">×</button>
                </div>
            </div>
            <div class="col-md-4">
                <div class="payment p-4 rounded shadow-sm">
                    <h5 class="mb-3 fw-semibold fs-5">Tóm tắt đơn hàng</h5>
                    <p class="d-flex justify-content-between mb-2">
                        <span>Tạm tính</span>
                        <span>{{ subtotal.toLocaleString('vi-VN') }}đ</span>
                    </p>
                    <p class="d-flex justify-content-between mb-2">
                        <span>Mã ưu đãi</span>
                        <span>10%</span>
                    </p>
                    <p class="d-flex justify-content-between fw-bold border-top pt-2">
                        <span>Tổng cộng</span>
                        <span>{{ subtotal.toLocaleString('vi-VN') }}đ</span>
                    </p>
                    <button class="btn btn-warning w-100 mt-3">THANH TOÁN</button>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.neon-title {
    color: #6C63FF;
    font-weight: 600;
    text-transform: uppercase;
    text-align: center;
}

.payment {
    background-color: #6C63FF;
    color: #fff;
}
</style>
