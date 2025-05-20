<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import AddCourse from './Model/AddCourse.vue';
import EditCourse from './Model/EditCourse.vue';
import DetailCourse from './Model/DetailCourse.vue';
import { translateViEn, getCourses, getLessons, deleteCourse } from '@/services';
import i18n from '@/i18n';
import AddSection from './Model/AddSection.vue';

const showModal = ref(false)
const showEditModal = ref(false)
const showSection = ref(false)
const showLesson = ref(false)
const courses = ref<any>([])
const rawCourses = ref<any[]>([])
const courseToEdit = ref(null)
const selectedCourse = ref(null)
const expandedCourses = ref<Set<number>>(new Set())
const expandedSections = ref<Set<number>>(new Set())
const selectedCourseId = ref<number | undefined>(undefined);

const locale = i18n.global.locale.toUpperCase();
const titleKey = `title${locale}`;
const desKey = `des${locale}`

// await translateViEn("Xin chào");
const showCourse = async () => {
    try {
        const res = await getCourses();
        const resdata = res.data;
        rawCourses.value = res.data;
        courses.value = await Promise.all(resdata.map(async (course: any) => {
            const sectionsRes = await getLessons(course.id);
            const sectionsCount = sectionsRes.data.length;

            return {
                id: course.id,
                title: course[titleKey],
                des: course[desKey],
                countDay: course.countDay,
                price: course.price,
                mode: course.mode,
                img: course.img,
                sections: [],
                sectionsCount: sectionsCount
            };
        }));
    } catch (error) {
        console.log("Lỗi lấy api course:", error);
    }
}

const getSectionsByCourseId = async (courseId: number) => {
    try {
        const res = await getLessons(courseId);
        const resdata = res.data;
        const courseIndex = courses.value.findIndex((c: any) => c.id === courseId);
        if (courseIndex !== -1) {
            courses.value[courseIndex].sections = await Promise.all(resdata.map(async (section: any) => {
                // Lấy số lượng lessons từ section.lessons
                const lessonsCount = section.lessons ? section.lessons.length : 0;

                return {
                    id: section.id,
                    title: section[titleKey],
                    des: section[desKey],
                    lessons: [],
                    lessonsCount: lessonsCount
                };
            }));
        }
    } catch (error) {
        console.log("Lỗi lấy sections:", error);
    }
}

const getLessonsBySectionId = async (courseId: number, sectionId: number) => {
    try {
        const res = await getLessons(courseId);
        const resdata = res.data;
        const courseIndex = courses.value.findIndex((c: any) => c.id === courseId);
        if (courseIndex !== -1) {
            const sectionIndex = courses.value[courseIndex].sections.findIndex((s: any) => s.id === sectionId);
            if (sectionIndex !== -1) {
                // Tìm section trong response data
                const sectionData = resdata.find((section: any) => section.id === sectionId);
                if (sectionData && sectionData.lessons) {
                    courses.value[courseIndex].sections[sectionIndex].lessons = sectionData.lessons.map((lesson: any) => ({
                        id: lesson.id,
                        title: lesson.titleVI,
                        des: lesson.desVI,
                        videoUrl: lesson.video_url,
                        completed: lesson.completed
                    }));
                }
            }
        }
    } catch (error) {
        console.log("Lỗi lấy lessons:", error);
    }
}
const delCourse = async (courseid: number) => {
    try {
        await deleteCourse(courseid)
        showCourse()
    } catch (error) {

    }
}
const toggleCourse = async (courseId: number) => {
    if (expandedCourses.value.has(courseId)) {
        expandedCourses.value.delete(courseId);
    } else {
        expandedCourses.value.add(courseId);
        await getSectionsByCourseId(courseId);
    }
}

const toggleSection = async (courseId: number, sectionId: number) => {
    if (expandedSections.value.has(sectionId)) {
        expandedSections.value.delete(sectionId);
    } else {
        expandedSections.value.add(sectionId);
        await getLessonsBySectionId(courseId, sectionId);
    }
}

