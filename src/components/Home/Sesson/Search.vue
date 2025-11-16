<template>
  <div class="position-relative">
    <div class="input-group">
      <input 
        v-model="query" 
        @input="handleSearch"
        @keydown.enter="goToSearchPage" 
        class="form-control form-control-lg p-3 pe-5 rounded-pill"
        :placeholder="$t('home.search')" 
        type="text" 
      />
      <button 
        @click="goToSearchPage"
        class="btn position-absolute end-0 top-50 translate-middle-y me-3"
        style="z-index: 10; background-color: white; border-color: #dee2e6; color: #6C63FF;"
      >
        <i class="fas fa-search"></i>
      </button>
    </div>

    <!-- Dropdown search results -->
    <div 
      v-if="showDropdown && filteredCourses.length > 0" 
      class="search-dropdown position-absolute w-100 mt-1"
      style="z-index: 1000;"
    >
      <div class="bg-white border rounded shadow-lg p-2">
        <div 
          v-for="course in filteredCourses" 
          :key="course.id"
          class="search-result-item p-2 border-bottom cursor-pointer"
          @click="selectCourse(course)"
        >
          <div class="d-flex align-items-center">
            <img 
              :src="course.image" 
              :alt="course.title"
              class="rounded me-3"
              width="40" 
              height="40"
              style="object-fit: cover;"
            />
                         <div class="flex-grow-1">
               <h6 class="mb-0 fw-bold text-dark">{{ course.title }}</h6>
               <small class="text-muted">{{ course.features?.slice(0, 1).join(', ') }}</small>
             </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'
import { useRouter } from 'vue-router'
import { getCourses } from '@/services'
import i18n from '@/i18n'

const query = ref('')
const router = useRouter()
const showDropdown = ref(false)
const filteredCourses = ref<any[]>([])
const allCourses = ref<any[]>([])

// Fetch all courses on mount
const fetchCourses = async () => {
  try {
    const res = await getCourses()
    const resdata = res.data
    
    const locale = i18n.global.locale.toUpperCase()
    const nameKey = `title${locale}`
    const desKey = `des${locale}`
    
    allCourses.value = resdata.map((course: any) => ({
      id: course.id,
      title: course[nameKey],
      image: course.img || 'https://storage.googleapis.com/a1aa/image/yvPg3N_DvR7Qpi4FXfhUbwPadENaDLYvzVGnrJoYJr8.jpg',
      features: course[desKey]?.split('. ') || []
    }))
  } catch (error) {
    console.error('Error fetching courses:', error)
  }
}

// Handle search input
const handleSearch = () => {
  const searchTerm = query.value.trim().toLowerCase()
  
  if (searchTerm.length === 0) {
    showDropdown.value = false
    filteredCourses.value = []
    return
  }
  
  // Filter courses based on search term
  filteredCourses.value = allCourses.value.filter(course => 
    course.title.toLowerCase().includes(searchTerm) ||
    course.features.some((feature: string) => 
      feature.toLowerCase().includes(searchTerm)
    )
  ).slice(0, 5) // Limit to 5 results
  
  showDropdown.value = filteredCourses.value.length > 0
}

// Select a course from dropdown
const selectCourse = (course: any) => {
  query.value = course.title
  showDropdown.value = false
  router.push(`/detail-course/${course.id}`)
}

// Handle click outside to close dropdown
const handleClickOutside = (event: Event) => {
  const target = event.target as HTMLElement
  if (!target.closest('.position-relative')) {
    showDropdown.value = false
  }
}

const goToSearchPage = () => {
  const courseName = query.value.trim()
  if (courseName) {
    router.push(`/search/${courseName}`)
  } else {
    router.push('/search')
  }
  showDropdown.value = false
}

onMounted(() => {
  fetchCourses()
  document.addEventListener('click', handleClickOutside)
})

onUnmounted(() => {
  document.removeEventListener('click', handleClickOutside)
})
</script>

<style scoped>
.search-dropdown {
  max-height: 300px;
  overflow-y: auto;
}

.search-result-item {
  transition: background-color 0.2s ease;
}

.search-result-item:hover {
  background-color: #f8f9fa;
}

.cursor-pointer {
  cursor: pointer;
}

/* Custom scrollbar for dropdown */
.search-dropdown::-webkit-scrollbar {
  width: 6px;
}

.search-dropdown::-webkit-scrollbar-track {
  background: #f1f1f1;
  border-radius: 3px;
}

.search-dropdown::-webkit-scrollbar-thumb {
  background: #c1c1c1;
  border-radius: 3px;
}

.search-dropdown::-webkit-scrollbar-thumb:hover {
  background: #a8a8a8;
}
</style>