<script setup lang="ts">
import { addCourse } from '@/services';
import { ref } from 'vue'
import { useToast } from '@/composables/useToast';
import ToastContainer from '@/components/Toast/ToastContainer.vue';
defineProps<{
    showModal: boolean
}>()
const { success, error } = useToast();

const newCourse = ref({
    titleVI: '',
    titleEN: '',
    desVI: '',
    desEN: '',
    countDay: 1,
    price: 0,
    mode: 'ONLINE',
    img: ''
})

const emit = defineEmits(['cancel', 'refresh'])

const saveCourse = async () => {
    try {
        const { titleVI, titleEN, desVI, desEN, countDay, price, mode, img } = newCourse.value
        await addCourse(titleVI, titleEN, desVI, desEN, countDay, price, mode, img)
        success('Thêm thành công')
        newCourse.value = {
            titleVI: '',
            titleEN: '',
            desVI: '',
            desEN: '',
            countDay: 1,
            price: 0,
            mode: 'ONLINE',
            img: ''
        }
        emit('refresh')
    } catch (exerror) {
        error('Thêm thất bại')
    }
}
</script>

<template>
    <div v-if="showModal">
        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Tiêu đề (Tiếng Việt) *</label>
                <input v-model="newCourse.titleVI" type="text" class="form-control" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Tiêu đề (English) *</label>
                <input v-model="newCourse.titleEN" type="text" class="form-control" />
            </div>

            <div class="col-md-6">
                <label class="form-label">Mô tả (Tiếng Việt) *</label>
                <textarea v-model="newCourse.desVI" class="form-control" rows="3"></textarea>
            </div>
            <div class="col-md-6">
                <label class="form-label">Mô tả (English) *</label>
                <textarea v-model="newCourse.desEN" class="form-control" rows="3"></textarea>
            </div>
            <div class="col-md-4">
                <label class="form-label">Số ngày học *</label>
                <input v-model="newCourse.countDay" type="number" min="1" class="form-control" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Giá (VNĐ) *</label>
                <input v-model="newCourse.price" type="number" min="0" class="form-control" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Hình thức học *</label>
                <select v-model="newCourse.mode" class="form-select">
                    <option value="ONLINE">Online</option>
                    <option value="OFFLINE">Offline</option>
                </select>
            </div>
            <div class="col-md-12 mb-3">
                <label class="form-label">Ảnh đại diện (URL) *</label>
                <input v-model="newCourse.img" type="text" class="form-control" />
            </div>
        </div>
        <div v-if="newCourse.img" class="text-center my-3">
            <img :src="newCourse.img" class="img-thumbnail" style="max-height: 200px;" />
        </div>
    </div>
    <button class="btn btn-submit mr-2" @click="saveCourse">Lưu khóa học</button>
    <button class="btn btn-outline-secondary" @click="emit('cancel')">Hủy</button>
    <ToastContainer />
</template>

<style scoped>
.btn-submit {
    background-color: #4b3fb3;
    color: white;
}

.btn-submit:hover {
    background-color: #3a32a3;
}

.btn-close {
    background: none;
    border: none;
    font-size: 1.5rem;
    line-height: 1;
    cursor: pointer;
}
</style>
