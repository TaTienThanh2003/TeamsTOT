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
                <div class="card mb-3">
                    <div class="card-body">
                        <h6 class="fw-bold">Nguyễn Văn A</h6>
                        <p class="mb-0">Bài học hôm nay rất hay. Cảm ơn trung tâm!</p>
                        <small class="text-muted">Vừa xong</small>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>