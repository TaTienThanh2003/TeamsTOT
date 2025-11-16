<template>
    <div class="section-customer">
        <h2 class="section-title shine-text">KHÓA HỌC TRỰC TIẾP</h2>
        <div class="course-list-wrapper">
            <div v-for="(course, index) in coursesoff.slice(0, 4)" :key="index" class="course-card back-blue">
                <h3 class="course-title text-warning">{{ course.name }}</h3>
                <p class="course-time text-white">{{ course.time }} · {{ course.schedule }}</p>
                <p class="course-date text-white">
                    <span class="font-medium">Ngày khai giảng:</span>
                    <span class="text-blue-600 font-semibold">
                        {{ course.openingDate }}
                    </span>
                </p>
                <span class="course-status btn btn-warning" data-bs-toggle="modal" data-bs-target="#consultModal"  @click="selectedCourseName = course.name">
                    {{ course.status }}
                </span>
            </div>
        </div>
        <div class="mt-4 text-center">
            <RouterLink to="/detail-off" class="fs-5">
                Xem tất cả &rarr;
            </RouterLink>
        </div>
    </div>
    <EnrollModel :name="selectedCourseName" />
</template>
<script setup lang="ts">
import EnrollModel from '@/components/Model/EnrollModel.vue';
import i18n from '@/i18n';
import { getCourseByName, getCourseOff } from '@/services';
import { ref , onMounted } from 'vue';

const coursesoff = ref<any>([])
const selectedCourseName = ref('');
const locale = i18n.global.locale.toUpperCase();
const titleKey = `title${locale}`;
const formatDate = (dateStr: string): string => {
  if (!dateStr) return ''
  const [year, month, day] = dateStr.replace(/\//g, '-').split('-')
  return `${day}/${month}/${year}`
}
const showcoursesoff = async () => {
   try {
    const res = await getCourseOff()
    const resdata = res.data

    coursesoff.value = resdata.map((course: any) => ({
      id: course.id,
      name: course[titleKey],
      time: course.courseOff?.time || '',
      schedule: course.courseOff?.schedule || '',
      openingDate: formatDate(course.courseOff?.date || ''),
      status: course.courseOff?.status ? 'Tuyển sinh' : 'Dự kiến'
    }))
  } catch (error) {
    console.error('Lỗi khi lấy khóa học:', error)
  }
}
onMounted(() =>{
    showcoursesoff()
})
</script>
<style scoped>
.course-list-wrapper {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 1.5rem;
}

.course-card {
    padding: 1rem 1.25rem;
    border-radius: 1rem;
    max-width: 250px;
    width: 100%;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.08);
    text-align: center;
}

.course-title {
    font-weight: 600;
    font-size: 1rem;
    margin-bottom: 0.5rem;
}

.course-time {
    font-size: 0.95rem;
}

.course-date {
    margin-top: 0.5rem;
    font-size: 0.9rem;
}

.course-status {
    display: inline-block;
    margin-top: 0.75rem;
    padding: 0.25rem 0.75rem;
    border-radius: 999px;
    font-size: 0.75rem;
    font-weight: 500;
}
</style>