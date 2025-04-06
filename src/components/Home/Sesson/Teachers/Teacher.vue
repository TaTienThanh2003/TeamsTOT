<script setup lang="ts">
import TeacherItem from './TeacherItem.vue';

</script>

<template>
    <section id="page4" class="section-customer">
        <h1 class="section-title">
            GIẢNG VIÊN TIÊU BIỂU
        </h1>
        <h4 class="text-center section-subtitle">
            Chúng tôi luôn giữ vững giá trị minh bạch, trách nhiệm và giao tiếp chặt chẽ <br />
            với học viên để mang lại trải nghiệm học tập tốt nhất.
        </h4>

        <div class="row row-cols-1 row-cols-sm-2 row-cols-lg-5 g-4">
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"
                des="TOIEC" />
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"
                des="TOIEC" />
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"
                des="TOIEC" />
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"
                des="TOIEC" />
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"
                des="TOIEC" />
        </div>
    </section>
</template>
<style scoped>
.section-title {
    margin-bottom: 2rem !important;
}

.section-subtitle {
    margin-bottom: 8rem;
}
</style>