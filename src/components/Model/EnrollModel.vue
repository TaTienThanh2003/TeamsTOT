<script setup lang="ts">
defineProps<{
    name : string
}>()
</script>

<template>
    <div class="modal fade" id="consultModal" tabindex="-1" aria-labelledby="consultModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content rounded-4 shadow">
                <div class="modal-header">
                    <h5 class="modal-title fw-bold" id="consultModalLabel">ĐĂNG KÝ NHẬN
                        TƯ VẤN</h5>
                    <button class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body p-4">
                    <form @submit.prevent="">
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
                        <button class="btn back-blue w-100 text-white">Đăng ký</button>
                    </form>
                </div>
            </div>
        </div>
    </div>

</template>