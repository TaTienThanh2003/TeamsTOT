# API Services Documentation

## Overview
Tất cả các API calls đã được tập trung trong file `index.ts` để dễ quản lý và bảo trì.

## UserLesson APIs
- `getUserLessons(userId: number)` - Lấy danh sách lesson của user
- `getUserLessonsByUserId(userId: number)` - Lấy danh sách lesson theo userId
- `addUserLesson(student_id: number, lessonsId: number)` - Thêm lesson vào userLesson

## Vocabulary APIs
- `createVocabulary(data: any)` - Tạo vocabulary mới
- `updateVocabulary(id: number, data: any)` - Cập nhật vocabulary
- `deleteVocabulary(id: number)` - Xóa vocabulary

## Task APIs
- `getTasks(userId: number)` - Lấy danh sách tasks
- `createTask(data: any)` - Tạo task mới
- `updateTask(id: number, data: any)` - Cập nhật task
- `deleteTask(id: number)` - Xóa task

## Schedule APIs
- `getSchedules(userId: number)` - Lấy danh sách schedules
- `createSchedule(data: any)` - Tạo schedule mới
- `updateSchedule(id: number, data: any)` - Cập nhật schedule
- `deleteSchedule(id: number)` - Xóa schedule

## Teacher APIs
- `getTeachers()` - Lấy danh sách teachers
- `getTeacherById(id: number)` - Lấy teacher theo ID

## Payment APIs
- `createPayment(data: any)` - Tạo payment
- `getPaymentHistory(userId: number)` - Lấy lịch sử payment

## Notification APIs
- `getNotifications(userId: number)` - Lấy danh sách notifications
- `markNotificationAsRead(id: number)` - Đánh dấu notification đã đọc

## Progress APIs
- `getUserProgress(userId: number, courseId: number)` - Lấy progress của user
- `updateUserProgress(userId: number, courseId: number, data: any)` - Cập nhật progress

## Usage
```typescript
import { getUserLessons, addUserLesson } from '@/services';

// Sử dụng trong component
const userLessons = await getUserLessons(userId);
await addUserLesson(userId, lessonId);
```

## Benefits
1. **Tập trung**: Tất cả API calls ở một nơi
2. **Dễ bảo trì**: Chỉ cần sửa ở một file
3. **Type safety**: Có thể thêm TypeScript interfaces
4. **Consistency**: Đảm bảo format API calls nhất quán
5. **Reusability**: Có thể tái sử dụng ở nhiều components 