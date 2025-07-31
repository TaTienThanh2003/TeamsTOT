<template>
  <div v-if="show" class="success-modal-backdrop" style="border: 3px solid red;">
    <!-- Debug: Hiển thị khi show = true -->
    <div style="position: absolute; top: 10px; left: 10px; color: white; background: red; padding: 5px; z-index: 9999;">
      DEBUG: SuccessModal is showing - show = {{ show }}
    </div>
    <div class="success-modal-content text-center p-5 rounded-4">
      <div class="success-icon mb-4">
        <i class="fas fa-check-circle fa-4x text-success"></i>
      </div>
      <h2 class="mb-3 text-success fw-bold">Thanh toán thành công!</h2>
      <p class="mb-4 text-muted">Cảm ơn bạn đã đăng ký khóa học.<br>Chúc bạn học tập hiệu quả!</p>
      <div class="d-flex gap-3 justify-content-center">
        <button class="btn btn-outline-secondary px-4" @click="$emit('close')">Đóng</button>
        <button class="btn btn-success px-4" @click="goToMyCourses">
          <i class="fas fa-graduation-cap me-2"></i>Khóa học của tôi
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';

const router = useRouter();

defineProps<{ show: boolean }>();
defineEmits(['close']);

const goToMyCourses = () => {
  router.push('/hocvien#course');
};
</script>

<style scoped>
.success-modal-backdrop {
  position: fixed;
  top: 0; 
  left: 0; 
  width: 100vw; 
  height: 100vh;
  background: rgba(0,0,0,0.6);
  z-index: 3000; /* Tăng z-index để đảm bảo hiển thị trên PayModel */
  display: flex; 
  align-items: center; 
  justify-content: center;
  padding: 20px;
}

.success-modal-content {
  background: #fff;
  max-width: 400px;
  width: 100%;
  box-shadow: 0 8px 32px rgba(0,0,0,0.2);
  border-radius: 16px;
  animation: slideIn 0.3s ease-out;
}

.success-icon i {
  font-size: 4rem;
  color: #28a745;
  animation: pop 0.6s ease-out;
}

@keyframes pop {
  0% { 
    transform: scale(0.5);
    opacity: 0;
  }
  50% { 
    transform: scale(1.1);
  }
  100% { 
    transform: scale(1);
    opacity: 1;
  }
}

@keyframes slideIn {
  0% {
    transform: translateY(-50px);
    opacity: 0;
  }
  100% {
    transform: translateY(0);
    opacity: 1;
  }
}

.btn-success {
  background-color: #28a745;
  border-color: #28a745;
  transition: all 0.3s ease;
}

.btn-success:hover {
  background-color: #218838;
  border-color: #1e7e34;
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(40, 167, 69, 0.3);
}

.btn-outline-secondary {
  transition: all 0.3s ease;
}

.btn-outline-secondary:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(108, 117, 125, 0.3);
}
</style> 