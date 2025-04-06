<script setup lang="ts">
</script>

<template>
    <div class="header d-flex justify-content-between align-items-center">
        <h2 class="text-primary font-weight-bold">
            TOT<span class="text-dark">Learn</span>
        </h2>

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
                <div class="dropdown">
                    <button class="btn btn-light dropdown-toggle d-flex align-items-center" type="button"
                        id="languageDropdown" data-bs-toggle="dropdown" aria-expanded="false">
                        <span class="language text-muted">Vietnamese</span>
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="languageDropdown">
                        <li><a class="dropdown-item" href="#" onclick="changeLanguage('English')">English</a></li>
                        <li><a class="dropdown-item" href="#" onclick="changeLanguage('Vietnamese')">Vietnamese</a></li>
                        <li><a class="dropdown-item" href="#" onclick="changeLanguage('French')">Français</a></li>
                    </ul>
                </div>
                <div class="dropdown d-flex align-items-center">
                    <a href="#" id="userDropdown" class="d-flex align-items-center text-decoration-none"
                        data-bs-toggle="dropdown" aria-expanded="false">
                        <img alt="User avatar" class="avatar rounded-circle me-2" src="https://placehold.co/40x40"
                            style="width: 40px; height: 40px;" />
                        <div class="user-details text-muted">
                            <p class="user-name mb-0 font-weight-bold">Moni Roy</p>
                        </div>
                    </a>
                    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="userDropdown">

                        <li><a class="dropdown-item" href="#">Đăng xuất</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>
