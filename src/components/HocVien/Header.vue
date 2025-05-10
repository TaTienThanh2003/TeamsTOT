<script lang="ts">

export default {
    data() {
        return {
            currentLanguage: "Vietnamese", // Ngôn ngữ mặc định
            user: localStorage.getItem("user"),
            name: user.fullName,
        };
    },
    methods: {
        changeLanguage(lang: string) {
            this.$i18n.locale = lang;
            if (lang === "en") {
                this.currentLanguage = "English";
            } else if (lang === "vi") {
                this.currentLanguage = "Vietnamese";
            }
        },
        logout() {
            // Xóa userId trong localStorage khi đăng xuất
            localStorage.removeItem('user');
            this.user = null; // Cập nhật lại userId sau khi logout
            this.$router.push('/'); // Điều hướng về trang chủ
        },
    },
};

const user = JSON.parse(localStorage.getItem("user") || "{}");
const userid = user.id;
</script>

<template>
    <div class="header d-flex justify-content-between align-items-center">
        <h1 class="logo text-primary">
            TOT<span class="text-dark">Learn</span>
        </h1>

        <!-- Menu & Search -->
        <div class="d-flex justify-content-center align-items-center flex-grow-1">
            <div class="search-bar input-group" style="max-width: 400px; flex-grow: 1;">
                <input class="form-control bg-light border-0 pl-4" placeholder="Search" type="text" />
                <div class="input-group-append">
                    <span class="input-group-text bg-light border-0">
                        <i class="fas fa-search text-muted"></i>
                    </span>
                </div>
            </div>
        </div>

        <!-- Thông báo và Thông tin người dùng -->
        <div class="d-flex align-items-center gap-4">
            <!-- Thông báo -->
            <div class="position-relative">
                <i class="fas fa-bell text-muted">
                    <span
                        class="notification-badge position-absolute top-0 start-100 translate-middle p-1 bg-danger border border-light rounded-circle"></span>
                </i>
            </div>

            <!-- Thông tin người dùng -->
            <div class="user-info d-flex align-items-center gap-3">
                <div class="dropdown" >
                    <button class="btn btn-light dropdown-toggle d-flex align-items-center" type="button"
                        id="languageDropdown" data-bs-toggle="dropdown" aria-expanded="false">
                        <span class="language text-muted">{{ currentLanguage }}</span>
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="languageDropdown">
                        <li><a class="dropdown-item" href="#" @click="changeLanguage('en')">English</a></li>
                        <li><a class="dropdown-item" href="#" @click="changeLanguage('vi')">Vietnamese</a></li>
                    </ul>
                </div>
                <div class="dropdown d-flex align-items-center">
                    <a href="#" id="userDropdown" class="d-flex align-items-center text-decoration-none"
                        data-bs-toggle="dropdown" aria-expanded="false">
                        <img alt="User avatar" class="avatar rounded-circle me-2" src="https://placehold.co/40x40"
                            style="width: 40px; height: 40px;" />
                        <div class="user-details text-muted">
                            <p class="user-name mb-0 font-weight-bold">{{ name }}</p>
                        </div>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="userDropdown">
                        <li><button class="dropdown-item" @click.prevent="logout">Đăng xuất</button></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
.header {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    z-index: 1050; /* Lớn hơn các nội dung khác */
    background-color: white;
}
.logo {
    font-size: 2.2rem;
}
.dropdown-menu {
  z-index: 1100;
  position: absolute
}
</style>