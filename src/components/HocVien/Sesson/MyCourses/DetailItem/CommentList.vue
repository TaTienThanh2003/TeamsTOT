<script setup lang="ts">
import { ref } from 'vue';

defineProps<{
    showCommentInput: boolean;
}>();

const emit = defineEmits(['setClose']);

const onCloseDetail = () => {
    emit('setClose', false)
}

const comments = ref<any>([
    {
        username: 'Nguyễn Văn A',
        text: 'Bình luận về mẫu câu chào hỏi cơ bản',
        date: '3 giờ trước',
        likes: 2,
        replies: []
    },
    {
        username: 'Trần Thị B',
        text: 'Bình luận về từ vựng gia đình và bạn bè',
        date: '2 ngày trước',
        likes: 5,
        replies: []
    }
]);

const activeReplyIndex = ref<number | null>(null);
const replyText = ref<string>('');
const likeComment = (comment: (typeof comments.value)[0]) => {
    comment.likes++;
}

const submitReply = (index: number) => {
    if (replyText.value.trim() !== '') {
        comments.value[index].replies.push({
            username: 'Người dùng mới',
            text: replyText.value,
            date: 'Vừa xong',
            likes: 0,
            replies: []
        });
        replyText.value = '';
        activeReplyIndex.value = null;
    }
};
</script>


<template>
    <div v-if="showCommentInput" :class="showCommentInput ? 'note-panel active' : 'note-panel'">
        <div class="d-flex justify-between align-items-center mb-4">
            <h3 class="fs-5 bold">Bắt đầu thảo luận</h3>
            <button class="fs-5" @click="onCloseDetail">
                <i class="fas fa-times"></i>
            </button>
        </div>
        <input class="start-discussion" type="text" placeholder="Nhập bình luận mới của bạn" />

        <ul class="comment-list">
            <li v-for="(comment, index) in comments" :key="index" class="comment-item">
                <div class="comment-header">
                    <div class="user-info">
                        <div class="user-avatar">{{ comment.username.charAt(0) }}</div>
                        <div class="user-name-time">
                            <div class="username">{{ comment.username }}</div>
                            <div class="time">{{ comment.date }}</div>
                        </div>
                    </div>
                    <div class="actions">
                        <button class="action-btn">...</button>
                    </div>
                </div>

                <div class="comment-text">{{ comment.text }}</div>

                <div class="comment-footer">
                    <button class="like-btn" @click="likeComment(comment)">👍 {{ comment.likes }}</button>
                    <button class="reply-btn" @click="activeReplyIndex = index">Reply</button>
                </div>

                <!-- Hộp nhập reply -->
                <div v-if="activeReplyIndex === index" class="reply-input">
                    <input v-model="replyText" type="text" placeholder="Write a reply..." />
                    <button @click="submitReply(index)" class="send-btn">Send</button>
                </div>

                <!-- Danh sách reply -->
                <ul class="reply-list">
                    <li v-for="(reply, replyIndex) in comment.replies" :key="replyIndex" class="reply-item">
                        <div class="reply-header">
                            <div class="user-info">
                                <div class="user-avatar">{{ reply.username.charAt(0) }}</div>
                                <div class="user-name-time">
                                    <div class="username">{{ reply.username }}</div>
                                    <div class="time">{{ reply.date }}</div>
                                </div>
                            </div>
                        </div>

                        <div class="reply-text">{{ reply.text }}</div>

                        <div class="reply-footer">
                            <button class="like-btn" @click="likeComment(reply)">👍 {{ reply.likes }}</button>
                        </div>
                    </li>
                </ul>

            </li>
        </ul>
    </div>
</template>

<style scoped>
.note-panel {
    padding: 1rem;
}

.comment-section {
    border-radius: 8px;
    padding: 16px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
}

.start-discussion {
    width: 100%;
    padding: 12px;
    margin-bottom: 20px;
    background-color: #fff;
    border: 1px solid #e5e7eb;
    border-radius: 8px;
    font-size: 14px;
    outline-style: none;
}

.comment-list {
    list-style: none;
    padding: 0;
    margin: 0;
}

.comment-item {
    padding: 12px 0;
    border-bottom: 1px solid #e5e7eb;
}

.comment-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.user-info {
    display: flex;
    align-items: center;
    gap: 10px;
}

.user-avatar {
    width: 36px;
    height: 36px;
    border-radius: 50%;
    background-color: #dbeafe;
    display: flex;
    justify-content: center;
    align-items: center;
    font-weight: bold;
    color: #3b82f6;
}

.user-name-time {
    display: flex;
    flex-direction: column;
}

.username {
    font-weight: 600;
}

.time {
    font-size: 12px;
    color: #9ca3af;
}

.actions .action-btn {
    background: none;
    border: none;
    font-size: 18px;
    color: #9ca3af;
    cursor: pointer;
}

.comment-text {
    margin-top: 8px;
    font-size: 14px;
    color: #374151;
}

.comment-footer {
    display: flex;
    gap: 10px;
    margin-top: 8px;
}

.like-btn,
.reply-btn {
    background: none;
    border: none;
    color: #3b82f6;
    cursor: pointer;
    font-size: 14px;
}

.reply-input {
    display: flex;
    gap: 8px;
    margin-top: 8px;
}

.reply-input input {
    flex: 1;
    padding: 8px;
    border: 1px solid #e5e7eb;
    border-radius: 8px;
    font-size: 14px;
    outline-style: none;
}

.send-btn {
    background-color: #3b82f6;
    color: #fff;
    padding: 8px 12px;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    font-size: 14px;
}

.reply-list {
    list-style: none;
    padding-left: 44px;
    margin-top: 8px;
}

.reply-item {
    padding: 8px 0;
}

.reply-text {
    font-size: 14px;
    color: #374151;
    margin-top: 4px;
}

.reply-footer {
    margin-top: 4px;
}
</style>