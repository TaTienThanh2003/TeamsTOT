<template>
  <div class="position-relative">

    <input v-model="query" @keydown.enter="goToSearchPage" class="form-control form-control-lg p-3 pe-5 rounded-pill"
      :placeholder="$t('home.search')" type="text" />

    <i class="fas fa-search search-icon"></i>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'
import { useRouter } from 'vue-router'


const query = ref('')
const router = useRouter()


// const goToCourse = (id: string | number) => {
//   router.push(`/course/${id}`)
// }

const goToSearchPage = () => {
  const courseName = query.value.trim()
  if (courseName) {
    router.push(`/search/${courseName}`)
  } else {
    router.push('/search')
  }
}
</script>

<style scoped>
.search-icon {
  position: absolute;
  top: 50%;
  right: 3.8rem;
  transform: translateY(-50%);
  color: #a3a3a3;
  font-size: 1.5rem;
  padding-right: 1rem;
  pointer-events: none;
  z-index: 10;
}
</style>