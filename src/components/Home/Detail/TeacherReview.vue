<template>
    <div class="container my-5">
        <h4 class="mt-4 fs-3 font-blue">Giáo viên</h4>
        <div class="d-flex mt-4 gap-5">
            <div v-for="(teacher, index) in teachers" :key="index">
                <TeacherItem :fullname="teacher.FullName" :image="teacher.image" />
            </div>
        </div>

        <div class="mt-5 row">
            <div class="col-md-4">
                <h4 class="mb-4 fs-3 font-blue">Đánh giá của học viên</h4>
                <div class="d-flex align-items-center mb-2">
                    <h3 class="me-2 mb-0">4.7</h3>
                    <div class="text-warning me-2">
                        <i class="fas fa-star"></i>
                        <i class="fas fa-star"></i>
                        <i class="fas fa-star"></i>
                        <i class="fas fa-star"></i>
                        <i class="bi bi-star-half"></i>
                    </div>
                    <span class="text-muted">50 đánh giá</span>
                </div>
                <button class="btn btn-secondary btn-sm">Viết đánh giá</button>
            </div>
            <div v-for="(review, index) in reviews" :key="index">
                <ReviewItem :name="review.name" :content="review.content" :star="review.star" />
            </div>
        </div>
    </div>
</template>
<script setup lang="ts">
import { getReview, getTeacher } from '@/services';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';

const router = useRoute();
const id = parseInt(router.params.id as string);
const teachers = ref<any>([]);
const reviews = ref<any>([]);

const showteacher = async () => {
    try {
        const res = await getTeacher();
        const resdata = res.data;
        teachers.value = resdata.map((teacher: any) => ({
            id: teacher.id,
            FullName: teacher.fullName,
            image: 'https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg',
        }));
    } catch (error) {
        console.log("Lỗi api giáo viên" + error)
    }
}
const showreview = async () => {
    try {
        const res = await getReview(id);
        const resdata = res.data;
        reviews.value = resdata.map((review: any) => ({
            name: 'A',
            content: review.content,
            star: review.star
        }));
    } catch (error) {

    }
}
onMounted(() => {
    showteacher();
    showreview();
});
</script>