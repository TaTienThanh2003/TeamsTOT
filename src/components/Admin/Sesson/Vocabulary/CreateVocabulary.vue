<template>
  <teleport to="body">
    <div class="modal fade" id="createVocabularyModal" tabindex="-1" aria-labelledby="createVocabularyLabel"
      aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header back-blue text-white">
            <h5 class="modal-title" id="createVocabularyLabel">Tạo list từ</h5>
            <button type="button" class="btn-close text-white" data-bs-dismiss="modal" aria-label="Close">X</button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="handleSubmit">
              <div class="mb-3">
                <label class="form-label">Tiêu đề*</label>
                <input type="text" class="form-control w-100" v-model="form.title" required />
              </div>
              <div class="mb-3">
                <label class="form-label">Ngôn ngữ*</label>
                <select class="form-select w-100" v-model="form.language" required>
                  <option value="en-US">Tiếng Anh-Mỹ</option>
                  <option value="vi-VN">Tiếng Việt</option>
                </select>
              </div>
              <div class="mb-3">
                <label class="form-label">Mô tả</label>
                <textarea class="form-control w-100" v-model="form.description"></textarea>
              </div>
              <button class="btn btn-primary mx-auto d-block">Lưu chủ đề</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </teleport>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';
import { defineEmits } from 'vue';

const emit = defineEmits(['saved']);

const form = ref({
  title: '',
  language: 'en-US',
  description: ''
});

const handleSubmit = () => {
  console.log('Đã gửi:', form.value);

  form.value = {
    title: '',
    language: 'en-US',
    description: ''
  };

  emit('saved');
};
</script>

<style scoped>
.back-blue {
  background-color: #007bff;
}

.modal {
  position: fixed;
  z-index: 99999 !important;
}
</style>
