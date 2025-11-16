<script setup lang="ts">
const props = defineProps<{
    id: string,
    name: string
}>()

import { useToast } from '@/composables/useToast'

const { success } = useToast()

const handleSubmit = () => {
  success('Đăng ký tư vấn thành công!')
  // Đóng modal
  const modal = document.getElementById(`giftConsultModal-${props.id}`)
  if (modal) {
    const closeButton = modal.querySelector('[data-bs-dismiss="modal"]') as HTMLElement
    if (closeButton) {
      closeButton.click()
    }
  }
}
</script>

<template>
  <teleport to="body">
    <div class="modal fade" :id="`giftConsultModal-${id}`" tabindex="-1" :aria-labelledby="`giftConsultModalLabel-${id}`" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content rounded-4 shadow">
          <div class="modal-header">
            <h5 class="modal-title fw-bold" :id="`giftConsultModalLabel-${id}`">ĐĂNG KÝ NHẬN TƯ VẤN</h5>
            <button class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body p-4">
            <form @submit.prevent="handleSubmit">
              <div class="mb-3">
                <input type="text" class="form-control w-100" placeholder="Ta Kim Oanh" required>
                <div class="invalid-feedback">Bạn phải điền trường thông tin này!</div>
              </div>
              <div class="mb-3">
                <input type="text" class="form-control w-100" placeholder="094839434" required>
              </div>
              <div class="mb-3">
                <input type="email" class="form-control w-100" placeholder="onah@gmail.com">
              </div>
              <div class="mb-3">
                <input type="text" class="form-control w-100" :placeholder="name" disabled>
              </div>
              <button type="submit" class="btn back-blue w-100 text-white">Đăng ký</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </teleport>
</template>

<style scoped>
.btn.back-blue {
    background-color: #6C63FF !important;
    border-color: #6C63FF !important;
    color: white !important;
    font-weight: 500;
    transition: all 0.3s ease;
}
.btn.back-blue:hover {
    background-color: #5a52d5 !important;
    border-color: #5a52d5 !important;
    color: white !important;
    transform: translateY(-2px);
    box-shadow: 0 4px 8px rgba(108, 99, 255, 0.3);
}
.btn.back-blue:focus {
    background-color: #6C63FF !important;
    border-color: #6C63FF !important;
    color: white !important;
    box-shadow: 0 0 0 0.2rem rgba(108, 99, 255, 0.25);
}
.btn.back-blue:active {
    background-color: #5a52d5 !important;
    border-color: #5a52d5 !important;
    color: white !important;
}
</style>