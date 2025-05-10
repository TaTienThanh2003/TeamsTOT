import Admin from '@/page/admin.vue'
import Cart from '@/page/Cart.vue'
import DetailCourse from '@/page/DetailCourse.vue'
import DetailOff from '@/page/DetailOff.vue'
import History from '@/page/history.vue'
import Hocvien from '@/page/hocvien.vue'
import Home from '@/page/home.vue'
import Login from '@/page/login.vue'
import Search from '@/page/Search.vue'
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
        path: '/detail-course/:id',
        name: 'DetailCourse',
        component: DetailCourse
    },
    {
        path: '/cart',
        name: 'Cart',
        component: Cart
    },
    {
        path: '/history',
        name: 'History',
        component: History
    },
    {
        path: '/search',
        name: 'Search',
        component: Search
    },
    {
        path: '/search/:courseName',
        name: 'SearchCourse',
        component: Search
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
    },
    {
        path: '/admin',
        name: 'Admin',
        component: Admin
    },
    {
        path: '/detail-off',
        name: 'DetaitOff',
        component: DetailOff
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
