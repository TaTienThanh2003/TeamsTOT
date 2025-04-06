<script setup lang="ts">
</script>

<template>
    <div class="tab-pane fade" id="user">
        <div class="card user_cart">

            <div class="text-center">
                <div class="icon-circle">
                    <i class="fa fa-camera fa-2x" aria-hidden="true"></i> <!-- Icon máy ảnh -->
                </div>
                <a href="#" class="d-block mt-2" style="text-decoration: none; color: #007bff;">Upload
                    File</a> <!-- Thẻ a -->
            </div>
            <form>
                <div class="row mb-4 from-input"> <!-- Thêm khoảng cách giữa hàng -->
                    <div class="form-group col-md-6 mb-3">
                        <label for="firstName">First Name</label>
                        <input type="text" class="form-control" id="firstName" placeholder="Enter your first name">
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="lastName">Last Name</label>
                        <input type="text" class="form-control" id="lastName" placeholder="Enter your last name">
                    </div>
                </div>
                <div class="row mb-4 from-input">
                    <div class="form-group col-md-6 mb-3">
                        <label for="email">Email</label>
                        <input type="email" class="form-control" id="email" placeholder="Enter your email">
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="phoneNumber">Phone Number</label>
                        <input type="text" class="form-control" id="phoneNumber" placeholder="Enter your phone number">
                    </div>
                </div>
                <div class="row mb-4 from-input">
                    <div class="form-group col-md-6 mb-3">
                        <label for="position">Position</label>
                        <input type="text" class="form-control" id="position" placeholder="CEO" readonly>
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="gender">Gender</label>
                        <select id="gender" class="form-control">
                            <option selected>Male</option>
                            <option>Female</option>
                            <option>Other</option>
                        </select>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary user-button btn-block">LƯU</button>
            </form>
        </div>
    </div>
</template>
