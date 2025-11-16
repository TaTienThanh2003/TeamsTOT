<template>
    <div class="modal fade" id="addLessonModal" tabindex="-1" aria-labelledby="addLessonModalLabel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="addLessonModalLabel">Thêm Lesson</h5>
                    <button class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="titleVI" class="form-label">Tiêu đề (Vietnamese)</label>
                                <input type="text" class="form-control" id="titleVI" v-model="formData.titleVI"
                                    required />
                            </div>
                            <div class="col-md-6 mb-3">
                                <label for="titleEN" class="form-label">Tiêu đề (English)</label>
                                <input type="text" class="form-control" id="titleEN" v-model="formData.titleEN"
                                    required />
                            </div>
                        </div>

                        <div class="mb-3">
                            <label for="desVI" class="form-label">Mô tả (Vietnamese)</label>
                            <textarea class="form-control" id="desVI" rows="3" v-model="formData.desVI"></textarea>
                        </div>

                        <div class="mb-3">
                            <label for="desEN" class="form-label">Mô tả (English)</label>
                            <textarea class="form-control" id="desEN" rows="3" v-model="formData.desEN"></textarea>
                        </div>

                        <div class="mb-3">
                            <label for="video_url" class="form-label">Link video</label>
                            <input type="url" class="form-control" id="video_url" v-model="formData.video_url"
                                required />
                        </div>

                        <div class="row">
                            <div class="col-md-12 mb-3">
                                <label for="position" class="form-label">Vị trí</label>
                                <input type="number" class="form-control" id="position" v-model="formData.position"
                                    required />
                            </div>
                        </div>

                        <button type="submit" class="btn btn-primary">Lưu</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <ToastContainer />
</template>
<script setup lang="ts">
import { ref } from 'vue';
import { useToast } from '@/composables/useToast';
import ToastContainer from '@/components/Toast/ToastContainer.vue';
const { success, error } = useToast();

const formData = ref({
    titleVI: '',
    titleEN: '',
    desVI: '',
    desEN: '',
    video_url: '',
    completed: false,
    position: 0
})

</script>
