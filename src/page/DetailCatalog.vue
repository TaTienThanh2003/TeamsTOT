<script setup lang="ts">
import { ref, onMounted } from 'vue';
import Header from '@/components/Home/Header.vue';
import i18n from '@/i18n';
import { getCatalogs, getCourseByCatalogs, getCourses } from '@/services';
import CourseItem from '@/components/Home/Sesson/Courses/CourseItem.vue';
import InTroOff from '@/components/Home/Sesson/InTroOff.vue';
import Footer from '@/components/Home/Footer.vue';
import { useRoute } from 'vue-router';
const courses = ref<any[]>([]);
const route = useRoute();
const catalogId = parseInt(route.params.id as string);
const catalogDes = ref<string | null>(null);
const activeTabNum = ref(1);
const locale = i18n.global.locale.toUpperCase();
const fetchCatalogInfo = async (id: number) => {
    try {
        const catalogs = (await getCatalogs()).data;
        const desKey = `des${locale}`;

        const found = catalogs.find((c: any) => c.id === id);
        if (found) {
            catalogDes.value = found[desKey];
        }
    } catch (err) {
        console.error('Lỗi khi lấy mô tả catalog:', err);
    }
};
const showCoursebyCatalog = async (id: number, num: number) => {
    try {
        const res = await getCourseByCatalogs(id, num);
        const resdata = res.data;

        const nameKey = `title${locale}`;
        const desKey = `des${locale}`;

        courses.value = resdata.map((course: any) => ({
            id: course.id,
            title: course[nameKey],
            image: course.img,
            features: course[desKey]?.split('. ') || [],
        }));
    } catch (err: any) {
        console.log("Lỗi API khóa học: " + err);
    }
};
onMounted(() => {
    fetchCatalogInfo(catalogId);
    showCoursebyCatalog(catalogId, activeTabNum.value);
    const tabEl = document.getElementById('pills-tab');

    tabEl?.addEventListener('shown.bs.tab', (event: any) => {
        // event.target là tab mới active (button.nav-link)
        const targetId = event.target.getAttribute('data-bs-target'); // vd: '#pills-step1'

        switch (targetId) {
            case '#pills-step1':
                activeTabNum.value = 1;
                break;
            case '#pills-step2':
                activeTabNum.value = 2;
                break;
            case '#pills-step3':
                activeTabNum.value = 3;
                break;
            case '#pills-step4':
                activeTabNum.value = 4;
                break;
        }
        showCoursebyCatalog(catalogId, activeTabNum.value);
    });
});
</script>

<template>
    <Header />
    <div class="container">
        <!-- Giới thiệu TOEIC -->
        <div class="mb-5">
            <h2 class="section-title fs-2">LỘ TRÌNH HỌC ĐẦY ĐỦ</h2>
            <p>{{ catalogDes }}</p>
            <p>
                Dưới đây là lộ trình học TOEIC do TOT thiết kế dành cho người mới bắt đầu hoặc muốn cải thiện điểm số,
                được chia thành các chặng phù hợp với từng trình độ.
            </p>
            <p class="fst-italic text-warning">
                Các khóa học luôn được cập nhật và cải tiến theo định dạng đề thi mới nhất.
            </p>
        </div>

        <!-- Tabs các chặng học -->
        <div class="">
            <h2 class="mb-5 text-center section-title fs-2">CÁC CHẶNG HỌC CHÍNH</h2>

            <ul class="nav nav-pills justify-content-center mb-4" id="pills-tab" role="tablist">
                <li class="nav-item" role="presentation">
                    <button class="nav-link active" id="pills-step1-tab" data-bs-toggle="pill"
                        data-bs-target="#pills-step1" type="button" role="tab">Nhập môn</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="pills-step2-tab" data-bs-toggle="pill" data-bs-target="#pills-step2"
                        type="button" role="tab">Nền tảng</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="pills-step3-tab" data-bs-toggle="pill" data-bs-target="#pills-step3"
                        type="button" role="tab">Bứt tốc</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="pills-step4-tab" data-bs-toggle="pill" data-bs-target="#pills-step4"
                        type="button" role="tab">Nâng cao</button>
                </li>
            </ul>

            <div class="tab-content" id="pills-tabContent">
                <!-- Chặng 1 -->
                <div class="tab-pane fade show active" id="pills-step1" role="tabpanel">
                    <h4 class="text-center mb-4">Chặng 1: Làm quen & Nền tảng</h4>
                    <div class="row justify-content-center">
                        <div class="col-md-4 mb-4" v-for="course in courses" :key="course.id">
                            <CourseItem :id="course.id" :title="course.title" :image="course.image"
                                :features="course.features" />
                        </div>
                    </div>
                </div>

                <!-- Chặng 2 -->
                <div class="tab-pane fade" id="pills-step2" role="tabpanel">
                    <h4 class="text-center mb-4">Chặng 2: Ôn luyện & Củng cố</h4>
                    <div class="row justify-content-center">
                        <div class="col-md-4 mb-4" v-for="course in courses" :key="course.id">
                            <CourseItem :id="course.id" :title="course.title" :image="course.image"
                                :features="course.features" />
                        </div>
                    </div>
                </div>

                <!-- Chặng 3 -->
                <div class="tab-pane fade" id="pills-step3" role="tabpanel">
                    <h4 class="text-center mb-4">Chặng 3: Bứt tốc & Luyện đề</h4>
                    <div class="row justify-content-center">
                        <div class="col-md-4 mb-4" v-for="course in courses" :key="course.id">
                            <CourseItem :id="course.id" :title="course.title" :image="course.image"
                                :features="course.features" />
                        </div>
                    </div>
                </div>

                <div class="tab-pane fade" id="pills-step4" role="tabpanel">
                    <h4 class="text-center mb-4">Chặng 4: Nâng cao</h4>
                    <div class="row justify-content-center">
                        <div class="col-md-4 mb-4" v-for="course in courses" :key="course.id">
                            <CourseItem :id="course.id" :title="course.title" :image="course.image"
                                :features="course.features" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <InTroOff />
    <Footer />
</template>

<style scoped>
.container {
    margin-top: 6rem !important;
}
</style>
