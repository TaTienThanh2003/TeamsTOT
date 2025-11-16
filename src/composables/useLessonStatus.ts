import { ref, onMounted } from 'vue';
import { getUserLessons } from '@/services';

export function useLessonStatus() {
    const isLoading = ref(true);
    const completedLessonIds = ref<number[]>([]);

    // Hàm refresh trạng thái lesson
    const refreshLessonStatus = async () => {
        try {
            const user = JSON.parse(localStorage.getItem('user') || '{}');
            const userId = user.id;
            
            const res = await getUserLessons(userId);
            
            // Kiểm tra cấu trúc response và xử lý đúng
            let lessonsData = [];
            if (res.data && Array.isArray(res.data)) {
                lessonsData = res.data;
            } else if (res.data && res.data.data && Array.isArray(res.data.data)) {
                lessonsData = res.data.data;
            } else if (Array.isArray(res)) {
                lessonsData = res;
            }
            
            const completedIds = lessonsData
                .filter((l: any) => l.isComplete)
                .map((l: any) => l.lessonsId || l.lessonId || l.id);
                
            completedLessonIds.value = completedIds;
            
            // Cập nhật localStorage
            localStorage.setItem('completedLessonIds', JSON.stringify(completedIds));
            
            return completedIds;
        } catch (error) {
            console.error('Lỗi refresh lesson status:', error);
            return [];
        }
    };

    // Hàm cập nhật trạng thái cho sections
    const updateSectionsStatus = (sections: any[]) => {
        sections.forEach(section => {
            section.lessons.forEach((lesson: any) => {
                const isCompleted = completedLessonIds.value.includes(lesson.id);
                lesson.completed = isCompleted;
            });
        });
    };

    // Hàm tìm lesson đầu tiên chưa hoàn thành
    const findFirstIncompleteLesson = (sections: any[]) => {
        for (const section of sections) {
            for (const lesson of section.lessons) {
                if (!lesson.completed) {
                    return lesson;
                }
            }
        }
        
        // Nếu tất cả lesson đã hoàn thành, lấy lesson cuối cùng
        const lastSection = sections[sections.length - 1];
        return lastSection.lessons[lastSection.lessons.length - 1];
    };

    // Khởi tạo ngay khi composable được sử dụng
    onMounted(async () => {
        await refreshLessonStatus();
        isLoading.value = false;
    });

    return {
        isLoading,
        completedLessonIds,
        refreshLessonStatus,
        updateSectionsStatus,
        findFirstIncompleteLesson
    };
} 