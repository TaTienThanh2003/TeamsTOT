<script setup lang="ts">
import TeacherItem from './TeacherItem.vue';

</script>

<template>
    <section id="page4" class="section-customer">
        <h1 class="section-title">
            {{ $t('home.page4.title') }}
        </h1>
        <h4 class="text-center section-subtitle">
            {{ $t('home.page4.description') }}
        </h4>

        <div class="row row-cols-1 row-cols-sm-2 row-cols-lg-5 g-4">
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"/>
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"/>
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"/>
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"/>
            <TeacherItem fullname="VÕ HOÀNG YẾN"
                image="https://storage.googleapis.com/a1aa/image/XWUbD4i3i_HDN4wMpfHgSlwoIuEVkAzNeH0nXuJ9mXM.jpg"/>
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