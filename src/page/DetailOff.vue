<template>
    <Header />
    <div class="container mt-5">
        <div class="course-banner text-center py-4">
            <h1 class="fs-2">Học tại trung tâm</h1>
            <p class="lead mx-auto" style="max-width: 700px;">
                Trải nghiệm môi trường học tập hiện đại và chuyên nghiệp cùng đội ngũ giáo viên giàu kinh nghiệm.
            </p>
        </div>
        <div class="row">
            <div class="col-md-8">
                <section class="mb-4">
                    <p class="mt-3">
                        Các khóa học tiếng Anh trực tiếp được thiết kế phù hợp với nhiều đối tượng – từ người mới bắt
                        đầu đến người học nâng cao.
                        Với hình thức học cùng giáo viên, bạn sẽ được hướng dẫn chi tiết theo lộ trình rõ ràng, tăng khả
                        năng tương tác và tiếp thu.
                    </p>
                    <p>
                        Lớp học diễn ra theo giờ cố định giúp duy trì kỷ luật học tập. Dù bạn đang luyện thi chứng chỉ,
                        nâng cao giao tiếp hay cần tiếng Anh cho công việc, các khóa học sẽ giúp bạn tiến bộ nhanh
                        chóng.
                    </p>
                </section>
                <p class="mb-4 fs-4 font-blue"> Lịch khai giảng</p>
                <div class="table-responsive">
                    <table class="table table-bordered table-hover align-middle text-center shadow-sm rounded">
                        <thead class="table-light">
                            <tr>
                                <th>Tên Khóa Học</th>
                                <th>Giờ Học</th>
                                <th>Lịch Học</th>
                                <th>Ngày Khai Giảng</th>
                                <th>Tình Trạng</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="course in courses" :key="course.name" @click="selectedCourse = course"
                                style="cursor: pointer;">
                                <td class="fw-semibold">{{ course.name }}</td>
                                <td>{{ course.time }}</td>
                                <td>{{ course.schedule }}</td>
                                <td>{{ course.openingDate }}</td>
                                <td>
                                    <span>{{ course.status }}</span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <!-- GIỚI THIỆU -->
                <div class="mt-4">
                    <h5 class="text-primary fs-4 mb-2">Lợi ích khi tham gia khóa học:</h5>
                    <ul>
                        <li><i class="fas fa-check font-blue me-2"></i> Học cùng giáo viên nhiều kinh
                            nghiệm</li>
                        <li><i class="fas fa-check font-blue me-2"></i> Tương tác trực tiếp, luyện phản xạ
                            nhanh</li>
                        <li><i class="fas fa-check font-blue me-2"></i> Giáo trình phù hợp trình độ từng
                            học viên</li>
                        <li><i class="fas fa-check font-blue me-2"></i> Môi trường học kỷ luật, tạo động
                            lực</li>
                        <li><i class="fas fa-check font-blue me-2"></i> Có thể học từ xa qua nền tảng trực
                            tuyến</li>
                        <li><i class="fas fa-check font-blue me-2"></i> Cam kết đồng hành xuyên suốt khóa
                            học</li>
                    </ul>
                    <div class="mt-4">
                        <strong class="fs-5">Lưu ý:</strong>
                        <ul class="ps-3 text-secondary">
                            <li class="mb-1">
                                Học viên nên dùng laptop hoặc máy tính có webcam.
                            </li>
                            <li>
                                Sau khi đăng ký, đội ngũ tư vấn sẽ liên hệ hỗ trợ xếp lớp.
                            </li>
                        </ul>
                    </div>
                </div>
                <TeacherReview />
            </div>

            <div class="col-md-4">
                <div class="card p-4 sticky-top shadow rounded-4 border-0 mb-4" style="top: 5rem;">

                    <!-- Video -->
                    <div class="mb-3 ratio ratio-16x9 rounded overflow-hidden">
                        <iframe class="w-100 h-100" src="https://www.youtube.com/embed/md3HfH0SWOI?si=Jz-ce3qM3NhZXoc7"
                            title="Giới thiệu khóa học TOEIC" frameborder="0"
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
                            allowfullscreen>
                        </iframe>
                    </div>

                    <!-- Nội dung -->
                    <div v-if="selectedCourse">
                        <h3 class="text-danger fw-bold fs-5 mb-3">
                            8,600,000đ
                            <span class="text-muted fs-6 ms-2 text-decoration-line-through">10,500,000đ</span>
                        </h3>

                        <button class="btn btn-primary btn-lg w-100 mb-2">Thêm vào giỏ hàng</button>
                        <button class="btn btn-outline-primary btn-lg w-100 mb-3" data-bs-toggle="modal"
                            data-bs-target="#consultModal">Đăng ký ngay</button>
                        <h5 class="fs-5 mb-3 font-blue">{{ selectedCourse.name }}</h5>
                        <ul class="mb-3">
                            <li class="mb-2">
                                <strong>Giờ học:</strong> {{ selectedCourse.time }}
                            </li>
                            <li class="mb-2">
                                <strong>Lịch học:</strong> {{ selectedCourse.schedule }}
                            </li>
                            <li class="mb-2">
                                <strong>Khai giảng:</strong> {{ selectedCourse.openingDate }}
                            </li>
                        </ul>

                        <div class="border p-3 rounded mb-2">
                            <p class="mb-1 text-muted small">LETLEARNNOW đã được áp dụng</p>
                        </div>
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="Nhập mã giảm giá">
                            <button class="btn btn-primary">Áp dụng</button>
                        </div>
                    </div>

                    <div v-else class="text-center py-4">
                        <i class="fas fa-info-circle fa-2x mb-2"></i>
                        <p class="mb-0">Vui lòng chọn một khóa học để xem thông tin và đăng ký.</p>
                    </div>


                </div>
            </div>
            <EnrollModel />
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Header from '@/components/Home/Header.vue';
import TeacherReview from '@/components/Home/Detail/TeacherReview.vue';
import EnrollModel from '@/components/Model/EnrollModel.vue';

const selectedCourse = ref<any>(null)
const showModal = ref(false);

const courses = [
    {
        name: 'Nền tảng TOEIC',
        time: '20h15–21h45',
        schedule: 'Thứ 2, 4, 6',
        openingDate: '05/08/2024',
        status: 'Tuyển sinh',
    },
    {
        name: 'TOEIC L&R - 450+',
        time: '18h30–20h00',
        schedule: 'Thứ 3, 5',
        openingDate: '22/08/2024',
        status: 'Tuyển sinh',
    },
    {
        name: 'TOEIC S&W - Cơ bản',
        time: '20h15–21h45',
        schedule: 'Thứ 2, 4',
        openingDate: '07/08/2024',
        status: 'Tuyển sinh',
    },
    {
        name: 'TOEIC L&R - 650+',
        time: '20h15–21h45',
        schedule: 'Thứ 3, 6',
        openingDate: '30/08/2024',
        status: 'Dự kiến',
    },
    {
        name: 'TOEIC S&W - Nâng cao',
        time: '20h15–21h45',
        schedule: 'Thứ 6',
        openingDate: '23/08/2024',
        status: 'Dự kiến',
    },
];
</script>

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
</style>
