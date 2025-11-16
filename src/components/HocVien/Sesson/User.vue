<script setup lang="ts">
</script>

<template>
    <div class="tab-pane fade" id="user">
        <div class="card user_cart">
            <div class="text-center">
                <div class="icon-circle">
                    <i class="fa fa-camera fa-2x" aria-hidden="true"></i>
                </div>
                <a href="#" class="d-block mt-2" style="text-decoration: none; color: #007bff;">{{ $t('hv.page9.upload') }}</a> <!-- Thẻ a -->
            </div>
            <form>
                <div class="row mb-4 from-input">
                    <div class="form-group col-md-6 mb-3">
                        <label for="firstName">{{ $t('hv.page9.firstname') }}</label>
                        <input type="text" class="form-control" id="firstName" placeholder="Enter your first name">
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="lastName">{{ $t('hv.page9.lastname') }}</label>
                        <input type="text" class="form-control" id="lastName" placeholder="Enter your last name">
                    </div>
                </div>
                <div class="row mb-4 from-input">
                    <div class="form-group col-md-6 mb-3">
                        <label for="email">Email</label>
                        <input type="email" class="form-control" id="email" placeholder="Enter your email">
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="phoneNumber">{{ $t('hv.page9.phone') }}</label>
                        <input type="text" class="form-control" id="phoneNumber" placeholder="Enter your phone number">
                    </div>
                </div>
                <div class="row mb-4 from-input">
                    <div class="form-group col-md-6 mb-3">
                        <label for="position">{{ $t('hv.page9.position') }}</label>
                        <input type="text" class="form-control" id="position" placeholder="CEO" readonly>
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="gender">{{ $t('hv.page9.gender') }}</label>
                        <select id="gender" class="form-control">
                            <option selected>{{ $t('hv.page9.male') }}</option>
                            <option>{{ $t('hv.page9.female') }}</option>
                            <option>{{ $t('hv.page9.other') }}</option>
                        </select>
                    </div>
                </div>
                <button class="btn btn-primary user-button btn-block">{{ $t('hv.page9.save') }}</button>
            </form>
        </div>
    </div>
</template>
