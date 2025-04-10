import DetailCourse from '@/page/DetailCourse.vue'
import Hocvien from '@/page/hocvien.vue'
import Home from '@/page/home.vue'
import Login from '@/page/login.vue'
import Signin from '@/page/signin.vue'
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/hocvien',
        name: 'HocVien',
        component: Hocvien
    },
    {
        path: '/detail-course',
        name: 'DetailCourse',
        component: DetailCourse
    },
    {
        path: '/login',
        name: 'Login',
        component: Login
    },
    {
        path: '/signin',
        name: 'SignIn',
        component: Signin
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
