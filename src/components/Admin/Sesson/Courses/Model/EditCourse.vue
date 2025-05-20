<script setup lang="ts">
import { ref, watch, defineEmits, defineProps } from 'vue'
import { updateCourse } from '@/services/index'

interface Course {
  id: number,
  titleVI: string,
  titleEN: string,
  desVI: string,
  desEN: string,
  countDay: number,
  price: number,
  mode: string,
  img: string
}

const props = defineProps<{
  showEditModal: boolean,
  course: Course | null
}>()

const emit = defineEmits(['cancel', 'saved'])

const defaultCourse: Course = {
  id: 0,
  titleVI: '',
  titleEN: '',
  desVI: '',
  desEN: '',
  countDay: 1,
  price: 0,
  mode: 'ONLINE',
  img: ''
}

const form = ref<Course>({ ...defaultCourse })

watch(() => props.course, (newCourse) => {
  form.value = newCourse ? { ...newCourse } : { ...defaultCourse }
}, { immediate: true })

const save = async () => {
  if (!form.value.id) {
    alert('Không có khóa học để cập nhật')
    return
  }
  try {
    const updated = await updateCourse(form.value.id, form.value)
    emit('saved', updated)
  } catch (error) {
    alert('Lỗi cập nhật khóa học')
    console.error(error)
  }
}

const cancel = () => {
  emit('cancel')
}
</script>


<template>
    <div v-if="showEditModal">
        <div class="row g-3">
            <div class="col-md-6">
                <label class="form-label">Tiêu đề (Tiếng Việt) *</label>
                <input v-model="form.titleVI" type="text" class="form-control" />
            </div>
            <div class="col-md-6">
                <label class="form-label">Tiêu đề (English) *</label>
                <input v-model="form.titleEN" type="text" class="form-control" />
            </div>

            <div class="col-md-6">
                <label class="form-label">Mô tả (Tiếng Việt) *</label>
                <textarea v-model="form.desVI" class="form-control" rows="3"></textarea>
            </div>
            <div class="col-md-6">
                <label class="form-label">Mô tả (English) *</label>
                <textarea v-model="form.desEN" class="form-control" rows="3"></textarea>
            </div>
            <div class="col-md-4">
                <label class="form-label">Số ngày học *</label>
                <input v-model="form.countDay" type="number" min="1" class="form-control" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Giá (VNĐ) *</label>
                <input v-model="form.price" type="number" min="0" class="form-control" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Hình thức học *</label>
                <select v-model="form.mode" class="form-select">
                    <option value="ONLINE">Online</option>
                    <option value="OFFLINE">Offline</option>
                </select>
            </div>
            <div class="col-md-12 mb-3">
                <label class="form-label">Ảnh đại diện (URL) *</label>
                <input v-model="form.img" type="text" class="form-control" />
            </div>
        </div>
        <div v-if="form.img" class="text-center my-3">
            <img :src="form.img" class="img-thumbnail" style="max-height: 200px;" />
        </div>
    </div>
    <button class="btn btn-submit mr-2" @click="save">Lưu thay đổi</button>
    <button class="btn btn-outline-secondary" @click="cancel">Hủy</button>
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
