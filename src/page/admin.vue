<script setup lang="ts">
import Header from '@/components/HocVien/Header.vue';
import Courses from '@/components/Admin/Sesson/Courses/Courses.vue';
import Sidebar from '@/components/Admin/Sidebar.vue';
import { ref } from 'vue';
import Member from '@/components/Admin/Sesson/Member/Member.vue';
import Overview from '@/components/Admin/Overview/Overview.vue';
import Vocabulary from '@/components/Admin/Sesson/Vocabulary/Vocabulary.vue';

const showDetail = ref(true);
const activeTab = ref('overview');

const setActiveTab = (tabName: string) => {
    activeTab.value = tabName;
};
</script>

<template>
    <Header />
    <div class="content d-flex">
        <Sidebar :active-tab="activeTab" @tab-change="setActiveTab" />
        <div :class="['main-content flex-grow-1 py-5', showDetail ? 'expanded' : 'collapsed']">
            <div class="tab-content px-5">
                <Overview v-if="activeTab === 'overview'" />
                <Courses v-if="activeTab === 'my-courses'" />
                <Member v-if="activeTab === 'my-members'" />
                <Vocabulary v-if="activeTab === 'vocabulary'" />
            </div>
        </div>
    </div>
</template>

<style scoped>
body {
    background-color: #F5F6FA;
}

.main-content {
    transition: margin-left 0.3s ease;
    width: 100%;
    padding: 20px;
    background: #fafafa;
    margin-top: 65px;
    height: calc(100vh - 65px);
    overflow-y: auto;
}

.main-content.expanded {
    margin-left: 220px;
}

.main-content.collapsed {
    margin-left: 60px;
}
</style>
