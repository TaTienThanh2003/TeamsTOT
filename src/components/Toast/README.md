# Toast Component với YouTube Player

## Cách sử dụng Toast với useYouTubePlayer

### 1. Import các component cần thiết

```vue
<template>
  <div>
    <div id="youtube-player"></div>
    <ToastContainer />
  </div>
</template>

<script setup lang="ts">
import { useYouTubePlayer } from '@/services/useYouTubePlayer'
import { useToast } from '@/composables/useToast'
import ToastContainer from '@/components/Toast/ToastContainer.vue'
</script>
```

### 2. Sử dụng useToast

```typescript
const { success, error, warning, info } = useToast()

// Tạo callback để xử lý toast từ YouTube player
const handleShowToast = (message: string, type: 'warning' | 'error' | 'success') => {
  switch (type) {
    case 'success':
      success(message)
      break
    case 'error':
      error(message)
      break
    case 'warning':
      warning(message)
      break
  }
}
```

### 3. Khởi tạo YouTube Player với Toast

```typescript
onMounted(async () => {
  try {
    await useYouTubePlayer(videoUrl, 'youtube-player', {
      maxSeekTime: 60, // Thời gian tối đa cho phép tua (giây)
      enableSeekWarning: true, // Bật cảnh báo tua video
      onShowToast: handleShowToast, // Callback để hiển thị toast
      onSeekBlocked: () => {
        console.log('Seek blocked')
      },
      onEnded: () => {
        success('Video đã kết thúc!')
      }
    })
  } catch (err) {
    if (err instanceof Error) {
      error(err.message, 'Lỗi YouTube Player')
    } else {
      error('Có lỗi xảy ra khi khởi tạo YouTube player', 'Lỗi')
    }
  }
})
```

## Các loại Toast

- **success**: Thông báo thành công (màu xanh)
- **error**: Thông báo lỗi (màu đỏ)
- **warning**: Thông báo cảnh báo (màu vàng)
- **info**: Thông báo thông tin (màu xanh dương)

## Các tùy chọn của useYouTubePlayer

- `maxSeekTime`: Thời gian tối đa cho phép tua video (mặc định: 120 giây)
- `enableSeekWarning`: Bật/tắt cảnh báo khi tua video (mặc định: true)
- `onShowToast`: Callback để hiển thị toast
- `onSeekBlocked`: Callback khi người dùng tua quá thời gian cho phép
- `onEnded`: Callback khi video kết thúc

## Ví dụ hoàn chỉnh

Xem file `src/components/Example/YouTubePlayerExample.vue` để có ví dụ hoàn chỉnh về cách sử dụng. 