export function useLiveChat(): void {
  const win = window as any;

  win.__lc = win.__lc || {};
  win.__lc.license = 19251732;
  win.__lc.integration_name = 'manual_onboarding';
  win.__lc.product_name = 'livechat';

  // Đảm bảo chỉ inject script nếu chưa có và chưa được init
  if (!win.__lc.asyncInit && (!win.LiveChatWidget || !win.LiveChatWidget._h)) {
    const script = document.createElement('script');
    script.async = true;
    script.type = 'text/javascript';
    script.src = 'https://cdn.livechatinc.com/tracking.js';
    document.head.appendChild(script);
  }

  // Khởi tạo khung LiveChatWidget nếu chưa có
  if (!win.LiveChatWidget) {
    const slice = [].slice;

    const i = (args: any[]) =>
      win.LiveChatWidget._h
        ? win.LiveChatWidget._h.apply(null, args)
        : win.LiveChatWidget._q.push(args);

    win.LiveChatWidget = {
      _q: [],
      _h: null,
      _v: '2.0',
      on: function (...args: any[]) {
        i(['on', slice.call(args)]);
      },
      once: function (...args: any[]) {
        i(['once', slice.call(args)]);
      },
      off: function (...args: any[]) {
        i(['off', slice.call(args)]);
      },
      get: function (...args: any[]) {
        if (!win.LiveChatWidget._h)
          throw new Error("[LiveChatWidget] You can't use getters before load.");
        return i(['get', slice.call(args)]);
      },
      call: function (...args: any[]) {
        i(['call', slice.call(args)]);
      },
    };
  }
}
