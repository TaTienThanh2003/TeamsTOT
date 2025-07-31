<script setup lang="ts">
import { ref, computed, watch, onUnmounted } from 'vue';
import Countdown from '@chenfengyuan/vue-countdown';
import { checkPaid, addEnrollments, deleteMultipleCarts } from '@/services';
import SuccessModal from './SuccessModal.vue';
import { useToast } from '@/composables/useToast';

const { success, error } = useToast();

// Props nhận từ cha
const props = defineProps<{
    show: boolean;
    amount: number;
    courseIds?: number[]; // Thêm prop để nhận danh sách course IDs
}>();
const emit = defineEmits(['close', 'success']);

// Biến trạng thái cho success modal
const showSuccess = ref(false);

// Thông tin QR code tĩnh
const bankId = 'mbbank';
const accountNumber = '0486955969999';
const template = 'compact2';
const accountName = 'Nguyễn Đức Anh Tuấn';
const content = 'TOT2025_TOEIC';

// URL QR code động
const qrUrl = computed(() => {
    const baseUrl = 'https://img.vietqr.io/image';
    const formattedAccountName = encodeURIComponent(accountName);
    return `${baseUrl}/${bankId}-${accountNumber}-${template}.jpg?amount=${props.amount}&addInfo=${content}&accountName=${formattedAccountName}`;
});

// Biến trạng thái kiểm tra giao dịch
const checking = ref(false);
let intervalId: number | null = null;
let timeoutId: number | null = null;

// Hàm thêm enrollment cho user
const enrollUserToCourses = async () => {
    if (!props.courseIds || props.courseIds.length === 0) {
        console.log("Không có course IDs để đăng ký");
        return;
    }

    try {
        const user = JSON.parse(localStorage.getItem("user") || "{}");
        const userId = user.id;

        if (!userId) {
            console.error("Không tìm thấy user ID");
            return;
        }

        // Đăng ký từng khóa học
        let enrolledCount = 0;
        let alreadyEnrolledCount = 0;
        
        for (const courseId of props.courseIds) {
            try {
                const result = await addEnrollments(userId, courseId);
                if (result.message === 'Đã đăng ký trước đó') {
                    console.log(`⚠️ Khóa học ${courseId} đã được đăng ký trước đó`);
                    alreadyEnrolledCount++;
                } else {
                    console.log(`✅ Đã đăng ký khóa học ID: ${courseId}`);
                    enrolledCount++;
                }
            } catch (error: any) {
                console.error(`❌ Lỗi đăng ký khóa học ${courseId}:`, error);
                // Vẫn tiếp tục với các khóa học khác
            }
        }
        
        // Xóa khóa học khỏi cart sau khi đăng ký thành công
        if (enrolledCount > 0 || alreadyEnrolledCount > 0) {
            try {
                await deleteMultipleCarts(props.courseIds || [], userId);
                console.log('✅ Đã xóa khóa học khỏi cart');
            } catch (error) {
                console.error('❌ Lỗi xóa khóa học khỏi cart:', error);
            }
        }
        
        // Hiển thị thông báo kết quả
        if (enrolledCount > 0 && alreadyEnrolledCount > 0) {
            success(`Đăng ký thành công ${enrolledCount} khóa học! ${alreadyEnrolledCount} khóa học đã được đăng ký trước đó.`);
        } else if (enrolledCount > 0) {
            success(`Đăng ký thành công ${enrolledCount} khóa học!`);
        } else if (alreadyEnrolledCount > 0) {
            success(`Tất cả khóa học đã được đăng ký trước đó!`);
        }
    } catch (error) {
        console.error("Lỗi khi đăng ký khóa học:", error);
    }
};

// Hàm polling gọi checkPaid mỗi 10 giây
const pollPayment = async () => {
    if (checking.value) {
        console.log("⚠️ Đang kiểm tra rồi, bỏ qua lần này");
        return;
    }
    console.log("⏳ Bắt đầu kiểm tra thanh toán...");
    checking.value = true;

    const success = await checkPaid(props.amount, content);

    if (success) {
        console.log("✅ Thanh toán thành công!");
        clearPolling();
        
        // Đăng ký khóa học cho user
        await enrollUserToCourses();
        
        // Đóng payModel và hiện success modal
        emit('close');
        emit('success'); // Emit success event
        console.log("🔄 Đang hiện SuccessModal...");
        
        // Delay để đảm bảo PayModel đã đóng hoàn toàn
        setTimeout(() => {
            showSuccess.value = true;
            console.log("✅ SuccessModal đã được set:", showSuccess.value);
        }, 500);
    } else {
        console.log("⏳ Chưa có thanh toán phù hợp, tiếp tục chờ...");
    }

    checking.value = false;
    console.log("⏳ Kết thúc lần kiểm tra thanh toán");
};

// Dừng polling
const clearPolling = () => {
    if (intervalId !== null) {
        clearInterval(intervalId);
        intervalId = null;
    }
    if (timeoutId !== null) {
        clearTimeout(timeoutId);
        timeoutId = null;
    }
};

// Khi modal mở bắt đầu đếm 30s rồi polling, đóng thì dừng
watch(() => props.show, (newVal) => {
    console.log('👀 props.show:', newVal);
    if (newVal) {
        timeoutId = setTimeout(() => {
            pollPayment(); // Gọi lần đầu sau 30s
            intervalId = setInterval(pollPayment, 10000); // Sau đó gọi mỗi 10s
        }, 10000);
    } else {
        clearPolling();
    }
}, { immediate: true });

// Dọn dẹp khi component unmount
onUnmounted(() => {
    clearPolling();
});

// Khi countdown kết thúc
const onCountdownEnd = async () => {
    clearPolling();

    const success = await checkPaid(props.amount, content);
    if (success) {
        console.log("✅ Thanh toán thành công!");
        // Đăng ký khóa học cho user
        await enrollUserToCourses();
        
        // Đóng payModel và hiện success modal
        emit('close');
        emit('success'); // Emit success event
        console.log("🔄 Đang hiện SuccessModal (countdown end)...");
        
        // Delay để đảm bảo PayModel đã đóng hoàn toàn
        setTimeout(() => {
            showSuccess.value = true;
            console.log("✅ SuccessModal đã được set (countdown end):", showSuccess.value);
        }, 500);
    } else {
        alert("❌ Hết thời gian thanh toán. Vui lòng thử lại sau");
        emit('close');
    }
};

// Hủy thanh toán
const onCancel = async () => {
    const confirmCancel = confirm('Bạn chắc chắn muốn hủy thanh toán?');
    if (!confirmCancel) return;

    await onCountdownEnd();
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

                <div class="text-warning mt-4 small">Đang chờ thanh toán</div>

                <Countdown :time="600000" @end="onCountdownEnd" v-slot="slotProps">
                    <div class="text-white fw-bold mt-1">
                        {{ String((slotProps as any).minutes).padStart(2, '0') }}:{{ String((slotProps as any).seconds).padStart(2, '0') }}
                    </div>
                </Countdown>

                <button class="btn btn-outline-light mt-4 w-100" @click="onCancel">HỦY THANH TOÁN</button>
            </div>
        </div>
        
        <!-- Success Modal -->
        <SuccessModal :show="showSuccess" @close="showSuccess = false" />
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
