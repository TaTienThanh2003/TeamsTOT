<template>
    <div class="exercise-card d-flex align-items-center p-3 shadow-sm rounded mb-3">
        <img src="@/assets/images/nangtho.jpg" class="exercise-icon rounded-circle" alt="Bài tập 1">
        <div class="exercise-info ms-3">
            <h5 class="mb-1">{{ $t('hv.page5.exerice') }} 1: Ngữ pháp</h5>
            <a href="exercise1.pdf" class="exercise-link text-decoration-none" download>
                {{ $t('hv.page5.download') }}
            </a>
        </div>
    </div>
</template>