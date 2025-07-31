<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import PayModel from '@/components/Model/payModel.vue';
import { getCourserbyUserId, deletecarts } from '@/services';
import { ref, computed, onMounted, watch } from 'vue';
import i18n from '@/i18n';
import { useToast } from '@/composables/useToast';
import ToastContainer from '@/components/Toast/ToastContainer.vue';

const { success, error } = useToast();

const selectedTab = ref('card');
const showModal = ref(false);
const Carts = ref<any[]>([]);
const user = JSON.parse(localStorage.getItem("user") || "{}");
const userId = user.id;

const showCarts = async () => {
    try {
        const res = await getCourserbyUserId(userId);
        const resdata = res.data;
        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        const desKey = `des${locale}`;

        Carts.value = resdata.map((Cart: any) => ({
            id: Cart.id,
            name: Cart[nameKey],
            description: Cart[desKey],
            img: Cart.img || 'https://via.placeholder.com/80',
            price: Number(Cart.price.toString().replace(/[^\d]/g, ''))
        }));
    } catch (err: any) {
        console.error("Lỗi api khóa học:", err);
    }
};

const count = computed(() => Carts.value.length);

const subtotal = computed(() => {
    return Carts.value.reduce((sum, item) => sum + item.price, 0);
});

const remove = async (CourseId: number) => {
    try {
        await deletecarts(CourseId, userId);
        success('Xóa khỏi giỏ hàng thành công!');
        showCarts();
    } catch (err: any) {
        error("Lỗi xóa khóa học: " + err);
    }
};

const handlePaymentSuccess = () => {
    console.log('✅ Thanh toán thành công từ Cart!');
    showCarts(); // Refresh cart data
};

watch(() => i18n.global.locale, () => {
    showCarts();
});

onMounted(() => {
    showCarts();
});
</script>

<template>
    <Header />
    <div class="container py-5 mt-5">
        <h1 class="neon-title fs-4 mb-5">Giỏ hàng của bạn</h1>

        <div class="row mt-4">
            <div class="col-md-8">
                <div v-for="(Cart, index) in Carts" :key="index"
                    class="d-flex align-items-center mb-4 border-bottom pb-3">
                    <img :src="Cart.image" class="me-4"
                        style="width: 80px; height: 80px; object-fit: cover; border-radius: 4px;" />
                    <div class="flex-grow-1">
                        <h5 class="mb-1">{{ Cart.name }}</h5>
                        <small class="text-muted">{{ Cart.description }}</small>
                    </div>
                    <div class="me-3 fw-bold">{{ Cart.price.toLocaleString('vi-VN') }}đ</div>
                    <button class="btn btn-outline-danger btn-sm" @click="remove(Cart.id)">×</button>
                </div>
            </div>
            <div class="col-md-4">
                <div class="payment p-4 rounded shadow-sm">
                    <h5 class="mb-3 fw-semibold fs-5">Tóm tắt đơn hàng</h5>
                    <p class="d-flex justify-content-between mb-2">
                        <span>Số khóa học</span>
                        <span>{{ count }}</span>
                    </p>
                    <p class="d-flex justify-content-between mb-2">
                        <span>Tạm tính</span>
                        <span>{{ subtotal.toLocaleString('vi-VN') }}đ</span>
                    </p>
                    <p class="d-flex justify-content-between fw-bold border-top pt-2">
                        <span>Tổng cộng</span>
                        <span>{{ subtotal.toLocaleString('vi-VN') }}đ</span>
                    </p>
                    <button class="btn btn-warning w-100 mt-3" @click="showModal = true">THANH TOÁN</button>
                </div>
            </div>
        </div>
        <PayModel 
            v-if="showModal" 
            :show="showModal" 
            :amount="subtotal" 
            :courseIds="Carts.map(cart => cart.id)"
            @close="showModal = false" 
            @success="handlePaymentSuccess"
        />
    </div>
    <ToastContainer />
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
