<script setup lang="ts">
import { getComment } from '@/services';
import { addComment } from '@/services';
import { onMounted, ref, watch } from 'vue';

const props = defineProps<{
    showCommentInput: boolean;
    lessonid: number;
}>();

const emit = defineEmits(['setClose']);
const user = JSON.parse(localStorage.getItem("user") || "{}");
const userid = user.id;
const username = user.fullName;
const comments = ref<any>([]);
const commentText = ref<string>('');
const onCloseDetail = () => {
    emit('setClose', false)
}
const activeReplyId = ref<number | null>(null);
const replyText = ref<{ [key: number]: string }>({});
const likeComment = (comment: (typeof comments.value)[0]) => {
    comment.likes++;
}

const submitReply = async (parentId: number) => {
    const text = replyText.value[parentId]?.trim();
    if (text) {
        try {
            await addComment(props.lessonid, userid, text, parentId);
            replyText.value[parentId] = ''; // clear text for that parent
            activeReplyId.value = null;
            await showcomment(props.lessonid); // refresh comments and replies
        } catch (error) {
            console.log("Lỗi gửi reply:", error);
        }
    }
};
const addComments = async (lesson_id: number, userid: number, text: string, parent_id: number | null = null) => {
    try {
        await addComment(lesson_id, userid, text, parent_id);
        commentText.value = '';
        await showcomment(lesson_id);
    } catch (err: any) {
        console.log("Lỗi comments: " + err);
    }
}
const showcomment = async (lessonid: number) => {
    try {
        const res = await getComment(lessonid);
        const resdata = res.data;

        // Tạo một đối tượng để lưu trữ các comment theo ID
        const commentMap: { [key: number]: any } = {};

        // Duyệt qua dữ liệu và tạo comment và reply
        resdata.forEach((item: any) => {
            if (item.parent_id === null) {
                // Đây là một comment cha
                commentMap[item.id] = {
                    id: item.id,
                    text: item.text,
                    likes: item.likes,
                    user: item.user || {},
                    replies: [] // Khởi tạo mảng replies
                };
            } else {
                // Đây là một reply
                const parentId = item.parent_id;
                if (commentMap[parentId]) {
                    commentMap[parentId].replies.push({
                        id: item.id,
                        text: item.text,
                        likes: item.likes,
                        user: item.user || {}
                    });
                }
            }
        });

        // Chuyển đổi đối tượng comment thành một mảng
        comments.value = Object.values(commentMap);

    } catch (error) {
        console.log(error);
    }
}
onMounted(() => {
    if (props.lessonid) {
        showcomment(props.lessonid);
    }
});

watch(() => props.lessonid, (newId) => {
    if (newId) {
        showcomment(newId);
    }
});
</script>


<template>
    <div v-if="showCommentInput" :class="showCommentInput ? 'note-panel active' : 'note-panel'">
        <div class="d-flex justify-between align-items-center mb-4">
            <h3 class="fs-5 bold">Bắt đầu thảo luận</h3>
            <button class="fs-5" @click="onCloseDetail">
                <i class="fas fa-times"></i>
            </button>
        </div>
        <input class="start-discussion" type="text" placeholder="Nhập bình luận mới của bạn" v-model="commentText" />
        <button class="btn btn-primary" @click="addComments(props.lessonid, userid, commentText, null)">
            Bình luận
        </button>

        <ul class="comment-list">
            <li v-for="(comment, index) in comments" :key="index" class="comment-item">
                <div class="comment-header">
                    <div class="user-info">
                        <div class="user-avatar">
                            <img :src="comment.user.image" alt="avatar" class="user-avatar">
                        </div>
                        <div class="user-name-time">
                            <div class="username">{{ comment.user.userName }}</div>
                        </div>
                    </div>
                    <div class="actions">
                        <button class="action-btn">...</button>
                    </div>
                </div>

                <div class="comment-text">{{ comment.text }}</div>

                <div class="comment-footer">
                    <button class="like-btn" @click="likeComment(comment)">👍 {{ comment.likes }}</button>
                    <button class="reply-btn" @click="activeReplyId = comment.id">Reply</button>
                </div>

                <!-- Hộp nhập reply -->
                <div v-if="activeReplyId === comment.id" class="reply-input">
                    <input v-model="replyText[comment.id]" type="text" placeholder="Write a reply..." />
                    <button @click="submitReply(comment.id)" class="send-btn">Send</button>
                </div>

                <!-- Danh sách reply, now properly nested under the respective comment -->
                <ul class="reply-list">
                    <li v-for="reply in comment.replies" :key="reply.id" class="reply-item">
                        <div class="reply-header">
                            <div class="user-info">
                                <div class="user-avatar">
                                    <img :src="reply.user.image" alt="avatar" class="user-avatar">
                                </div>
                                <div class="user-name-time">
                                    <div class="username">{{ reply.user.userName }}</div>
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