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
import Toast from 'vue-toastification';
import type { PluginOptions, POSITION } from 'vue-toastification';
import 'vue-toastification/dist/index.css';
import ToastContainer from '@/components/Toast/ToastContainer.vue'

AOS.init({
    duration: 1200,
    offset: 200,
    once: false,
    easing: 'ease-in-out',
});

const options: PluginOptions = {
  position: 'top-right' as POSITION,
  timeout: 3000,
  closeOnClick: true,
  pauseOnFocusLoss: true,
  pauseOnHover: true,
  draggable: true,
  draggablePercent: 0.6,
  showCloseButtonOnHover: false,
  hideProgressBar: false,
  closeButton: 'button',
  icon: true,
  rtl: false
};

const app = createApp(App);
app.use(i18n);
app.use(router);
app.use(ProCalendar);
app.use(Toast, options);
app.component('ToastContainer', ToastContainer)
app.mount('#app');

