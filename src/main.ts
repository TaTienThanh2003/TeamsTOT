// CSS
import 'bootstrap/dist/css/bootstrap.min.css'
import '@fortawesome/fontawesome-free/css/all.min.css'
import '@/assets/css/hocvien.css'
import '@/assets/css/home.css'
import 'material-symbols'


// JS
import 'bootstrap/dist/js/bootstrap.bundle.min.js'

import { ProCalendar } from "@lbgm/pro-calendar-vue";
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import i18n from './i18n'
import AOS from 'aos';
import 'aos/dist/aos.css';

AOS.init({
    duration: 1200,
    offset: 200,
    once: false,
    easing: 'ease-in-out',
});

createApp(App)
    .use(i18n)
    .use(router)
    .use(ProCalendar)
    .mount('#app')

