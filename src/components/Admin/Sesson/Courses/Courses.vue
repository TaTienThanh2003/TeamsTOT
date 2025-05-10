<script setup lang="ts">
import { ref } from 'vue';
import AddCourse from './Model/AddCourse.vue';
import DetailCourse from './Model/DetailCourse.vue';
import { translateViEn } from '@/services';
import AddSection from './Model/AddSection.vue';

const showModal = ref(false)
const showSection = ref(false)
const showLesson = ref(false)
// await translateViEn("Xin chào");
</script>
<template>
    <div class="tab-pane fade active" id="my-courses">
        <h4 class="fs-4 text-center fw-bold ">QUẢN LÝ KHÓA HỌC</h4>
        <div class="mt-2">
            <button v-if="!showModal" @click="showModal = true, showSection = false, showLesson = false"
                class="btn btn-outline-primary">
                + Thêm khóa học
            </button>
            <AddCourse v-if="showModal" :showModal="showModal" @cancel="showModal = false" />
        </div>

        <table class="table table-bordered mt-4">
            <thead class="table-light">
                <tr>
                    <th style="width: 40%;">Tên</th>
                    <th style="width: 15%;">Số mục</th>
                    <th style="width: 15%;">Hành động</th>
                </tr>
            </thead>
            <tbody>
                <!-- Course -->
                <tr class="table-primary">
                    <td>
                        <div class="d-flex justify-between">
                            Tiếng Anh thiếu nhi cơ bản
                            <button class="btn btn-sm btn-link" @click="showSection = !showSection, showLesson = false">
                                <i :class="['fa', showSection ? 'fa-chevron-up' : 'fa-chevron-down']"></i>
                            </button>
                        </div>
                    </td>
                    <td>3</td>
                    <td>
                        <button class="btn btn-sm btn-outline-dark mx-1" data-bs-toggle="modal"
                            data-bs-target="#courseDetailModal" title="Chi tiết">
                            <i class="fa fa-eye"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-success mx-1"
                            @click="showModal = true, showSection = false, showLesson = false" title="Sửa">
                            <i class="fa fa-edit"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
                            <i class="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>

                <!-- Section -->
                <tr v-if="showSection" class="table-secondary">
                    <td class="ps-4">
                        <div class="d-flex justify-between">
                            Chuyên phần 1: Phát âm
                            <button class="btn btn-sm btn-link" @click="showLesson = !showLesson">
                                <i :class="['fa', showLesson ? 'fa-chevron-up' : 'fa-chevron-down']"></i>
                            </button>
                        </div>
                    </td>
                    <td>2</td>
                    <td>
                        <button class="btn btn-sm btn-outline-success mx-1" data-bs-toggle="modal"
                            data-bs-target="#addSectionlModal" title="Sửa">
                            <i class="fa fa-edit"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
                            <i class="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>
                <tr v-if="showSection" class="table-secondary">
                    <td class="ps-4">
                        <div class="d-flex justify-between">
                            Chuyên phần 2: Cơ bản
                            <button class="btn btn-sm btn-link" @click="showLesson = !showLesson">
                                <i :class="['fa', showLesson ? 'fa-chevron-up' : 'fa-chevron-down']"></i>
                            </button>
                        </div>
                    </td>
                    <td>2</td>
                    <td>
                        <button class="btn btn-sm btn-outline-success mx-1" title="Sửa">
                            <i class="fa fa-edit"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
                            <i class="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>

                <!-- Lesson -->
                <tr v-if="showLesson">
                    <td class="ps-5">Bài 1: Giới thiệu bảng chữ cái
                    </td>
                    <td>—</td>
                    <td>
                        <button class="btn btn-sm btn-outline-success mx-1" title="Sửa">
                            <i class="fa fa-edit"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
                            <i class="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>
                <tr v-if="showLesson">
                    <td class="ps-5">Bài 2: Âm A, B, C</td>
                    <td>—</td>
                    <td>
                        <button class="btn btn-sm btn-outline-success mx-1" title="Sửa">
                            <i class="fa fa-edit"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
                            <i class="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>

                <!-- Lesson thêm -->
                <tr v-if="showLesson">
                    <td class="ps-5">
                        <div class="d-flex justify-between">
                            Bài giảng khác
                            <button class="btn btn-sm btn-link">
                                <i class="fa fa-plus"></i>
                            </button>
                        </div>
                    </td>
                    <td>—</td>
                    <td>—</td>
                </tr>

                <!-- Section thêm (nếu có) -->
                <tr v-if="showSection" class="table-secondary">
                    <td class="ps-4">
                        <div class="d-flex justify-between">
                            Chuyên phần khác
                            <button class="btn btn-sm btn-link" data-bs-toggle="modal"
                                data-bs-target="#addSectionlModal">
                                <i class="fa fa-plus"></i>
                            </button>
                        </div>
                    </td>
                    <td>—</td>
                    <td>—</td>
                </tr>

                <!-- Course khác -->
                <!-- ... -->
            </tbody>
        </table>
        <DetailCourse />
        <AddSection />
    </div>
</template>
<style scoped>
body {
    background-color: #f3f4ff;
}

.section-header {
    background-color: #4b3fb3;
    color: white;
    padding: 1rem;
    border-radius: 10px 10px 0 0;
}

.form-section {
    background: white;
    padding: 2rem;
    border-radius: 0 0 10px 10px;
    margin-bottom: 2rem;
}

.btn-submit {
    background-color: #4b3fb3;
    color: white;
}

.btn-submit:hover {
    background-color: #3a32a3;
}
</style>