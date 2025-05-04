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
                    <td>{{ enrollment.startDate }}</td>
                    <td>
                        <span class="badge" :class="{
                            'bg-success': enrollment.status === 'Đang học',
                            'bg-warning text-dark': enrollment.status === 'Đã kết thúc',
                            // 'bg-danger': enrollment.status === 'Từ chối'
                        }">
                            {{ enrollment.status }}
                        </span>
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
import i18n from '@/i18n';
import { getEnrollments } from '@/services';
import { onMounted, ref } from 'vue';

const user = JSON.parse(localStorage.getItem("user") || "{}");
const userId = user.id;

const enrollments = ref<any>([]);
const showEnrollments = async () => {
    try {
        const res = await getEnrollments(userId);
        const resdata = res.data;

        const locale = i18n.global.locale.toUpperCase();
        const nameKey = `title${locale}`;
        enrollments.value = resdata.map((enrollment: any) => {
            const today = new Date();
            const endDate = new Date(enrollment.end_date);
            const status = endDate >= today ? "Đang học" : "Đã kết thúc";

            return {
                name: enrollment.courses[nameKey],
                startDate: enrollment.start_date,
                endDate: enrollment.end_date,
                status: status,
                action: "Xem chi tiết"
            };
        });

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