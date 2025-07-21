<script setup lang="ts">
import { onMounted, ref } from 'vue';
import VocabularyItem from './VocabularyItem.vue';
import CreateVocabulary from './CreateVocabulary.vue';
import FlashcardLearn from './FlashcardLearn.vue';
import { getTopic } from '@/services';
import { useToast } from 'vue-toastification';

const currentTab = ref('mine');
const selectedWord = ref<any>(null);
const showFlashcardLearn = ref(false);
const topics = ref<any>([]);
const toast = useToast();

// Dữ liệu mẫu
const flashcardLists = [
    {
        title: "900 từ TOEFL (có ảnh)",
        wordCount: 899,
        learners: 5400,
        author: "study4",
        avatar: "https://via.placeholder.com/32x32.png?text=S4",
        wordData: {
            word: "abandon",
            type: "verb",
            phonetic: "əˈbændən",
            definition: "bỏ rơi, ruồng bỏ",
            example: "We should not abandon veterans.",
            image: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Abandonment.jpg/220px-Abandonment.jpg"
        }
    },
    {
        title: "900 từ TOEFL (có ảnh)",
        wordCount: 899,
        learners: 5400,
        author: "study4",
        avatar: "https://via.placeholder.com/32x32.png?text=S4",
        wordData: {
            word: "abandon",
            type: "verb",
            phonetic: "əˈbændən",
            definition: "bỏ rơi, ruồng bỏ",
            example: "We should not abandon veterans.",
            image: "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/Abandonment.jpg/220px-Abandonment.jpg"
        }
    },

];
const showTopics = async () => {
    try {
        const res = await getTopic();
        const resdata = res.data;
        topics.value = resdata.map((topic : any) => {
            id: topic.id;
            name: topic.name;
            wordCount : topic.wordCount;
            imageUrl : topic.imageUrl;
        })
    } catch (error) {
        console.log(error)
    }
}
const handleSelectWord = (list: any) => {
    selectedWord.value = list.wordData;
};

const goBackToList = () => {
    selectedWord.value = null;
};
function handleListCreated() {
    console.log('Đã tạo list mới!');
}
onMounted(() => {
    showTopics();
})
</script>

<template>
    <div class="tab-pane fade show active" id="vocabulary">
        <div class="container py-2">
            <div v-if="!(selectedWord || showFlashcardLearn)">
                <ul class="nav mb-5 gap-4 ">
                    <li class="nav-item">
                        <span class="nav-link-tab" :class="{ active: currentTab === 'explore' }"
                            @click="currentTab = 'explore'">
                            Khám phá
                        </span>
                    </li>
                    <li class="nav-item">
                        <span class="nav-link-tab" :class="{ active: currentTab === 'learning' }"
                            @click="currentTab = 'learning'">
                            Đang học
                        </span>
                    </li>
                    <li class="nav-item">
                        <span class="nav-link-tab" :class="{ active: currentTab === 'mine' }"
                            @click="currentTab = 'mine'">
                            List của tôi
                        </span>
                    </li>
                </ul>

                <div v-show="currentTab === 'learning' && !selectedWord">
                    <p class="fst-italic text-muted">Bạn chưa học list từ nào. <a href="#">Khám phá ngay</a></p>
                </div>

                <div v-show="currentTab === 'mine' && !selectedWord">
                    <div class="row g-3">
                        <div class="col-6 col-md-4">
                            <div class="border border-secondary rounded-3 p-4 text-center bg-white h-100 d-flex flex-column justify-content-center align-items-center"
                                style="cursor: pointer;" data-bs-toggle="modal" data-bs-target="#createVocabularyModal">
                                <div class="display-6 text-primary">+</div>
                                <div class="mt-2 text-primary fw-semibold">Tạo list từ</div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-4 col-lg-3" v-for="(topic, i) in topics" :key="i"
                            @click="handleSelectWord(topic)" style="cursor: pointer;">
                            <div class="card h-100 shadow-sm">
                                <div class="card-body">
                                    <h6 class="card-title fw-bold">{{ topic.title }}</h6>
                                    <p class="card-text small text-muted">📄 {{ topic.wordCount }} từ | 👤 {{
                                        topic.learners
                                        }}</p>
                                </div>
                                <div class="card-footer bg-white border-top-0 d-flex align-items-center gap-2">
                                    <img :src="topic.avatar" alt="avatar" class="user-avatar" />
                                    <small class="text-muted">{{ topic.author }}</small>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Modal component -->
                    <CreateVocabulary @saved="handleListCreated" />
                </div>

                <div v-show="currentTab === 'explore' && !selectedWord">
                    <div class="row g-3">
                        <div class="col-sm-6 col-md-4 col-lg-3" v-for="(list, i) in flashcardLists" :key="i"
                            @click="handleSelectWord(list)" style="cursor: pointer;">
                            <div class="card h-100 shadow-sm">
                                <div class="card-body">
                                    <h6 class="card-title fw-bold">{{ list.title }}</h6>
                                    <p class="card-text small text-muted">📄 {{ list.wordCount }} từ | 👤 {{
                                        list.learners
                                        }}</p>
                                </div>
                                <div class="card-footer bg-white border-top-0 d-flex align-items-center gap-2">
                                    <img :src="list.avatar" alt="avatar" class="user-avatar" />
                                    <small class="text-muted">{{ list.author }}</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div v-if="selectedWord">
                <div class="d-flex justify-content-between align-items-center mb-4 flex-wrap gap-2">
                    <button class="btn btn-outline-secondary" @click="goBackToList">
                        <span class="material-symbols-outlined align-middle me-1">arrow_back</span>
                        Quay lại
                    </button>

                    <div class="d-flex gap-2">
                        <button class="btn btn-light border">
                            <span class="material-symbols-outlined align-middle me-1">shuffle</span>
                            Xem ngẫu nhiên
                        </button>
                        <button class="btn btn-primary" @click="showFlashcardLearn = true, selectedWord = false">
                            <span class="material-symbols-outlined align-middle me-1">play_arrow</span>
                            Bắt đầu luyện tập
                        </button>
                    </div>
                </div>

                <VocabularyItem :wordData="selectedWord" />
            </div>
            <FlashcardLearn v-if="showFlashcardLearn" @back="showFlashcardLearn = false, selectedWord = true" />
        </div>
    </div>
</template>

<style scoped>
.user-avatar {
    width: 36px;
    height: 36px;
    border-radius: 50%;
    background-color: #dbeafe;
}

.nav-link-tab {
    cursor: pointer;
    color: #333;
    font-weight: 500;
    transition: color 0.2s ease;
}

.nav-link-tab:hover {
    color: #0d6efd;
}

.nav-link-tab.active {
    color: #0d6efd;
    font-weight: 600;
}
</style>
