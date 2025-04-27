<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useI18n } from 'vue-i18n'

defineProps<{ showDetail: boolean }>()

const router = useRouter()
const { locale } = useI18n()

const user = ref(JSON.parse(localStorage.getItem("user") || "{}"))
const name = ref(user.value?.fullName || "")
const currentLanguage = ref("Vietnamese")

function changeLanguage(lang: string) {
    locale.value = lang
    currentLanguage.value = lang === "en" ? "English" : "Vietnamese"
}

function logout() {
    localStorage.removeItem('user')
    user.value = null
    router.push('/')
}
</script>


<template>
    <div class="header d-flex justify-content-between align-items-center">
        <h1 :class="['logo text-primary', showDetail ? 'expanded' : 'collapsed']">
            TOT<span class="text-dark">Learn</span>
        </h1>

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
.logo {
    font-size: 2.2rem;
}

.logo.expanded {
    margin-left: 0;
}

.logo.collapsed {
    margin-left: 36px;
}
</style>