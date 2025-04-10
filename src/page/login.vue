<script setup lang="ts">
import { ref } from 'vue'
import axios from 'axios'
import { useRouter } from 'vue-router'

const email = ref('')
const password = ref('')
const router = useRouter()
const errorMsg = ref('')

const handleLogin = async () => {
    try {
        const res = await axios.post(`https://localhost:7041/api/users/login?email=${email.value}&password=${password.value}`)
        alert('Đăng nhập thành công')
        router.push('/') // chuyển hướng nếu cần
    } catch (err: any) {
        errorMsg.value = err.response?.data || 'Đăng nhập thất bại'
    }
}
</script>

<template>
    <div class="bg-light d-flex align-items-center justify-content-center min-vh-100">
        <div class="position-absolute top-0 start-0 w-100 h-100">
            <img src="@/assets/images/background.png" alt="Background Image" class="w-100 h-100 object-fit-cover" />
        </div>

        <div class="bg-white rounded shadow p-4 w-100" style="max-width: 400px; z-index: 1;">
            <p class="text-center fs-2 mb-3">Login</p>

            <form @submit.prevent="handleLogin">
                <div class="mb-3">
                    <label for="email" class="form-label">Email</label>
                    <input v-model="email" type="email" id="email" class="form-control w-full" placeholder="you@example.com"
                        required />
                </div>

                <div class="mb-3">
                    <label for="password" class="form-label">Password</label>
                    <input v-model="password" type="password" id="password" class="form-control w-full" placeholder="••••••••"
                        required />
                </div>

                <p class="text-danger text-center" v-if="errorMsg">{{ errorMsg }}</p>

                <button type="submit" class="btn btn-primary w-100">Đăng nhập</button>
            </form>

            <p class="text-center text-muted mt-3">
                No account?
                <router-link to="/signin" class="text-primary">Sign up</router-link>
            </p>
        </div>
    </div>
</template>
