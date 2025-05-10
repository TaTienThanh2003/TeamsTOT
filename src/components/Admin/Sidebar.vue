<script setup lang="ts">
import { ref } from 'vue'


const activeTab = ref('overview')

const setActiveTab = (tabName: string) => {
    activeTab.value = tabName
}

const getIconStyle = (tabName: string) => {
    return {
        'font-variation-settings': `'FILL' ${activeTab.value === tabName ? 1 : 0}, 'wght' 400, 'GRAD' 0, 'opsz' 24`
    }
}
</script>

<template>
    <div class="sidebar expanded">
        <h1 class="logo text-warning mt-2">
            TOT<span class="text-white">Admin</span>
        </h1>
        <nav class="nav flex-column nav-pills">
            <a class="nav-link text-muted white mt-3" data-bs-toggle="pill" href="#overview"
                :class="{ active: activeTab === 'overview' }" @click="setActiveTab('overview')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('overview')">dashboard</span>
                <span class="nav-text">{{ $t('hv.overview') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#my-courses"
                :class="{ active: activeTab === 'my-courses' }" @click="setActiveTab('my-courses')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('my-courses')">menu_book</span>
                <span class="nav-text">Khóa học</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#my-members"
                :class="{ active: activeTab === 'my-members' }" @click="setActiveTab('my-members')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('my-members')">group</span>
                <span class="nav-text">Thành viên</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#schedule"
                :class="{ active: activeTab === 'schedule' }" @click="setActiveTab('schedule')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('schedule')">event</span>
                <span class="nav-text">{{ $t('hv.schedule') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#tasks"
                :class="{ active: activeTab === 'tasks' }" @click="setActiveTab('tasks')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('tasks')">assignment</span>
                <span class="nav-text">Bài tập</span>
            </a>

            <div class="px-3">
                <hr class="my-3 border-muted p-2">
            </div>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#revenue"
                :class="{ active: activeTab === 'revenue' }" @click="setActiveTab('revenue')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('revenue')">bar_chart</span>
                <span class="nav-text">Doanh thu</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#settings"
                :class="{ active: activeTab === 'settings' }" @click="setActiveTab('settings')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('settings')">settings</span>
                <span class="nav-text">Cài đặt</span>
            </a>
        </nav>
    </div>
</template>

<style scoped>
.logo {
    font-size: 2.2rem;
    text-align: center;
}

.sidebar {
    position: fixed;
    top: 0;
    left: 0;
    z-index: 1000;
    height: 100%;
    background: #6C63FF;
    transition: width 0.4s ease;
    overflow: hidden;
    width: 60px;
}

.sidebar.expanded {
    width: 220px;
}

.nav-link {
    display: flex;
    align-items: center;
    transition: padding 0.3s ease, margin-bottom 0.3s ease;
    margin-bottom: 1.6rem;
    padding-left: 0.5rem;
}

.nav-link.active {
    background-color: #e1dbf3;
}

.nav-link.active .nav-text {
    color: #000;
}

.nav-link.active .icon {
    color: #000 !important;
}

.sidebar.expanded .nav-link {
    margin-bottom: 1rem;
    padding-left: 1.8rem;
}

.icon {
    font-family: 'Material Symbols Outlined';
    font-size: 20px;
    line-height: 1;
    color: #fff;
}

.nav-text {
    margin-left: 6px;
    white-space: nowrap;
    overflow: hidden;
    opacity: 0;
    transform: translateX(-10px);
    transition:
        opacity 0.3s ease 0.1s,
        transform 0.3s ease 0.1s;
    display: inline-block;
    width: 0;
    color: #fff;
}

.sidebar.expanded .nav-text {
    opacity: 1;
    transform: translateX(0);
    width: auto;
    transition-delay: 0.2s;
}

.sidebar.collapsed .nav-link {
    justify-content: center;
}

.sidebar.collapsed .nav-text {
    opacity: 0;
    transform: translateX(-10px);
    width: 0;
    transition-delay: 0s;
}
</style>
