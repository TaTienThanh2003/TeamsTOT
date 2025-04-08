import { createI18n } from 'vue-i18n'
import en from './language/en'
import vi from './language/vi'

const i18n = createI18n({
    legacy: true,
    globalInjection: true,
    locale: 'vi',
    fallbackLocale: 'en',
    messages: {
        en,
        vi,
    },
})

export default i18n
