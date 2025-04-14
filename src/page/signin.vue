<script setup lang="ts">
import { ref } from 'vue';

const [name, email, password, confirmpass] = [ref(''), ref(''), ref(''), ref('')];
const checkterm = ref(false);

const handleSignin = () => {

}
</script>

<template>
    <div class="bg-light d-flex align-items-center justify-content-center min-vh-100">
        <div class="position-absolute top-0 start-0 w-100 h-100">
            <img src="@/assets/images/background.png" alt="Background Image" class="w-100 h-100 object-fit-cover" />
        </div>

        <div class="bg-white rounded shadow p-4 w-100" style="max-width: 400px; z-index: 1;">
            <p class="text-center fs-2 mb-2">Create an Account</p>
            <!-- <p class="text-muted text-center">Create an account to continue</p> -->

            <form @submit.prevent="handleSignin" class="mt-4">
                <div class="mb-3">
                    <label for="username" class="form-label">Username</label>
                    <input v-model="name" type="text" class="form-control w-full" id="username" placeholder="Username"
                        required />
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
                    <input v-model="password" type="password" class="form-control w-full" id="password"
                        placeholder="********" required />
                </div>

                <div class="mb-3">
                    <label for="password" class="form-label d-flex justify-content-between">
                        <span>Confirm Password</span>
                    </label>
                    <input v-model="confirmpass" type="password" class="form-control w-full" id="password"
                        placeholder="********" required />
                </div>

                <div class="form-check mb-3">
                    <input v-model="checkterm" class="form-check-input" type="checkbox" id="terms" required />
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
