<script setup lang="ts">
import { ref, onMounted } from 'vue'
import DetailItem from '@/components/Home/Detail/DetailItem.vue';
import i18n from '@/i18n';
import { getLessons } from '@/services';

const course = ref({
    id: 2,
    titleVI: "Khóa học Giao tiếp thực tế",
    titleEN: "Practical Communication Course",
    desVI:
        "Dành cho người mất gốc hoặc muốn cải thiện phản xạ nói. Phương pháp phản xạ tự nhiên, thực hành ngay tại lớp. Tự tin giao tiếp trong công việc và cuộc sống.",
    desEN:
        "For beginners or those who want to improve speaking reflexes. Natural reflection method, practice directly in class. Be confident in communication at work and in life.",
    countDay: 30,
    price: 1990000,
    mode: "ONLINE",
    img: "https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg"
})
const sections = ref<any>([])

const showLessons = async (courseid: number) => {
    try {
        const res = await getLessons(courseid);
        const resdata = res.data;

        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        sections.value = resdata.map((section: any) => ({
            title: section[nameKey],
            lessons: section.lessons
        }));
        console.log("Lỗi api khóa học" + resdata)
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};
const changeVideo = () => {

}
onMounted(() => showLessons(2))
</script>
<template>
    <!-- Modal -->
    <div class="modal fade" id="courseDetailModal" tabindex="-1" aria-labelledby="courseDetailModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title" id="courseDetailModalLabel">Thông tin khóa học</h5>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal"
                        aria-label="Đóng"></button>
                </div>
                <div class="modal-body">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <img :src="course.img" class="img-fluid h-100 object-fit-cover" alt="course image" />
                        </div>
                        <div class="col-md-8">
                            <div class="card-body p-3">
                                <h3 class="card-title">{{ course.titleVI }}</h3>
                                <h5 class="text-muted">{{ course.titleEN }}</h5>
                                <p class="card-text mt-3">{{ course.desVI }}</p>
                                <p class="text-muted fst-italic">{{ course.desEN }}</p>
                                <ul class="list-group list-group-flush mt-4">
                                    <li class="list-group-item">
                                        🗓️ Thời lượng: {{ course.countDay }} ngày
                                    </li>
                                    <li class="list-group-item">
                                        💰 Giá: {{ course.price.toLocaleString('vi-VN') }} VNĐ
                                    </li>
                                    <li class="list-group-item">
                                        🖥️ Hình thức: {{ course.mode }}
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <h5 class="text-center fs-4 mt-2 text-blue ">Chi tiết Phần học</h5>
                    <DetailItem v-for="(section, index) in sections" :key="index" :title="section.title"
                            :lessons="section.lessons" :isLocked="false" @play="changeVideo" />
                    <div class="modal-footer">
                        <button class="btn btn-secondary" data-bs-dismiss="modal">Đóng</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
.img-fluid {
    border-radius: 10px;
}
</style>