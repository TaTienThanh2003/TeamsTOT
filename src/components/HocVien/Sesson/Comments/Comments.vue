<script setup lang="ts">
import CommentItem from './CommentItem.vue';

</script>

<template>
    <div class="tab-pane fade" id="comments">
        <div class="container py-4">
            <div class="card mb-4 shadow-sm">
                <div class="card-body">
                    <form id="commentForm">
                        <div class="mb-3">
                            <label for="commentName" class="form-label">Tên của bạn</label>
                            <input type="text" class="form-control" id="commentName" required />
                        </div>
                        <div class="mb-3">
                            <label for="commentText" class="form-label">Bình luận</label>
                            <textarea class="form-control" id="commentText" rows="3" required></textarea>
                        </div>
                        <button type="submit" class="btn btn-primary">Gửi bình luận</button>
                    </form>
                </div>
            </div>

            <div id="commentList">
                <CommentItem />
            </div>
        </div>
    </div>

</template>