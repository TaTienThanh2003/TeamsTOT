export function useLiveChat() {
    const win = window as any

    win.__lc = win.__lc || {}
    win.__lc.license = 19173749
    win.__lc.integration_name = 'manual_onboarding'
    win.__lc.product_name = 'livechat'

    if (!win.__lc.asyncInit && !win.LiveChatWidget?._h) {
        const s = document.createElement('script')
        s.async = true
        s.type = 'text/javascript'
        s.src = 'https://cdn.livechatinc.com/tracking.js'
        document.head.appendChild(s)
    }
}
