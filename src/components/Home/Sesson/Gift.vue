<script setup lang="ts">
import GiftEnrollModel from '@/components/Model/GiftEnrollModel.vue'
</script>

<template>
    <div class="section-customer">
        <h2 class="section-title shine-text">ƯU ĐÃI GIỚI HẠN</h2>
        <div class="row g-4">
            <div class="col-md-4">
                <div class="pricing-card">
                    <h3>{{ $t('hv.page7.plan.basic') }}</h3>
                    <p>{{ $t('hv.page7.fee') }}</p>
                    <p class="price font-blue">1.500.000đ</p>
                    <div class="divider"></div>
                    <ul class="list-unstyled">
                        <li>{{ $t('hv.page7.features.basic[0]') }}</li>
                        <li>{{ $t('hv.page7.features.basic[1]') }}</li>
                        <li>{{ $t('hv.page7.features.basic[2]') }}</li>
                        <li>{{ $t('hv.page7.features.basic[3]') }}</li>
                    </ul>
                    <div class="divider"></div>
                    <button class="btn btn-custom" data-bs-toggle="modal" data-bs-target="#giftConsultModal-basic">{{ $t('hv.page7.start') }}</button>
                    <GiftEnrollModel id="basic" :name="$t('hv.page7.plan.basic')" />
                    <p class="mt-2 text-muted">{{ $t('hv.page7.getStarted') }}</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="pricing-card center">
                    <h3>{{ $t('hv.page7.plan.standard') }}</h3>
                    <p>{{ $t('hv.page7.fee') }}</p>
                    <p class="price font-blue">3.000.000đ</p>
                    <div class="divider"></div>
                    <ul class="list-unstyled">
                        <li>{{ $t('hv.page7.features.standard[0]') }}</li>
                        <li>{{ $t('hv.page7.features.standard[1]') }}</li>
                        <li>{{ $t('hv.page7.features.standard[2]') }}t</li>
                        <li>{{ $t('hv.page7.features.standard[3]') }}</li>
                        <li>{{ $t('hv.page7.features.standard[4]') }}</li>
                    </ul>
                    <div class="divider"></div>
                    <button class="btn btn-custom" data-bs-toggle="modal" data-bs-target="#giftConsultModal-standard">{{ $t('hv.page7.start') }}</button>
                    <GiftEnrollModel id="standard" :name="$t('hv.page7.plan.standard')" />
                    <p class="mt-2 text-muted">{{ $t('hv.page7.getStarted') }}</p>
                </div>
            </div>
            <div class="col-md-4">
                <div class="pricing-card">
                    <h3>{{ $t('hv.page7.plan.premium') }}</h3>
                    <p>{{ $t('hv.page7.fee') }}</p>
                    <p class="price font-blue">5.000.000đ</p>
                    <div class="divider"></div>
                    <ul class="list-unstyled">
                        <li>{{ $t('hv.page7.features.premium[0]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[1]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[2]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[3]') }}</li>
                        <li>{{ $t('hv.page7.features.premium[4]') }}</li>
                    </ul>
                    <div class="divider"></div>
                    <button class="btn btn-custom" data-bs-toggle="modal" data-bs-target="#giftConsultModal-premium">{{ $t('hv.page7.start') }}</button>
                    <GiftEnrollModel id="premium" :name="$t('hv.page7.plan.premium')" />
                    <p class="mt-2 text-muted">{{ $t('hv.page7.getStarted') }}</p>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
.pricing-card {
    min-height: 37.5rem;
    border-radius: 0.625rem;
    padding: 1.875rem;
    text-align: center;
    background: var(--bg-white);
    box-shadow: 0px 0.25rem 0.625rem #6C63FF;
}

.pricing-card.center {
    border: 3px solid #6C63FF;
    box-shadow: 0px 0.8rem 1rem #6C63FF;
}

.pricing-card h3 {
    font-weight: bold;
}

.price {
    font-size: 1.75rem;
    font-weight: bold;
}

.list-unstyled {
    min-height: 18.75rem;
    padding-top: 0.625rem;
}

.list-unstyled li {
    margin: 0.625rem 0;
    font-weight: bold;
}

.btn-custom {
    border: 2px solid #6C63FF;
    color: #6C63FF;
    font-weight: bold;
}

.btn-custom:hover {
    background-color: #6C63FF;
    color: var(--bg-white);
}

.divider {
    border-top: 1px solid var(--border-color);
    margin: 0.9375rem 0;
}
</style>