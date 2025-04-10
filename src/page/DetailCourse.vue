<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
</script>

<template>
    <Header />
    <div class="container">
        <!-- Tiêu đề và mô tả -->
        <div class="course-banner text-center">
            <h1 class="fs-3">Chinh phục TOEIC 700+ trong 30 ngày</h1>
            <p class="lead">Khóa học TOEIC toàn diện giúp bạn tăng điểm nhanh chóng với lộ trình rõ ràng, mẹo làm bài,
                và thực hành theo đề thi thật.</p>
        </div>

        <!-- Thông tin tổng quan -->
        <div class="row text-center mb-4">
            <div class="col-md-3"><strong>👥</strong> Hơn 5.000 học viên</div>
            <div class="col-md-3"><strong>📚</strong> 30 bài học chuyên sâu</div>
            <div class="col-md-3"><strong>⏰</strong> 20 giờ học hiệu quả</div>
            <div class="col-md-3"><strong>⭐️</strong> 4.9 / 5 (1.250 đánh giá)</div>
        </div>

        <!-- Trích dẫn truyền cảm hứng -->
        <div class="highlight">
            <p class="quote">"Bạn không cần giỏi tiếng Anh, bạn chỉ cần phương pháp đúng và luyện tập đều đặn."
                <br>– Giảng viên Lê Thảo, 950 TOEIC
            </p>
        </div>

        <!-- Bạn sẽ học được gì -->
        <h4 class="mb-3 fs-4">🚀 Sau khóa học bạn sẽ:</h4>
        <ul class="benefits">
            <li>Nắm vững chiến lược làm bài Listening & Reading</li>
            <li>Thành thạo 1000+ từ vựng TOEIC thường gặp</li>
            <li>Luyện tập với đề thi thật và phân tích đáp án</li>
            <li>Cải thiện điểm TOEIC lên 150–300 điểm</li>
        </ul>

        <!-- Preview nội dung -->
        <h4 class="mt-5 mb-4 fs-4">📋 Nội dung khóa học (Xem trước)</h4>
        <div class="card mb-3 p-3">
            <div class="d-flex justify-content-between">
                <div>
                    <p>Bài 1: TOEIC là gì? Tổng quan đề thi</p>
                    <small>🎥 Video - 6:00</small>
                </div>
                <a href="#" class="btn btn-outline-warning align-self-center">Xem miễn phí</a>
            </div>
        </div>
        <div class="card mb-3 p-3">
            <div class="d-flex justify-content-between">
                <div>
                    <p>Bài 2: Chiến lược làm Part 1 - Hình ảnh</p>
                    <small>🎥 Video - 8:20</small>
                </div>
                <a href="#" class="btn btn-outline-warning align-self-center">Xem miễn phí</a>
            </div>
        </div>

        <!-- Bài học bị khóa -->
        <div class="card mb-3 p-3 blurred-card">
            <p>Bài 3: Kỹ thuật nghe Part 2 - Hỏi đáp ngắn</p>
        </div>
        <div class="card mb-3 p-3 blurred-card">
            <p>Bài 4: Ngữ pháp trọng điểm trong TOEIC</p>
        </div>

        <!-- CTA -->
        <div class="text-center mt-5">
            <router-link class="btn btn-warning btn-lg" to="/login">🔓 Đăng nhập để học toàn bộ khóa
                TOEIC</router-link>
            <p class="mt-3">Chưa có tài khoản? <router-link class="text-primary" to="/signin">Đăng ký miễn
                    phí</router-link></p>
        </div>
    </div>
</template>

<style scoped>
.container {
    margin-top: 8rem;
    margin-bottom: 4rem;
}

.course-banner {
    background: linear-gradient(135deg, #0d6efd, #0056d2);
    color: white;
    padding: 40px;
    border-radius: 16px;
    margin-bottom: 30px;
}

.blurred-card {
    filter: blur(2px);
    pointer-events: none;
    position: relative;
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

.benefits li {
    margin-bottom: 10px;
}

.quote {
    font-style: italic;
    color: #555;
}

.highlight {
    background-color: #d4edda;
    padding: 10px 15px;
    border-left: 5px solid #28a745;
    border-radius: 6px;
    margin-bottom: 20px;
}
</style>