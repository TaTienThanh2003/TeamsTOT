<script setup lang="ts">
import { ref, onMounted, defineProps, watch } from 'vue'
import DetailItem from '@/components/Home/Detail/DetailItem.vue';
import i18n from '@/i18n';
import { getLessons, getCourseById } from '@/services';

const props = defineProps<{
    courseId?: number | null;
}>();

const course = ref<any>({
    id: 0,
    titleVI: "",
    titleEN: "",
    desVI: "",
    desEN: "",
    countDay: 0,
    price: 0,
    mode: "",
    img: ""
})
const sections = ref<any>([])

const showCourseDetail = async (courseId: number) => {
    try {
        const res = await getCourseById(courseId);
        console.log("API Response:", res);
        const courseData = res;
        if (!courseData) {
            console.error("Không có dữ liệu course");
            return;
        }
        course.value = {
            id: courseData.id,
            titleVI: courseData.titleVI,
            titleEN: courseData.titleEN,
            desVI: courseData.desVI,
            desEN: courseData.desEN,
            countDay: courseData.countDay,
            price: courseData.price,
            mode: courseData.mode,
            img: courseData.img
        };
        await showLessons(courseId);
    } catch (err: any) {
        console.log("Lỗi lấy thông tin khóa học:", err);
    }
};

const showLessons = async (courseid: number) => {
    try {
        const res = await getLessons(courseid);
        console.log("Lessons Response:", res);
        if (!res || !res.data) {
            console.error("Không có dữ liệu lessons");
            return;
        }

        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        
        // res.data là mảng các section, mỗi section có thuộc tính lessons
        sections.value = res.data.map((section: any) => {
            const processedSection = {
                title: section[nameKey],
                lessons: section.lessons.map((lesson: any) => ({
                    id: lesson.id,
                    titleVI: lesson.titleVI,
                    titleEN: lesson.titleEN,
                    desVI: lesson.desVI,
                    desEN: lesson.desEN,
                    completed: lesson.completed,
                    videoUrl: lesson.video_url
                }))
            };
            console.log("Processed section:", processedSection);
            return processedSection;
        });
        console.log("All sections:", sections.value);
    } catch (err: any) {
        console.log("Lỗi lấy danh sách bài học:", err);
    }
};

const changeVideo = (videoUrl: string) => {
    // TODO: Implement video player functionality
    console.log("Playing video:", videoUrl);
}

watch(() => props.courseId, (newId) => {
    if (newId) {
        showCourseDetail(newId);
    }
});

onMounted(() => {
    if (props.courseId) {
        showCourseDetail(props.courseId);
    }
});
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
                    <div v-for="(section, index) in sections" :key="index">
                        <DetailItem 
                            :title="section.title"
                            :lessons="section.lessons"
                            :isLocked="false"
                            @play="changeVideo"
                        />
                    </div>
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

.lesson-item {
    background-color: #f8f9fa;
    transition: all 0.3s ease;
}

.lesson-item:hover {
    background-color: #e9ecef;
}

.text-blue {
    color: #0d6efd;
}
</style>