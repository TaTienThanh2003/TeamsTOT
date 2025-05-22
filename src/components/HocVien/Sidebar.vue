<script setup lang="ts">
import { ref } from 'vue'

defineProps<{ showDetail: boolean }>()
const emit = defineEmits(['setTrue'])

const activeTab = ref('overview')

const setActiveTab = (tabName: string) => {
    activeTab.value = tabName
    emit('setTrue', true)
}

const getIconStyle = (tabName: string) => {
    return {
        'font-variation-settings': `'FILL' ${activeTab.value === tabName ? 1 : 0}, 'wght' 400, 'GRAD' 0, 'opsz' 24`
    }
}
</script>

<template>
    <div :class="['sidebar', showDetail ? 'expanded' : 'collapsed']">
        <nav class="nav flex-column nav-pills">
            <a class="nav-link text-muted white mt-2" data-bs-toggle="pill" href="#overview"
                :class="{ active: activeTab === 'overview' }" @click="setActiveTab('overview')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('overview')">space_dashboard</span>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.overview') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#my-courses"
                :class="{ active: activeTab === 'my-courses' }" @click="setActiveTab('my-courses')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('my-courses')">school</span>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.mycourse') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#my-teachers"
                :class="{ active: activeTab === 'my-teachers' }" @click="setActiveTab('my-teachers')">
                <span class="material-symbols-outlined icon"
                    :style="getIconStyle('my-teachers')">supervisor_account</span>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.myteacher') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#vocabulary"
                :class="{ active: activeTab === 'vocabulary' }" @click="setActiveTab('vocabulary')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('vocabulary')">translate</span>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.vocabulary') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#tasks"
                :class="{ active: activeTab === 'tasks' }" @click="setActiveTab('tasks')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('tasks')">edit_note</span>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.exercise') }}</span>
            </a>

            <div class="px-3">
                <hr class="my-3 border-muted p-2">
            </div>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#schedule"
                :class="{ active: activeTab === 'schedule' }" @click="setActiveTab('schedule')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('schedule')">calendar_month</span>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.schedule') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#user"
                :class="{ active: activeTab === 'user' }" @click="setActiveTab('user')">
                <span class="material-symbols-outlined icon" :style="getIconStyle('user')">manage_accounts</span>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.account') }}</span>
            </a>
        </nav>
    </div>
</template>

<style scoped>
.sidebar {
    position: fixed;
    top: 65px;
    left: 0;
    z-index: 1000;
    height: calc(100vh - 65px);
    background: #fff;
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

.sidebar.expanded .nav-link {
    margin-bottom: 1rem;
    padding-left: 1.8rem;
}

.nav-link.active {
    background-color: #5e53f5;
}

.nav-link.active .nav-text,
.nav-link.active .icon {
    color: #fff !important;
}

.icon {
    font-size: 22px;
    line-height: 1;
    color: #444;
    transition: color 0.3s ease;
}

.nav-text {
    margin-left: 6px;
    white-space: nowrap;
    overflow: hidden;
    opacity: 0;
    transform: translateX(-10px);
    transition: opacity 0.3s ease 0.1s, transform 0.3s ease 0.1s;
    display: inline-block;
    width: 0;
    color: #444;
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
