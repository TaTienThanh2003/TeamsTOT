<script>
</script>

<template>
  <div class="tab-pane fade active" id="my-members">
    <div class="d-flex justify-content-between align-items-center mb-3">
      <h4 class="fs-4 text-center fw-bold ">QUẢN LÝ THÀNH VIÊN</h4>
      <button class="btn btn-outline-primary">+ Thêm người dùng</button>
    </div>

    <div class="d-flex justify-content-between align-items-center mb-3">
      <ul class="nav nav-tabs mb-3">
        <li class="nav-item">
          <a class="nav-link active" href="#">Tất cả</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Học viên</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Giáo viên</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Nhân viên</a>
        </li>
      </ul>

      <div class="mb-3">
        <input type="text" class="form-control" placeholder="Search" style="min-width: 300px;">
      </div>
    </div>

    <table class="table table-hover align-middle">
      <thead>
        <tr>
          <th>Họ và tên</th>
          <th>Email</th>
          <th>Số điện thoại</th>
          <th>Vai trò</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <!-- Sample Row -->
        <tr>
          <td class="d-flex align-items-center">
            <img src="https://randomuser.me/api/portraits/men/32.jpg" class="table-avatar" />
            <div>
              <strong>Edgar Rivera</strong><br>
              <small class="text-muted">Fishermen Labs</small>
            </div>
          </td>
          <td>Office Member<br><strong>$79.00</strong></td>
          <td>Credit Card</td>
          <td>Người dùng</td>
          <td><button class="btn btn-sm btn-outline-success mx-1" title="Sửa">
              <i class="fa fa-edit"></i>
            </button>
            <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
              <i class="fa fa-trash"></i>
            </button>
          </td>
        </tr>

        <tr class="active-row">
          <td class="d-flex align-items-center">
            <img src="https://randomuser.me/api/portraits/women/65.jpg" class="table-avatar" />
            <div>
              <strong>Priya Bollam</strong><br>
              <small class="text-muted">Airbnb</small>
            </div>
          </td>
          <td>Part-Time<br><strong>$79.00</strong></td>
          <td>Credit Card</td>
          <td>Giao vien</td>
          <td><button class="btn btn-sm btn-outline-success mx-1" title="Sửa">
              <i class="fa fa-edit"></i>
            </button>
            <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa">
              <i class="fa fa-trash"></i>
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- Pagination -->
    <nav>
      <ul class="pagination justify-content-center">
        <li class="page-item disabled"><a class="page-link" href="#">«</a></li>
        <li class="page-item active"><a class="page-link" href="#">1</a></li>
        <li class="page-item"><a class="page-link" href="#">2</a></li>
        <li class="page-item"><a class="page-link" href="#">...</a></li>
        <li class="page-item"><a class="page-link" href="#">10</a></li>
        <li class="page-item"><a class="page-link" href="#">»</a></li>
      </ul>
    </nav>
  </div>
</template>

<style scoped>
.table-avatar {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  object-fit: cover;
  margin-right: 10px;
}

.active-row {
  background-color: #eafaf1;
}
</style>