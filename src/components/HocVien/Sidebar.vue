<script setup lang="ts">
</script>

<template>
    <nav class="nav flex-column nav-pills">
        <a class="nav-link mb-3 text-muted active white" data-bs-toggle="pill" href="#overview">
            <i class="icon fa-solid fa-star"></i>
            <span class="nav-text">Tổng quan</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#my-courses">
            <i class="icon fa-regular fa-folder"></i>
            <span class="nav-text">Khóa học của tôi</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#my-teachers">
            <i class="icon fa-regular fa-user"></i>
            <span class="nav-text">Giáo viên của tôi</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#schedule">
            <i class="icon fa-regular fa-calendar"></i>
            <span class="nav-text">Lịch học</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#tasks">
            <i class="icon fa-regular fa-clipboard"></i>
            <span class="nav-text">Bài tập &amp; Kiểm tra</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#sticky">
            <i class="icon fa-regular fa-note-sticky"></i>
            <span class="nav-text">Ghi chú</span>
        </a>
        <div class="px-3">
            <hr class="my-3 border-muted p-2">
        </div>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#gift">
            <i class="icon fa-regular fa-rectangle-list"></i>
            <span class="nav-text">Ưu đãi</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#comments">
            <i class="icon fa-regular fa-comment-dots"></i>
            <span class="nav-text">Diễn đàn</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#user">
            <i class="icon fa-regular fa-circle-user"></i>
            <span class="nav-text">Tài khoản</span>
        </a>
    </nav>
</template>

<style scoped>
.nav-text {
    margin-left: 6px;
}
</style>
