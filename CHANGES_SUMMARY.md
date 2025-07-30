# Tóm tắt thay đổi - Tính năng kiểm soát tua video và cập nhật trạng thái lesson

## 1. Cập nhật API Service (`src/services/index.ts`)

### Thêm API cập nhật trạng thái lesson:
```typescript
export const updateLessonStatus = async (lessonId: number, lessonData: any) => {
    const res = await axios.put(`${api}/lessons/${lessonId}`, {
        section_id: lessonData.section_id || 0,
        titleVI: lessonData.titleVI || "",
        titleEN: lessonData.titleEN || "",
        desVI: lessonData.desVI || "",
        desEN: lessonData.desEN || "",
        video_url: lessonData.video_url || "",
        completed: true, // Luôn set thành true khi gọi API này
        position: lessonData.position || 0
    });
    return res.data;
}
```

## 2. Cập nhật YouTube Player Service (`src/services/useYouTubePlayer.ts`)

### Thêm callback `onSeek` vào interface:
```typescript
interface YouTubeOptions {
  onSeekBlocked?: () => void;
  onEnded?: () => void;
  onSeek?: () => void; // Thêm callback khi tua video
  maxSeekTime?: number;
  onShowToast?: (message: string, type: 'warning' | 'error' | 'success') => void;
  enableSeekWarning?: boolean;
}
```

### Cập nhật logic xử lý tua video:
- Thêm gọi callback `options.onSeek?.()` khi phát hiện tua video

## 3. Cập nhật Component ShowDetail (`src/components/HocVien/Sesson/MyCourses/ShowDetail.vue`)

### Thêm tính năng kiểm soát tua video:
- Biến `seekCount` để theo dõi số lần tua
- Hằng số `maxSeeks = 2` để giới hạn số lần tua
- Hàm `handleExcessiveSeeking()` để xử lý khi tua quá nhiều lần

### Thêm tính năng cập nhật trạng thái lesson:
- Hàm `updateLessonCompletion()` để cập nhật trạng thái lesson khi xem hết video
- Hàm `handleVideoEnded()` để xử lý khi video kết thúc

### Các tính năng chính:

1. **Kiểm soát tua video:**
   - Theo dõi số lần tua video
   - Hiển thị cảnh báo khi tua quá 2 lần
   - Reset về đầu video khi tua quá nhiều lần

2. **Cập nhật trạng thái lesson:**
   - Tự động cập nhật `completed = true` khi xem hết video
   - Gọi API PUT `/api/lessons/{id}` với dữ liệu lesson đầy đủ
   - Hiển thị thông báo chúc mừng khi hoàn thành

3. **Tích hợp với YouTube Player:**
   - Sử dụng callback `onSeek` để phát hiện tua video
   - Sử dụng callback `onEnded` để xử lý khi video kết thúc
   - Reset seek count khi chuyển bài học mới

## 4. Cấu trúc dữ liệu API

API PUT `/api/lessons/{id}` nhận dữ liệu:
```json
{
  "section_id": 0,
  "titleVI": "string",
  "titleEN": "string", 
  "desVI": "string",
  "desEN": "string",
  "video_url": "string",
  "completed": true,
  "position": 0
}
```

## 5. Luồng hoạt động

1. **Khi người dùng tua video:**
   - Phát hiện tua video qua YouTube Player API
   - Tăng counter `seekCount`
   - Hiển thị cảnh báo nếu tua quá 2 lần
   - Reset video về đầu nếu tua quá nhiều

2. **Khi video kết thúc:**
   - Gọi API cập nhật trạng thái lesson
   - Cập nhật UI để hiển thị lesson đã hoàn thành
   - Hiển thị thông báo chúc mừng
   - Tự động chuyển sang bài học tiếp theo 