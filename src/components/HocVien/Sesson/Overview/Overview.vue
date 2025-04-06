<script setup lang="ts">
</script>

<template>
    <div class="tab-pane fade show active" id="overview">
        <!-- Stats -->
        <div class="stats row mb-5">
            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                Cấp độ
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                Level 1
                            </p>
                        </div>
                        <i class="fas fa-medal fa-2x text-purple"></i>
                    </div>
                    <p class="stat-change text-success mt-2 mb-0 small">
                        <i class="fas fa-arrow-up">
                        </i>
                        10d để lên cấp
                    </p>
                </div>
            </div>
            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                Điểm kinh nghiệm
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                10293
                            </p>
                        </div>
                        <i class="fas fa-cube fa-2x text-warning">
                        </i>
                    </div>
                    <p class="stat-change text-success mt-2 mb-0 small">
                        <i class="fas fa-arrow-up">
                        </i>
                        1.3% Up from past week
                    </p>
                </div>
            </div>

            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                Tổng thời gian đã học
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                $89,000
                            </p>
                        </div>
                        <i class="fas fa-chart-line fa-2x text-success">
                        </i>
                    </div>
                    <p class="stat-change text-danger mt-2 mb-0 small">
                        <i class="fas fa-arrow-down">
                        </i>
                        4.3% Down from yesterday
                    </p>
                </div>
            </div>
            <div class="col-md-3 over-item mb-4">
                <div class="stat-card p-3 bg-white rounded shadow-sm">
                    <div class="d-flex justify-content-between align-items-center mb-5">
                        <div>
                            <p class="stat-title text-muted mb-1">
                                Thời gian học hôm nay
                            </p>
                            <p class="stat-value h5 mb-0 font-weight-bold">
                                2040
                            </p>
                        </div>
                        <i class="fas fa-clock fa-2x text-orange">
                        </i>
                    </div>
                    <p class="stat-change text-success mt-2 mb-0 small">
                        <i class="fas fa-arrow-up">
                        </i>
                        1.8% Up from yesterday
                    </p>
                </div>
            </div>
        </div>
        <!-- Chart -->
        <div class="chart bg-white rounded shadow-sm p-4 mt-5">
            <div class="d-flex justify-content-between align-items-center">
                <h2 class="chart-title h6 font-weight-bold">
                    Nhật ký thời gian học tập
                </h2>
                <div class="form-group mb-0">
                    <select class="form-control bg-light border-0">
                        <option>
                            October
                        </option>
                    </select>
                </div>
            </div>
            <div class="mt-4">
                <img alt="Line chart showing study time log" class="img-fluid" src="https://placehold.co/600x300" />
            </div>
        </div>
    </div>
</template>
