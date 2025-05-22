<template>
    <!-- Modal -->
    <div class="modal fade" id="addSectionlModal" tabindex="-1" aria-labelledby="addSectionlModalLabel"
        aria-hidden="false">
        <div class="modal-dialog">
            <div class="modal-content rounded-3 overflow-hidden">
                <div class="modal-header bg-primary text-white">
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

<script setup lang="ts">
import { addSection } from '@/services';
import { ref, watch } from 'vue';
import { defineProps } from 'vue';


declare const bootstrap: any;
const props = defineProps<{ courses_id?: number | null; }>();
const emit = defineEmits(['refresh', 'close'])

interface Section {
    titleVI: string,
    titleEN: string,
    desVI: string,
    desEN: string,
    courses_id: number | null,
    position: number | null,
}

const formData = ref<Section>({
    titleVI: '',
    titleEN: '',
    desVI: '',
    desEN: '',
    courses_id: null,
    position: null
});
const submitForm = async () => {
    // Xử lý gửi dữ liệu ở đây
    formData.value.courses_id = props.courses_id ?? null;
    try {
        console.log('Received course_id:', props.courses_id);
        const res = await addSection(formData.value);
        const modalElement = document.getElementById('addSectionlModal');
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
        modal.hide();
        // Reset form
        formData.value = {
            titleVI: '',
            titleEN: '',
            desVI: '',
            desEN: '',
            courses_id: null,
            position: null
        };
        emit('close')
        emit("refresh")
    } catch (error) {
        console.log(error)
    }
    // console.log(formData.value);
};
watch(() => props.courses_id, (newVal) => {
    console.log('course_id changed:', newVal);
});
</script>
