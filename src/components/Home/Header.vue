<script lang="ts">
export default {
  props: {
    isShow: {
      type: Boolean,
      default: false,
    },
    hasRegistered: {
      type: Boolean,
      default: true,
    },
  },
  data() {
    return {
      user: localStorage.getItem("user"),
    };
  },
  methods: {
    changeLanguage(lang: string) {
      this.$i18n.locale = lang;
    },
    logout() {
      localStorage.removeItem('user');
      this.user = null;
      this.$router.push('/login');
    },
  },
};
</script>

<template>
  <header class="navbar navbar-expand-lg fixed-top px-5" style="background-color: #6C63FF;">
    <div class="container-fluid">
      <router-link to="/" class="navbar-brand">
        <img src="@/assets/images/logo.png" alt="Logo" class="d-inline-block align-text-top me-2" />
        <span class="font-weight-bold text-white" style="font-size: 1.25rem;">TRUNG TÂM TOT</span>
      </router-link>

      <!-- Menu điều hướng -->
      <div class="d-flex ms-auto text-uppercase" v-if="isShow">
        <ul class="navbar-nav mb-2 mb-lg-0">
          <li class="nav-item">
            <a class="nav-link text-white" href="#page1">{{ $t('home.home') }}</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#page2">{{ $t('home.introduce') }}</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#page3">{{ $t('home.course') }}</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#page4">{{ $t('home.lecturer') }}</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-white" href="#page5">{{ $t('home.contact') }}</a>
          </li>
        </ul>
      </div>

      <div class="ms-auto  d-flex align-items-center gap-3">
        <div class="lang-switch">
          <input type="radio" id="lang-vi" name="lang" value="vi" checked @change="changeLanguage('vi')" />
          <label for="lang-vi">VN</label>

          <input type="radio" id="lang-en" name="lang" value="en" @change="changeLanguage('en')" />
          <label for="lang-en">EN</label>
        </div>

        <!-- Kiểm tra userId để hiển thị icon giỏ hàng và dropdown thông tin người dùng -->
        <template v-if="user">
          <router-link to="/cart" class="icon-circles">
            <i class="fas fa-shopping-cart text-white fs-5"></i>
          </router-link>
          <div class="dropdown">
            <button class="btn icon-circles dropdown-toggle" type="button" id="dropdownUser" data-bs-toggle="dropdown"
              aria-expanded="false">
              <i class="fa-solid fa-user text-white fs-5"></i>
            </button>

            <ul class="dropdown-menu dropdown-menu-end mt-2" aria-labelledby="dropdownUser">
              <li v-if="hasRegistered">
                <router-link class="dropdown-item" to="/hocvien">
                  Tài khoản học viên
                </router-link>
                <router-link class="dropdown-item" to="/history">
                  Lịch sử thanh toán
                </router-link>
                <router-link class="dropdown-item" to="/hocvien">
                  Hồ sơ của tôi
                </router-link>
                <hr class="dropdown-divider" />

                <a class="dropdown-item text-danger" href="#" @click.prevent="logout">
                  <i class="fa-solid fa-right-from-bracket me-2"></i> Đăng xuất
                </a>
              </li>
            </ul>
          </div>
        </template>

        <!-- Nếu không có userId, hiển thị icon đăng nhập -->
        <template v-else>
          <router-link to="/login" class="text-white" title="Đăng nhập">
            <i class="fas fa-sign-in-alt fa-lg"></i>
          </router-link>
        </template>
      </div>
    </div>
  </header>
</template>

<style scoped>
.navbar-brand,
.container-fluid {
  display: flex;
  align-items: center;
}

.nav-item {
  margin-right: 1rem;
  font-weight: 500;
}

.nav-link:hover {
  color: #ffee00 !important;
}

.lang-switch {
  display: inline-flex;
  background-color: #fff;
  border-radius: 999px;
  overflow: hidden;
  font-weight: 500;
  font-size: 0.9rem;
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

.btn-check:checked+.btn,
.btn.active,
.btn.show,
.btn:first-child:active,
:not(.btn-check)+.btn:active {
  border: none !important;
}

.dropdown-toggle::after {
  display: none;
}

.icon-circles i:hover {
  color: #ffee00 !important;
}
</style>
