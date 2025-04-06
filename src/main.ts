// CSS
import 'bootstrap/dist/css/bootstrap.min.css'
import '@fortawesome/fontawesome-free/css/all.min.css'
import '@/assets/css/hocvien.css'
import '@/assets/css/home.css'

// JS
import 'bootstrap/dist/js/bootstrap.bundle.min.js'
import '@/assets/js/style.js'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

const app = createApp(App)
app.use(router)
app.mount('#app')

