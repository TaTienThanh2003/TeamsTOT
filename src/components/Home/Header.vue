<script lang="ts">

export default {
  methods: {
    changeLanguage(lang: string) {
      this.$i18n.locale = lang
    }
  }
}

</script>
<template>
  <header class="navbar navbar-expand-lg fixed-top" style="background-color: #6C63FF;">
    <div class="container-fluid">
      <a class="navbar-brand ms-5" href="#">
        <img src="@/assets/images/logo.png" alt="Logo" class="d-inline-block align-text-top me-2" />
        <span class="font-weight-bold text-white" style="font-size: 1.25rem;">TRUNG TÂM TOT</span>
      </a>

      <!-- Menu điều hướng -->
      <div class="d-flex ms-auto">
        <ul class="navbar-nav mb-2 mb-lg-0">
          <li class="nav-item">
            <a class="nav-link text-white" href="#">{{ $t('home.home') }}</a>
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
      </div>
      <div class="lang-switch">
        <input type="radio" id="lang-vi" name="lang" value="vi" checked @change="changeLanguage('vi')" />
        <label for="lang-vi">VN</label>

        <input type="radio" id="lang-en" name="lang" value="en" @change="changeLanguage('en')" />
        <label for="lang-en">EN</label>
      </div>

      <!-- Nút đăng nhập -->
      <router-link to="/login" class="text-white" title="Đăng nhập">
        <i class="fas fa-sign-in-alt fa-lg"></i>
      </router-link>

    </div>
  </header>
</template>
<style scoped>
.navbar-brand,
.container-fluid {
  display: flex;
  align-items: center;
}

.lang-switch {
  display: inline-flex;
  background-color: #fff;
  border-radius: 999px;
  overflow: hidden;
  font-weight: 500;
  font-size: 0.9rem;
  margin: 0 1rem;
}

.lang-switch input[type="radio"] {
  display: none;
}

.lang-switch label {
  padding: 6px 16px;
  margin: 0;
  cursor: pointer;
  color: #6c757d;
  transition: all 0.3s ease;
}

.lang-switch input[type="radio"]:checked+label {
  background-color: #ffee00;
}
</style>