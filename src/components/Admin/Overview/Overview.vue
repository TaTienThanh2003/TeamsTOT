<script setup lang="ts">
import BestSellerCoursesChart from './BestSellerCoursesChart.vue';
import StudentBarChart from './StudentBarChart.vue';

</script>

<template>
    <div>
        <div class="container py-4">
            <h2 class="mb-4 fw-bold text-center fs-4">TỔNG QUAN TRUNG TÂM</h2>
            <div class="row g-4">
                <!-- Thẻ doanh thu -->
                <div class="col-lg-4">
                    <div class="card p-4 shadow-sm rounded-4 text-center h-100">
                        <div class="mb-3">
                            <div class="bg-warning bg-opacity-25 d-inline-flex justify-content-center align-items-center rounded-circle"
                                style="width: 48px; height: 48px;">
                                <i class="fa fa-shopping-bag fs-4 text-warning"></i>
                            </div>
                        </div>
                        <h3 class="fw-bold mb-1">$54,143</h3>
                        <div class="mb-2">
                            <span class="badge bg-light text-success border border-success px-2 py-1 small">47% <i
                                    class="bi bi-arrow-up-short"></i></span>
                        </div>
                        <p class="text-muted small mb-3">
                            Doanh thu tháng này sau khi trừ chi phí và thuế.
                        </p>
                        <div
                            class="d-flex justify-content-between align-items-center rounded-pill border px-3 py-1 shadow-sm">
                            <span class="text-muted small fw-semibold">Download Reports</span>
                            <button
                                class="btn btn-primary btn-sm d-flex align-items-center justify-content-center rounded-circle"
                                style="width: 32px; height: 32px; padding: 0;">
                                <i class="fas fa-arrow-right text-white"></i>
                            </button>
                        </div>

                    </div>

                </div>

                <!-- Thẻ chỉ số phụ -->
                <div class="col-lg-4">
                    <div class="card p-4 shadow-sm rounded-4 h-100">
                        <ul class="list-group list-group-flush small">
                            <li class="list-group-item d-flex justify-content-between">
                                <span>Tổng giao dịch</span>
                                <span>4.501 <span class="text-danger">▼ 2%</span></span>
                            </li>
                            <li class="list-group-item d-flex justify-content-between">
                                <span>Ca học bị hủy</span>
                                <span>2 <span class="text-danger">▼ 0.1%</span></span>
                            </li>
                            <li class="list-group-item d-flex justify-content-between">
                                <span>Giá trị thuê tổng</span>
                                <span>$72.000 <span class="text-success">▲ 49%</span></span>
                            </li>
                            <li class="list-group-item d-flex justify-content-between">
                                <span>Lợi nhuận thuần</span>
                                <span>$54.000 <span class="text-success">▲ 52%</span></span>
                            </li>
                            <li class="list-group-item d-flex justify-content-between">
                                <span>Học viên mới</span>
                                <span>2.500 <span class="text-success">▲ 52%</span></span>
                            </li>
                        </ul>
                    </div>
                </div>

                <!-- Biểu đồ học viên -->
                <div class="col-lg-4">
                    <div class="card p-3 shadow-sm rounded-4 h-100">
                        <h5 class="mb-3 fw-semibold">Học viên mới theo tháng</h5>
                        <StudentBarChart />
                    </div>
                </div>

                <!-- Biểu đồ best seller -->
                <div class="col-lg-12">
                    <div class="card p-4 shadow-sm rounded-4">
                        <h5 class="mb-3 fw-semibold">Khóa học bán chạy</h5>
                        <BestSellerCoursesChart />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
.text-sm {
    font-size: 0.9rem;
}

.card {
    border-radius: 1rem;
}
</style>