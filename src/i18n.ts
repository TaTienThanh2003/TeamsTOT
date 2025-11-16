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
console.log('i18n Locale:', i18n.global.locale)
export default i18n
