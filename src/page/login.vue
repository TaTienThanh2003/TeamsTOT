<script setup lang="ts">
</script>

<template>
    <div class="bg-light d-flex align-items-center justify-content-center min-vh-100">
        <div class="position-absolute top-0 start-0 w-100 h-100">
            <img src="@/assets//images/background.png" alt="Background Image" class="w-100 h-100 object-fit-cover" />
        </div>

        <div class="bg-white rounded shadow p-4 w-100" style="max-width: 400px; z-index: 1;">
            <h2 class="text-center mb-3">Login</h2>
            <!-- <p class="text-center text-muted mb-4">Enter your email and password</p> -->

            <form>
                <div class="mb-3">
                    <label for="email" class="form-label">Email</label>
                    <input type="email" id="email" class="form-control" placeholder="you@example.com" />
                </div>

                <div class="mb-3">
                    <label for="password" class="form-label d-flex justify-content-between">
                        <span>Password</span>
                    </label>
                    <input type="password" id="password" class="form-control" placeholder="••••••••" />
                </div>
                <div class="mb-3">
                    <a href="#" class="small">Forget Password?</a>
                </div>
                <div class="form-check mb-3">
                    <input type="checkbox" id="remember" class="form-check-input" />
                    <label for="remember" class="form-check-label">Remember me</label>
                </div>

                <button type="submit" class="btn btn-primary w-100">Sign In</button>
            </form>

            <p class="text-center text-muted mt-3">
                No account?
                <router-link to="/signin">Sign up</router-link>
            </p>
        </div>
    </div>
</template>
