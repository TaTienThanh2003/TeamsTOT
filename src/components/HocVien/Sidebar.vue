<script setup lang="ts">
import { ref, watch } from 'vue'

defineProps<{ showDetail: boolean }>()
const emit = defineEmits(['setTrue'])

const activeTab = ref('overview')

const setActiveTab = (tabName: string) => {
    activeTab.value = tabName
    emit('setTrue', true)
}
</script>

<template>
    <div :class="['sidebar', showDetail ? 'expanded' : 'collapsed']">
        <nav class="nav flex-column nav-pills">
            <a class="nav-link text-muted white mt-2" data-bs-toggle="pill" href="#overview"
                :class="{ active: activeTab === 'overview' }" @click="setActiveTab('overview')">
                <i :class="['icon', activeTab === 'overview' ? 'fa-solid' : 'fa-regular', 'fa-font-awesome']"></i>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.overview') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#my-courses"
                :class="{ active: activeTab === 'my-courses' }" @click="setActiveTab('my-courses')">
                <i :class="['icon', activeTab === 'my-courses' ? 'fa-solid' : 'fa-regular', 'fa-folder']"></i>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.mycourse') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#my-teachers"
                :class="{ active: activeTab === 'my-teachers' }" @click="setActiveTab('my-teachers')">
                <i :class="['icon', activeTab === 'my-teachers' ? 'fa-solid' : 'fa-regular', 'fa-user']"></i>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.myteacher') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#schedule"
                :class="{ active: activeTab === 'schedule' }" @click="setActiveTab('schedule')">
                <i :class="['icon', activeTab === 'schedule' ? 'fa-solid' : 'fa-regular', 'fa-calendar']"></i>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.schedule') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#tasks"
                :class="{ active: activeTab === 'tasks' }" @click="setActiveTab('tasks')">
                <i :class="['icon', activeTab === 'tasks' ? 'fa-solid' : 'fa-regular', 'fa-clipboard']"></i>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.exercise') }}</span>
            </a>

            <div class="px-3">
                <hr class="my-3 border-muted p-2">
            </div>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#comments"
                :class="{ active: activeTab === 'comments' }" @click="setActiveTab('comments')">
                <i :class="['icon', activeTab === 'comments' ? 'fa-solid' : 'fa-regular', 'fa-comment-dots']"></i>
                <span class="nav-text" v-if="showDetail">{{ $t('hv.forum') }}</span>
            </a>

            <a class="nav-link text-muted white" data-bs-toggle="pill" href="#user"
                :class="{ active: activeTab === 'user' }" @click="setActiveTab('user')">
                <i :class="['icon', activeTab === 'user' ? 'fa-solid' : 'fa-regular', 'fa-circle-user']"></i>
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

.nav-link i {
    font-size: 18px;
    transition: transform 0.3s ease;
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