/// <reference types="youtube" />

import { ref, onMounted, watch, type Ref } from 'vue';

interface YouTubeOptions {
  onSeekBlocked?: () => void;
  onEnded?: () => void;
  onSeek?: () => void; // Thêm callback khi tua video
  maxSeekTime?: number; // Thời gian tối đa cho phép tua (giây)
  onShowToast?: (message: string, type: 'warning' | 'error' | 'success') => void;
  enableSeekWarning?: boolean; // Bật/tắt cảnh báo tua video
}

export function useYouTubePlayer(
  videoUrl: string | Ref<string>,
  playerId: string,
  options: YouTubeOptions = {}
): Promise<YT.Player> {
  const player = ref<YT.Player | null>(null);
  const currentTime = ref(0);
  const maxSeekTime = options.maxSeekTime || 120; // Mặc định 2 phút (120 giây)
  const enableSeekWarning = options.enableSeekWarning !== false; // Mặc định bật
  const lastSeekWarning = ref(0); // Thời gian cảnh báo cuối cùng

  const showToast = (message: string, type: 'warning' | 'error' | 'success' = 'warning') => {
    console.log('showToast called:', message, type);
    
    // Kiểm tra debounce - chỉ hiển thị cảnh báo mỗi 5 giây
    const now = Date.now();
    if (type === 'warning' && now - lastSeekWarning.value < 5000) {
      console.log('Toast blocked by debounce');
      return;
    }
    lastSeekWarning.value = now;

    // Sử dụng callback nếu có
    if (options.onShowToast) {
      console.log('Using callback onShowToast');
      options.onShowToast(message, type);
      return;
    }

    // Nếu không có callback, chỉ log ra console
    console.log(`Toast (${type}): ${message}`);
  };

  const getVideoIdFromUrl = (url: string) => {
    if (!url || typeof url !== 'string') {
      console.warn('URL không hợp lệ:', url);
      return '';
    }
    
    console.log('Processing URL:', url);
    
    // Hỗ trợ nhiều định dạng URL YouTube
    const patterns = [
      /(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v=|shorts\/))([\w-]{11})/,
      /youtube\.com\/watch\?.*v=([\w-]{11})/,
      /youtu\.be\/([\w-]{11})/,
      /youtube\.com\/embed\/([\w-]{11})/,
      /youtube\.com\/v\/([\w-]{11})/,
      /youtube\.com\/shorts\/([\w-]{11})/
    ];
    
    for (const pattern of patterns) {
      const match = url.match(pattern);
      if (match) {
        const videoId = match[1];
        console.log('Extracted video ID:', videoId);
        return videoId;
      }
    }
    
    console.warn('Không thể trích xuất video ID từ URL:', url);
    return '';
  };

  const loadYouTubeIframeAPI = () => {
    return new Promise<void>((resolve) => {
      if (window.YT && window.YT.Player) {
        resolve();
        return;
      }

      const tag = document.createElement('script');
      tag.src = 'https://www.youtube.com/iframe_api';
      document.body.appendChild(tag);

      (window as any).onYouTubeIframeAPIReady = () => {
        resolve();
      };
    });
  };

  const initPlayer = async (videoId: string) => {
    if (!videoId) {
      console.warn('YouTube video ID is invalid');
      return Promise.reject('Invalid video ID');
    }

    console.log('Initializing player with video ID:', videoId);
    await loadYouTubeIframeAPI();

    return new Promise<YT.Player>((resolve, reject) => {
      if (player.value) {
        console.log('Destroying existing player');
        player.value.destroy();
      }

      try {
        player.value = new window.YT.Player(playerId, {
          videoId,
          playerVars: {
            modestbranding: 1,
            rel: 0,
            enablejsapi: 1,
            playsinline: 1,
            fs: 1,
            origin: window.location.origin,
          },
          events: {
            onReady: (event) => {
              console.log('YouTube player ready with video ID:', videoId);
              // Expose player ra window để có thể truy cập từ component khác
              (window as any).ytPlayer = event.target;
              event.target.playVideo();
              resolve(player.value!);
            },
            onError: (event) => {
              console.error('YouTube player error:', event.data);
              reject(`YouTube player error: ${event.data}`);
            },
            onStateChange: (event) => {
              console.log('Player state changed:', event.data);
              if (event.data === YT.PlayerState.PLAYING) {
                // Kiểm tra tua video mỗi giây
                setInterval(() => {
                  if (player.value) {
                    const ct = player.value.getCurrentTime();
                    const timeDiff = Math.abs(ct - currentTime.value);
                    
                    // Nếu thời gian thay đổi quá lớn (tua video)
                    if (timeDiff > maxSeekTime) {
                      console.log(`Seek detected: ${timeDiff}s > ${maxSeekTime}s`);
                      
                      // Gọi callback onSeek nếu có
                      options.onSeek?.();
                      
                      // Chỉ hiển thị thông báo cảnh báo nếu bật tính năng này
                      if (enableSeekWarning) {
                        const minutes = Math.floor(maxSeekTime / 60);
                        const seconds = maxSeekTime % 60;
                        const timeLimit = minutes > 0 ? `${minutes} phút ${seconds} giây` : `${seconds} giây`;
                        
                        // Hiển thị cảnh báo khi tua quá thời gian cho phép
                        showToast(`Cảnh báo: Bạn đã tua video quá xa! Chỉ nên tua tối đa ${timeLimit} so với thời gian hiện tại.`, 'warning');
                      }
                      
                      // Cập nhật thời gian hiện tại để tránh spam thông báo
                      currentTime.value = ct;
                      
                      // Gọi callback nếu có
                      options.onSeekBlocked?.();
                    } else {
                      // Cập nhật thời gian hiện tại
                      currentTime.value = ct;
                    }
                  }
                }, 1000);
              }

              if (event.data === YT.PlayerState.ENDED) {
                console.log('Video ended');
                options.onEnded?.();
              }
            },
          },
        });
      } catch (error) {
        console.error('Error creating YouTube player:', error);
        reject(error);
      }
    });
  };

  const initialize = async () => {
    // Kiểm tra videoUrl có tồn tại không
    if (!videoUrl) {
      console.warn('videoUrl is undefined or null');
      return Promise.reject('Empty video URL');
    }
    
    const url = typeof videoUrl === 'string' ? videoUrl : videoUrl.value;
    if (!url) {
      console.warn('Không có URL để khởi tạo YouTube player');
      return Promise.reject('Empty video URL');
    }
    const id = getVideoIdFromUrl(url);
    console.log('Initializing YouTube player with video ID:', id);
    return await initPlayer(id);
  };

  const playerPromise = initialize();

  if (typeof videoUrl !== 'string') {
    watch(videoUrl, (newUrl) => {
      const id = getVideoIdFromUrl(newUrl);
      console.log('Changing YouTube video to ID:', id);
      initPlayer(id);
    });
  }

  return playerPromise;
}