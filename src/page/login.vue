<script setup lang="ts">
import { ref } from 'vue'
import { login } from "@/services/index";
import { useRouter } from 'vue-router';
import { onMounted } from 'vue';

const email = ref("");
const password = ref("");
const errorMsg = ref("");
const router = useRouter();

onMounted(() => {
  const toggleIcon = document.getElementById("togglepasslogin");
  const passwordInput = document.getElementById("passwordlogin") as HTMLInputElement | null;

  if (toggleIcon && passwordInput) {
    toggleIcon.addEventListener("click", () => {
      const isPassword = passwordInput.type === "password";
      passwordInput.type = isPassword ? "text" : "password";

      toggleIcon.classList.toggle("fa-eye-slash");
      toggleIcon.classList.toggle("fa-eye");
    });
  }
});
const handleLogin = async () => {
    const response = await login(email.value, password.value);
    if (response.success) {
        localStorage.setItem("userId", response.id);
        alert("Đăng nhập thành công");
        router.push("/");
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
            <p class="text-center fs-2 mb-3">Login</p>

            <form @submit.prevent="handleLogin">
                <p class="text-danger text-center" v-if="errorMsg">{{ errorMsg }}</p>
                <div class="mb-3">
                    <label for="email" class="form-label">Email</label>
                    <input v-model="email" type="email" id="email" class="form-control w-full"
                        placeholder="you@example.com" required />
                </div>

                <div class="mb-3">
                    <label for="password" class="form-label">Password</label>
                    <div class="input-group">
                        <input v-model="password" type="password" id="passwordlogin" class="form-control"
                            placeholder="••••••••" required />
                        <span class="input-group-text">
                            <i class="fa-solid fa-eye" id="togglepasslogin" style="cursor: pointer;"></i>
                        </span>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary w-100">Đăng nhập</button>
            </form>
            <p class="text-center text-muted mt-3">
                No account?
                <router-link to="/signin" class="text-primary">Sign up</router-link>
            </p>
        </div>
    </div>
</template>
