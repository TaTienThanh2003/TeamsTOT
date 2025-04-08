<script setup lang="ts">
</script>

<template>
    <nav class="nav flex-column nav-pills">
        <a class="nav-link mb-3 text-muted active white" data-bs-toggle="pill" href="#overview">
            <i class="icon fa-solid fa-font-awesome"></i>
            <span class="nav-text">{{ $t('hv.overview') }}</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#my-courses">
            <i class="icon fa-regular fa-folder"></i>
            <span class="nav-text">{{ $t('hv.mycourse') }}</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#my-teachers">
            <i class="icon fa-regular fa-user"></i>
            <span class="nav-text">{{ $t('hv.myteacher') }}</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#schedule">
            <i class="icon fa-regular fa-calendar"></i>
            <span class="nav-text">{{ $t('hv.schedule') }}</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#tasks">
            <i class="icon fa-regular fa-clipboard"></i>
            <span class="nav-text">{{ $t('hv.exercise') }}</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#sticky">
            <i class="icon fa-regular fa-clone"></i>
            <span class="nav-text">{{ $t('hv.note') }}</span>
        </a>
        <div class="px-3">
            <hr class="my-3 border-muted p-2">
        </div>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#gift">
            <i class="icon fa-regular fa-lightbulb"></i>
            <span class="nav-text">{{ $t('hv.offer') }}</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#comments">
            <i class="icon fa-regular fa-comment-dots"></i>
            <span class="nav-text">{{ $t('hv.forum') }}</span>
        </a>
        <a class="nav-link mb-3 text-muted white" data-bs-toggle="pill" href="#user">
            <i class="icon fa-regular fa-circle-user"></i>
            <span class="nav-text">{{ $t('hv.account') }}</span>
        </a>
    </nav>
</template>

<style scoped>
.nav-text {
    margin-left: 6px;
}
</style>
