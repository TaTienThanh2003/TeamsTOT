<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import PayModel from '@/components/Model/payModel.vue';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import { getCourses, getLessons, addCarts } from '@/services';
import DetailItem from '@/components/Home/Detail/DetailItem.vue';
import Courses from '@/components/HocVien/Sesson/MyCourses/Courses.vue';

const router = useRoute();
const showModal = ref(false);
const selectedOption = ref('');
const isLogin = ref(false);
const lessons = ref<any>([]);
const id = parseInt(router.params.id as string);

const showLessons = async () => {
    try {
        const res = await getLessons(id);
        const resdata = res.data;
        console.log(resdata);
        lessons.value = resdata.slice(0, 2).map((lesson: any) => ({
            title: lesson.title,
        }));
    } catch (err: any) {
        console.log("Lỗi api khóa học" + err)
    }
};

const addtoCarts = async () => {
    try {
        const res = await addCarts(1, id);
        console.log(res);
    } catch (err: any) {
        console.log("Lỗi thêm vào giỏ hàng" + err)
    }
}
onMounted(() => {
    showLessons();
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
            <!-- Cột trái: Nội dung khóa học -->
            <div class="col-md-8">
                <!-- ✅ Sau khóa học bạn sẽ -->
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

                <button v-if="!isLogin" class="btn btn-cart mt-3" @click="addtoCarts">
                    <i class="fa-solid fa-cart-plus me-2"></i>Thêm vào giỏ hàng
                </button>

                <h4 class="mt-5 mb-4 fs-4 font-blue">Nội dung khóa học (Xem trước)</h4>

                <!-- Preview 2 bài miễn phí -->
                <DetailItem v-for="lesson in lessons" :key="id" :title="lesson.title" />

                <!-- Các bài bị khoá -->
                <div class="card mb-3 p-3 blurred-card">
                    <p>Bài 3: Kỹ thuật nghe Part 2 - Hỏi đáp ngắn</p>
                </div>
                <div class="card mb-3 p-3 blurred-card">
                    <p>Bài 4: Ngữ pháp trọng điểm trong TOEIC</p>
                </div>
                <div class="card p-3">
                    <h6 class="mb-2">❓ Cần hỗ trợ?</h6>
                    <p class="mb-1">📞 0901.123.987</p>
                    <p class="mb-0">📧 support@toeic.vn</p>
                </div>
            </div>

            <!-- Cột phải: Thông tin & Thanh toán -->
            <div class="col-md-4">
                <div class="card p-4 shadow-sm mb-4">
                    <div class="mb-3">
                        <iframe class="w-100 rounded" style="aspect-ratio: 16/9"
                            src="https://www.youtube.com/embed/md3HfH0SWOI?si=Jz-ce3qM3NhZXoc7"
                            title="Giới thiệu khóa học TOEIC" frameborder="0"
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                            allowfullscreen></iframe>
                    </div>

                    <div class="form-check mt-3">
                        <input class="form-check-input" type="radio" value="video" v-model="selectedOption"
                            id="optionVideo">
                        <label class="form-check-label" for="optionVideo">
                            Học video (giá: 499.000đ)
                        </label>
                    </div>
                    <div v-if="selectedOption === 'video'" class="mt-3 custom-info-box">
                        <p class="mb-1"><i class="fas fa-play-circle text-white me-2"></i> Xem video mọi lúc, mọi nơi
                        </p>
                        <p class="mb-1"><i class="fas fa-tachometer-alt text-white me-2"></i> Học theo tốc độ cá nhân
                        </p>
                        <p class="mb-0"><i class="fas fa-infinity text-white me-2"></i> Truy cập trọn đời vào nội dung
                        </p>
                    </div>

                    <div class="form-check mt-2">
                        <input class="form-check-input" type="radio" value="class" v-model="selectedOption"
                            id="optionClass">
                        <label class="form-check-label" for="optionClass">
                            Học theo lớp (giá: 1.200.000đ) <br />
                            <small class="text-primary">→ Bao gồm video miễn phí</small>
                        </label>
                    </div>
                    <div v-if="selectedOption === 'class'" class="mt-3 custom-info-box">
                        <p class="mb-1">
                            <i class="fas fa-user-check text-white me-2"></i>
                            Bạn sẽ được <strong>tự động xếp vào lớp phù hợp</strong>
                        </p>
                        <p class="mb-1">
                            <i class="fas fa-users text-white me-2"></i>
                            Mỗi lớp tối đa <strong>10 học viên</strong>
                        </p>
                        <p class="mb-0">
                            <i class="fas fa-calendar-alt text-white me-2"></i>
                            Sau khi được xếp lớp, bạn sẽ nhận lịch học & danh sách giáo viên
                        </p>
                    </div>


                    <button class="btn btn-warning btn-lg w-100 mt-4" :disabled="!selectedOption"
                        @click="showModal = true">
                        <i class="fas fa-credit-card me-2"></i>
                        Tiến hành thanh toán
                    </button>
                </div>

            </div>
        </div>
        <!-- Modal thanh toán -->
        <PayModel v-if="showModal" :show="showModal" @close="showModal = false" />
    </div>
</template>

<style scoped>
.container {
    margin-top: 6rem !important;
}

.course-banner {
    background: linear-gradient(135deg, #610dfd, #2e00d2);
    color: white;
    padding: 40px;
    border-radius: 16px;
    margin-bottom: 30px;
}
.btn-cart {
    border: 1px solid #6C63FF;
    color: #6C63FF;
}

.btn-cart:hover {
    background-color: #6C63FF;
    color: #fff;
}

.custom-info-box {
    background-color: #6C63FF;
    color: white;
    border-radius: 10px;
    padding: 16px;
    font-size: 0.95rem;
}


.benefits {
    list-style: none;
    padding-left: 0;
}

.benefits li {
    margin-bottom: 12px;
}

.blurred-card {
    filter: blur(2px);
    pointer-events: none;
    position: relative;
}

i {
    width: 1.25rem;
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