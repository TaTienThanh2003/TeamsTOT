<template>
    <!-- Modal -->
    <div class="modal fade" id="addSectionlModal" tabindex="-1" aria-labelledby="addSectionlModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header back-blue text-white">
                    <h5 class="modal-title" id="addSectionlModalLabel">Tạo Section</h5>
                    <button type="button" class="btn-close text-white" data-bs-dismiss="modal"
                        aria-label="Close">X</button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="submitForm">
                        <div class="d-flex gap-1">
                            <div class="mb-3">
                                <label for="titleVI" class="form-label">Tiêu đề (Vietnamese)</label>
                                <input type="text" class="form-control" id="titleVI" v-model="formData.titleVI"
                                    required />
                            </div>
                            <div class="mb-3">
                                <label for="titleEN" class="form-label">Tiêu đề (English)</label>
                                <input type="text" class="form-control" id="titleEN" v-model="formData.titleEN"
                                    required />
                            </div>
                        </div>
                        <div class="mb-3">
                            <label for="desVI" class="form-label">Mô tả (Vietnamese)</label>
                            <textarea class="form-control" id="desVI" v-model="formData.desVI"></textarea>
                        </div>
                        <div class="mb-3">
                            <label for="desEN" class="form-label">Mô tả (English)</label>
                            <textarea class="form-control" id="desEN" v-model="formData.desEN"></textarea>
                        </div>
                        <div class="mb-3">
                            <label for="position" class="form-label">Vị trí</label>
                            <input type="number" class="form-control" id="position" v-model="formData.position" />
                        </div>
                        <button class="btn btn-primary">Submit</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref } from 'vue';

const formData = ref({
    titleVI: '',
    titleEN: '',
    desVI: '',
    desEN: '',
    position: null
});

const submitForm = () => {
    // Xử lý gửi dữ liệu ở đây
    console.log(formData.value);

    // Đóng modal sau khi gửi
    const modalElement = document.getElementById('addSectionlModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.hide(); // Đóng modal
};
</script>

<style scoped>
.img-fluid {
    border-radius: 10px;
}
</style>