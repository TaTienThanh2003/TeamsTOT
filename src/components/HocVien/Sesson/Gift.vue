<script setup lang="ts">
</script>

<template>
    <div class="tab-pane fade" id="gift">
        <div class="row g-4">
            <div class="col-md-4">
                <div class="pricing-card">
                    <h3>{{ $t('hv.page7.plan.basic') }}</h3>
                    <p>{{ $t('hv.page7.fee') }}</p>
                    <p class="price">1.500.000đ</p>
                    <div class="divider"></div>
                    <ul class="list-unstyled">
                        <li>{{ $t('hv.page7.features.basic[0]') }}</li>
                        <li>{{ $t('hv.page7.features.basic[1]') }}</li>
                        <li>{{ $t('hv.page7.features.basic[2]') }}</li>
                        <li>{{ $t('hv.page7.features.basic[3]') }}</li>
                    </ul>
                    <div class="divider"></div>
                    <button class="btn btn-custom">{{ $t('hv.page7.start') }}</button>
                    <p class="mt-2 text-muted">{{ $t('hv.page7.getStarted') }}</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="pricing-card">
                    <h3>{{ $t('hv.page7.plan.standard') }}</h3>
                    <p>{{ $t('hv.page7.fee') }}</p>
                    <p class="price">3.000.000đ</p>
                    <div class="divider"></div>
                    <ul class="list-unstyled">
                        <li>{{ $t('hv.page7.features.standard[0]') }}</li>
                        <li>{{ $t('hv.page7.features.standard[1]') }}</li>
                        <li>{{ $t('hv.page7.features.standard[2]') }}t</li>
                        <li>{{ $t('hv.page7.features.standard[3]') }}</li>
                        <li>{{ $t('hv.page7.features.standard[4]') }}</li>
                    </ul>
                    <div class="divider"></div>
                    <button class="btn btn-custom">{{ $t('hv.page7.start') }}</button>
                    <p class="mt-2 text-muted">{{ $t('hv.page7.getStarted') }}</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="pricing-card">
                    <h3>{{ $t('hv.page7.plan.premium') }}</h3>
                    <p>{{ $t('hv.page7.fee') }}</p>
                    <p class="price">5.000.000đ</p>
                    <div class="divider"></div>
                    <ul class="list-unstyled">
                        <li>{{ $t('hv.page7.features.premium[0]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[1]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[2]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[3]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[4]') }}</li>
                    </ul>
                    <div class="divider"></div>
                    <button class="btn btn-primary">{{ $t('hv.page7.start') }}</button>
                    <p class="mt-2 text-muted">{{ $t('hv.page7.getStarted') }}</p>
                </div>
            </div>
        </div>
    </div>
</template>