const openEditModal = (courseId: number) => {
    const course = rawCourses.value.find(c => c.id === courseId);
    if (course) {
        selectedCourse.value = { ...course };  // truyền nguyên object gốc
        showEditModal.value = true;
    }
}
const openAddSection = (courseId: number) => {
    selectedCourseId.value = courseId;
    console.log("selectedCourseId:", selectedCourseId);
}
onMounted(() => {
    showCourse();
})
</script>
<template>
    <div class="tab-pane fade active" id="my-courses">
        <h4 class="fs-4 text-center fw-bold ">QUẢN LÝ KHÓA HỌC</h4>
        <div class="mt-2">
            <button v-if="!showModal" @click="showModal = true, showSection = false, showLesson = false"
                class="btn btn-outline-primary">
                + Thêm khóa học
            </button>
            <AddCourse v-if="showModal" :showModal="showModal" @cancel="showModal = false; courseToEdit = null"
                @refresh="showCourse" />
            <EditCourse v-if="showEditModal" :showEditModal="showEditModal" :course="selectedCourse"
                @cancel="() => showEditModal = false" />
        </div>

        <table class="table table-bordered mt-4">
            <thead class="table-light">
                <tr>
                    <th style="width: 40%;">Tên</th>
                    <th style="width: 15%;">Số mục</th>
                    <th style="width: 15%;">Hành động</th>
                </tr>
            </thead>
            <tbody>
                <template v-for="course in courses" :key="course.id">
                    <!-- Course -->
                    <tr class="table-primary">
                        <td>
                            <div class="d-flex justify-between">
                                {{ course.title }}
                                <button class="btn btn-sm btn-link" @click="toggleCourse(course.id)">
                                    <i
                                        :class="['fa', expandedCourses.has(course.id) ? 'fa-chevron-up' : 'fa-chevron-down']"></i>
                                </button>
                            </div>
                        </td>
                        <td>{{ course.sectionsCount || 0 }}</td>
                        <td>
                            <button class="btn btn-sm btn-outline-dark mx-1" data-bs-toggle="modal"
                                data-bs-target="#courseDetailModal" title="Chi tiết"
                                @click="selectedCourseId = course.id">
                                <i class="fa fa-eye"></i>
                            </button>
                            <button class="btn btn-sm btn-outline-success mx-1" v-if="!showEditModal"
                                @click="openEditModal(course.id), showEditModal = true, showSection = false, showLesson = false"
                                title="Sửa">
                                <i class="fa fa-edit"></i>
                            </button>
                            <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa"
                                @click="delCourse(course.id)">
                                <i class="fa fa-trash"></i>
                            </button>
                        </td>
                    </tr>

                    <!-- Sections -->
                    <template v-if="expandedCourses.has(course.id)">
                        <template v-for="section in course.sections" :key="section.id">
                            <tr class="table-secondary">
                                <td class="ps-4">
                                    <div class="d-flex justify-between">
                                        {{ section.title }}
                                        <button class="btn btn-sm btn-link"
                                            @click="toggleSection(course.id, section.id)">
                                            <i
                                                :class="['fa', expandedSections.has(section.id) ? 'fa-chevron-up' : 'fa-chevron-down']"></i>
                                        </button>
                                    </div>
                                </td>
                                <td>{{ section.lessonsCount || 0 }}</td>
                                <td>
                                    <button class="btn btn-sm btn-outline-success mx-1" data-bs-toggle="modal"
                                        data-bs-target="#addSectionlModal" title="Sửa">
                                        <i class="fa fa-edit"></i>
                                    </button>
                                    <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
                                        <i class="fa fa-trash"></i>
                                    </button>
                                </td>
                            </tr>
                            <!-- Lessons -->
                            <template v-if="expandedSections.has(section.id)">
                                <tr v-for="lesson in section.lessons" :key="lesson.id">
                                    <td class="ps-5">{{ lesson.title }}</td>
                                    <td>—</td>
                                    <td>
                                        <button class="btn btn-sm btn-outline-success mx-1" title="Sửa">
                                            <i class="fa fa-edit"></i>
                                        </button>
                                        <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
                                            <i class="fa fa-trash"></i>
                                        </button>
                                    </td>
                                </tr>
                                <!-- Lesson thêm -->
                                <tr>
                                    <td class="ps-5">
                                        <div class="d-flex justify-between">
                                            Bài giảng khác
                                            <button class="btn btn-sm btn-link">
                                                <i class="fa fa-plus"></i>
                                            </button>
                                        </div>
                                    </td>
                                    <td>—</td>
                                    <td>—</td>
                                </tr>

                            </template>
                            
                        </template>
                        <!-- Section thêm (nếu có) -->
                        <tr class="table-secondary">
                            <td class="ps-4">
                                <div class="d-flex justify-between">
                                    Chuyên phần khác
                                    <button @click="selectedCourseId = course.id" class="btn btn-sm btn-link" data-bs-toggle="modal"
                                        data-bs-target="#addSectionlModal">
                                        <i class="fa fa-plus"></i>
                                    </button>
                                </div>
                            </td>
                            <td>—</td>
                            <td>—</td>
                        </tr>
                    </template>
                </template>
                <AddSection :courses_id="selectedCourseId" @refresh="showCourse" />
                <DetailCourse :courseId="selectedCourseId" />
            </tbody>
        </table>
    </div>
</template>
<style scoped>
body {
    background-color: #f3f4ff;
}

.section-header {
    background-color: #4b3fb3;
    color: white;
    padding: 1rem;
    border-radius: 10px 10px 0 0;
}

.form-section {
    background: white;
    padding: 2rem;
    border-radius: 0 0 10px 10px;
    margin-bottom: 2rem;
}

.btn-submit {
    background-color: #4b3fb3;
    color: white;
}

.btn-submit:hover {
    background-color: #3a32a3;
}
</style>