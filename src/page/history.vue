<template>
    <div class="container py-5">
        <Header />
        <h1 class="text-primary my-5 fs-2 text-center">Khóa học của tôi</h1>

        <table class="table my-table">
            <thead>
                <tr>
                    <th>Tên khóa học</th>
                    <th>Ngày đăng ký</th>
                    <th>Trạng thái</th>
                    <th>Thao tác</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(enrollment, index) in enrollments" :key="index">
                    <td>{{ enrollment.name }}</td>
                    <td>10/04/2025</td>
                    <td>
                        <span class="badge bg-success">Đã đăng ký</span>
                        <!-- <span class="badge" :class="{
                            'bg-success': course.status === 'Đã đăng ký',
                            'bg-warning text-dark': course.status === 'Đang xử lý',
                            'bg-danger': course.status === 'Từ chối'
                        }">
                            {{ course.status }}
                        </span> -->
                    </td>
                    <td>
                        <button class="btn btn-outline-primary btn-sm">Xem chi tiết</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

</template>

<script setup lang="ts">
import Header from '@/components/Home/Header.vue';
import { getCourseById, getEnrollments } from '@/services';
import { onMounted, ref } from 'vue';

const user = JSON.parse(localStorage.getItem("user") || "{}");
const userId = user.id;
// const registeredCourses = ref([
//     {
//         name: 'TOEIC Cơ bản',
//         registeredDate: '10/04/2025',
//         status: 'Đã đăng ký'
//     },
//     {
//         name: 'TOEIC Nâng cao',
//         registeredDate: '09/04/2025',
//         status: 'Đang xử lý'
//     }
// ]);
const enrollments = ref<any>([]);
const showEnrollments = async () => {
    try {
        const res = await getEnrollments(userId);
        const resdata = res.data;
        enrollments.value = resdata.map((enrollment : any) => ({
            name: enrollment.name
        }))
    } catch (error) {
        
    }
}
onMounted(() => {
    showEnrollments();
});
</script>

<style scoped>
.my-table {
    border-collapse: collapse;
    width: 100%;
}

.my-table thead tr {
    border-bottom: 2px solid #6C63FF;
}

.my-table td,
.my-table th {
    border-bottom: 1px solid #ddd;
    padding: 0.75rem;
}

.my-table tr:last-child td {
    border-bottom: none;
}
</style>