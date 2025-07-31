<script setup lang="ts">
import { deleteUser, getUser } from '@/services';
import { computed, onMounted, ref } from 'vue';

const users = ref<Array<{
  id: number;
  name: string;
  des: string;
  email: string;
  phone: string;
  image: string;
  role: string;
}>>([]);

const activeRole = ref<string>('all');

const showUser = async () => {
  try {
    const res = await getUser();
    const resdata = res.data;
    users.value = resdata.map((user: any) => ({
      id: user.id,
      name: user.fullName,
      des: user.des,
      email: user.email,
      phone: user.phone,
      image: user.image,
      role: user.role
    }));
  } catch (err: any) {
    console.log(err);
  }
}
const removeUser = async (userId: number) => {
  try {
    const res = await deleteUser(userId);
    console.log(res)
    showUser()
  } catch (error: any) {
    console.log(error)
  }
}
onMounted(() => {
  showUser();
});

const filteredUsers = computed(() => {
  if (activeRole.value === 'all') return users.value;
  return users.value.filter(user => user.role.toLowerCase() === activeRole.value);
});

const setActiveRole = (role: string) => {
  activeRole.value = role;
};
</script>

<template>
  <div>
    <div class="d-flex justify-content-between align-items-center mb-3">
      <h4 class="fs-4 text-center fw-bold ">QUẢN LÝ THÀNH VIÊN</h4>
      <button class="btn btn-outline-primary">+ Thêm người dùng</button>
    </div>

    <div class="d-flex justify-content-between align-items-center mb-3">
      <ul class="nav nav-tabs mb-3">
        <li class="nav-item">
          <a class="nav-link" :class="{ active: activeRole === 'all' }" href="#"
            @click.prevent="setActiveRole('all')">Tất cả</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" :class="{ active: activeRole === 'user' }" href="#"
            @click.prevent="setActiveRole('user')">Học viên</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" :class="{ active: activeRole === 'teacher' }" href="#"
            @click.prevent="setActiveRole('teacher')">Giáo viên</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" :class="{ active: activeRole === 'staff' }" href="#"
            @click.prevent="setActiveRole('staff')">Nhân viên</a>
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
        <tr v-for="user in filteredUsers" :key="user.id">
          <td class="d-flex align-items-center">
            <img src="https://randomuser.me/api/portraits/men/32.jpg" class="table-avatar" />
            <div>
              <strong>{{ user.name }}</strong><br>
              <small class="text-muted">{{ user.des }}</small>
            </div>
          </td>
          <td>{{ user.email }}</td>
          <td>{{ user.phone }}</td>
          <td>{{ user.role }}</td>
          <td><button class="btn btn-sm btn-outline-success mx-1" title="Sửa">
              <i class="fa fa-edit"></i>
            </button>
            <button class="btn btn-sm btn-outline-danger mx-1" title="Xóa" @click="removeUser(user.id)">
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