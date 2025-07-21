<script setup lang="ts">
import { ref } from 'vue'
import { register } from "@/services/index";
import { useRouter } from 'vue-router';

const fullname = ref("");
const email = ref("");
const password = ref("");
const confirmPassword = ref("");
const errorMsg = ref("");
const router = useRouter();

import { onMounted } from "vue";

onMounted(() => {
  const toggleIcons = document.querySelectorAll<HTMLElement>(".togglePassword");

  toggleIcons.forEach((icon) => {
    const targetId = icon.getAttribute("data-target");
    const input = document.getElementById(targetId!) as HTMLInputElement | null;

    if (icon && input) {
      icon.addEventListener("click", () => {
        input.type = input.type === "password" ? "text" : "password";
        icon.classList.toggle("fa-eye");
        icon.classList.toggle("fa-eye-slash");
      });
    }
  });
});
const handleRegister = async () => {
    if (password.value !== confirmPassword.value) {
        errorMsg.value = "Mật khẩu không khớp";
        return;
    }
    const response = await register(fullname.value,email.value, password.value);
    if (response.success) {
        alert("Đăng ký thành công");
        router.push("/login");
    } else {
        errorMsg.value = response.error;
    }
};
</script>

<template>
    <div class="bg-light d-flex align-items-center justify-content-center min-vh-100">
        <div class="position-absolute top-0 start-0 w-100 h-100">
            <img src="@/assets/images/background.png" alt="Background Image" class="w-100 h-100 object-fit-cover" />
        </div>

        <div class="bg-white rounded shadow p-4 w-100" style="max-width: 400px; z-index: 1;">
            <p class="text-center fs-2 mb-2">Create an Account</p>
            <!-- <p class="text-muted text-center">Create an account to continue</p> -->

            <form class="mt-4" @submit.prevent="handleRegister">
                <p class="text-danger text-center" v-if="errorMsg">{{ errorMsg }}</p>
                <div class="mb-3">
                    <label for="fullname" class="form-label">Full Name</label>
                    <input v-model="fullname" type="text" class="form-control w-full" id="fullname"
                        placeholder="Fullname" required />
                </div>

                <div class="mb-3">
                    <label for="email" class="form-label">Email address</label>
                    <input v-model="email" type="email" class="form-control w-full" id="email"
                        placeholder="nguyen_dang@gmail.com" required />
                </div>

                <div class="mb-3">
                    <label for="password" class="form-label d-flex justify-content-between">
                        <span>Password</span>
                    </label>
                    <div class="input-group">
                        <input v-model="password" type="password" id="password" class="form-control password-input"
                            placeholder="••••••••" required />
                        <span class="input-group-text">
                            <i class="fa-solid fa-eye togglePassword" data-target="password" style="cursor: pointer;"></i>
                        </span>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="password" class="form-label d-flex justify-content-between">
                        <span>Confirm Password</span>
                    </label>
                    <div class="input-group">
                        <input v-model="confirmPassword" type="password" id="confirmpassword" class="form-control password-input"
                            placeholder="••••••••" required />
                        <span class="input-group-text">
                            <i class="fa-solid fa-eye togglePassword" data-target="confirmpassword" style="cursor: pointer;"></i>
                        </span>
                    </div>
                </div>

                <div class="form-check mb-3">
                    <input class="form-check-input" type="checkbox" id="terms" required />
                    <label class="form-check-label" for="terms">
                        I accept terms and conditions
                    </label>
                </div>

                <button class="btn btn-primary w-100 mb-3">Sign Up</button>

                <p class="text-center text-muted">
                    Already have an account?
                    <router-link to="/login" class="text-primary">Login</router-link>
                </p>
            </form>
        </div>
    </div>
</template>
