<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import PayModel from '@/components/Model/payModel.vue';
import { onMounted, ref, computed } from 'vue';
import { useRoute } from 'vue-router';
import { getLessons, addCarts, getTeacher, getReview } from '@/services';
import DetailItem from '@/components/Home/Detail/DetailItem.vue';
import TeacherItem from '@/components/Home/Sesson/Teachers/TeacherItem.vue';
import ReviewItem from '@/components/Home/Detail/ReviewItem.vue';
import i18n from '@/i18n';

const router = useRoute();
const showModal = ref(false);
const selectedOption = ref('');
const isLogin = ref(false);
const sections = ref<any>([]);
const teachers = ref<any>([]);
const reviews = ref<any>([]);
const id = parseInt(router.params.id as string);
const user = JSON.parse(localStorage.getItem("user") || "{}");
const userId = user.id;

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

const showLessons = async () => {
    try {
        const res = await getLessons(id);
        const resdata = res.data;
   
        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        sections.value = resdata.map((section: any) => ({
            title: section[nameKey],
            lessons: section.lessons
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};
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
const addtoCarts = async () => {
    try {
        await addCarts(userId, id);
    } catch (err: any) {
        console.log("Lỗi thêm vào giỏ hàng" + err)
    }
}

const computedAmount = computed(() => {
    if (selectedOption.value === 'video') return 499000;
    if (selectedOption.value === 'class') return 1200000;
    return 0;
});
onMounted(() => {
    showLessons();
    showteacher();
    showreview();
});
</script>


<template>
    <Header />
    <div class="container">
        <div class="course-banner text-center">
            <h1 class="fs-3">Chinh phục TOEIC 700+ trong 30 ngày</h1>
            <p class="lead">Khóa học TOEIC toàn diện giúp bạn tăng điểm nhanh chóng với lộ trình rõ ràng, mẹo
                làm bài,
                và thực hành theo đề thi thật.</p>
        </div>

        <div class="row">
            <div class="col-md-8">
                <h4 class="mb-4 fs-3 font-blue">Bạn sẽ học được gì?</h4>
                <ul class="benefits">
                    <li>
                        <i class="fas fa-check-circle text-primary me-2"></i>
                        Giao tiếp cơ bản bằng tiếng Anh trong các tình huống hàng ngày
                    </li>
                    <li>
                        <i class="fas fa-check-circle text-primary me-2"></i>
                        Phát triển kỹ năng nghe và hiểu tiếng Anh hiệu quả
                    </li>
                    <li>
                        <i class="fas fa-check-circle text-primary me-2"></i>
                        Học hơn 1000 từ vựng và cụm từ thông dụng
                    </li>
                    <li>
                        <i class="fas fa-check-circle text-primary me-2"></i>
                        Không cần kiến thức tiếng Anh trước đó
                    </li>
                </ul>
                <h4 class="mt-5 mb-4 fs-3 font-blue">Nội dung khóa học (Xem trước)</h4>
                <DetailItem v-for="(section, index) in sections" :key="id" :title="section.title"
                    :lessons="section.lessons" :isLocked="index !== 0" />
                <TeacherReview />
            </div>

            <div class="col-md-4">
                <div class="card p-4 sticky-top shadow-sm mb-4" style="top: 4rem;">
                    <div class="mb-3">
                        <iframe class="w-100 rounded" style="aspect-ratio: 16/9"
                            src="https://www.youtube.com/embed/md3HfH0SWOI?si=Jz-ce3qM3NhZXoc7"
                            title="Giới thiệu khóa học TOEIC" frameborder="0"
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                            allowfullscreen></iframe>
                    </div>

                    <h3 class="text-danger fw-bold fs-5 mb-3">
                        1,600,000đ
                        <span class="text-muted fs-6 ms-2 text-decoration-line-through">2,500,000đ</span>
                    </h3>

                    <button v-if="!isLogin" class="btn btn-primary btn-lg w-100 mb-2" @click="addtoCarts">
                        Thêm vào giỏ hàng
                    </button>
                    <button class="btn btn-outline-primary btn-lg w-100 mb-2" @click="showModal = true">
                        Tiến hành thanh toán
                    </button>
                    <div class="p-3 rounded-3 h-100">
                        <h5 class="fs-5 mb-3 font-blue">Khóa học TOIEC</h5>
                        <p class="mb-2"><i class="fas fa-play-circle me-2"></i> Xem video mọi lúc, mọi nơi</p>
                        <p class="mb-2"><i class="fas fa-tachometer-alt me-2"></i> Học theo tốc độ cá nhân</p>
                        <p class="mb-2"><i class="fas fa-infinity me-2"></i> Truy cập trọn đời vào nội dung</p>
                    </div>

                    <div class="border p-3 rounded mb-2">
                        <p class="mb-1 text-muted small">LETLEARNNOW đã được áp dụng</p>
                    </div>
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Nhập mã giảm giá">
                        <button class="btn btn-primary">Áp dụng</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal thanh toán -->
        <PayModel v-if="showModal" :show="showModal" :amount="499000" @close="showModal = false" />
    </div>
</template>

<style scoped>
.container {
    margin-top: 6rem !important;
}

.course-banner {
    background: linear-gradient(135deg, #8787fc, #6C63FF);
    color: white;
    padding: 40px;
    border-radius: 16px;
    margin-bottom: 30px;
}

.benefits {
    list-style: none;
    padding-left: 0;
}

.benefits li {
    margin-bottom: 12px;
}

i {
    width: 1.25rem;
}

.teacher-img {
    width: 60px;
    height: 60px;
    object-fit: cover;
    border-radius: 50%;
}

.rating i {
    color: #fbc02d;
}

.card-review {
    border-radius: 10px;
}

.carousel-indicators [data-bs-target] {
    background-color: #000;
}

.blurred-card::after {
    content: "🔒 Đăng nhập để xem";
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background: rgba(0, 0, 0, 0.7);
    color: white;
    padding: 6px 12px;
    border-radius: 8px;
}
</style>