<script setup lang="ts">
import CourseItem from './CourseItem.vue'

</script>

<template>
    <section id="page3" class="section-customer">
        <h1 class="section-title">
            KHÓA HỌC
        </h1>

        <div class="d-flex flex-wrap justify-content-center gap-3">
            <!-- <div v-for="courses in c> ->c.title, c.img, c.des -->
            <CourseItem title="Khóa học Giao tiếp thực tế"
                image="https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg"
                :features="[
                    'Dành cho người mất gốc hoặc muốn cải thiện phản xạ nói.',
                    'Phương pháp phản xạ tự nhiên, thực hành ngay tại lớp.',
                    'Tự tin giao tiếp trong công việc và cuộc sống.'
                ]" />

            <CourseItem title="Khóa học Giao tiếp thực tế"
                image="https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg"
                :features="[
                    'Dành cho người mất gốc hoặc muốn cải thiện phản xạ nói.',
                    'Phương pháp phản xạ tự nhiên, thực hành ngay tại lớp.',
                    'Tự tin giao tiếp trong công việc và cuộc sống.'
                ]" />

            <CourseItem title="Khóa học Giao tiếp thực tế"
                image="https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg"
                :features="[
                    'Dành cho người mất gốc hoặc muốn cải thiện phản xạ nói.',
                    'Phương pháp phản xạ tự nhiên, thực hành ngay tại lớp.',
                    'Tự tin giao tiếp trong công việc và cuộc sống.'
                ]" />
        </div>
    </section>
</template>

<style scoped></style>
