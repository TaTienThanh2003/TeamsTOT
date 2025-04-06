<script setup lang="ts">
</script>

<template>
  <header class="navbar navbar-expand-lg fixed-top" style="background-color: #6C63FF;">
    <div class="container-fluid">
      <!-- Logo và Tên trung tâm -->
      <a class="navbar-brand ms-5" href="#">
        <img src="@/assets/images/logo.png" alt="Logo" class="d-inline-block align-text-top me-2" />
        <span class="font-weight-bold text-white" style="font-size: 1.25rem;">TRUNG TÂM TOT</span>
      </a>

      <!-- Menu điều hướng -->
      <div class="d-flex ms-auto">
        <ul class="navbar-nav mb-2 mb-lg-0">
          <li class="nav-item">
            <a class="nav-link text-white" href="#">Trang chủ</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#">Giới thiệu</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#">Khóa học</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#">Giảng viên</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#">Liên hệ</a>
          </li>
        </ul>

        <!-- Nút đăng nhập -->
        <a href="login.html" class="ms-3">
          <button class="btn btn-link text-white">
            <i class="fas fa-user-circle fs-2"></i>
          </button>
        </a>
      </div>
    </div>
  </header>
</template>
<style scoped>
.navbar-brand {
  display: flex;
  align-items: center;
}
</style>