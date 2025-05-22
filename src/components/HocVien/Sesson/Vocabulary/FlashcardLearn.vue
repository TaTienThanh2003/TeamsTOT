<template>
    <div class="container py-4">
        <div class="d-flex justify-content-between align-items-center mb-3 flex-wrap gap-2">
            <div>
                <a href="#" class="text-primary small me-3">
                    <span class="material-symbols-outlined align-middle">arrow_back</span> Xem tất cả
                </a>

                <a href="#" class="text-primary small">
                    <span class="material-symbols-outlined align-middle">playlist_remove</span> Các từ đã bỏ qua
                </a>
            </div>
            <button class="btn btn-outline-danger btn-sm">
                <span class="material-symbols-outlined align-middle">stop_circle</span> Dừng học list từ này
            </button>
        </div>

        <div class="card text-center shadow-sm rounded-4 mb-4 position-relative" style="min-height: 220px;">
            <div class="card-body d-flex flex-column justify-content-center align-items-center">
                <span class="badge bg-warning text-dark position-absolute top-0 end-0 m-2">Từ mới</span>
                <h4 class="fw-bold text-dark mb-2">
                    {{ currentWord.word }}
                    <button class="btn btn-link p-0 ms-2" @click="playAudio" aria-label="Play audio">
                        <span class="material-symbols-outlined">volume_up</span>
                    </button>
                </h4>
                <p class="text-muted fst-italic">({{ currentWord.type }}) /{{ currentWord.pronunciation }}/</p>
            </div>
            <button class="btn btn-light position-absolute bottom-0 end-0 m-3" @click="flipCard" aria-label="Flip card">
                <span class="material-symbols-outlined">autorenew</span>
            </button>
        </div>

        <div class="card border-0 shadow-sm rounded-4 text-center">
            <div class="card-body d-flex justify-content-around flex-wrap gap-2">
                <button class="btn btn-outline-success px-4" @click="markLevel('easy')">
                    <span class="material-symbols-outlined align-middle text-success">check_circle</span> Dễ
                </button>
                <button class="btn btn-outline-warning px-4" @click="markLevel('medium')">
                    <span class="material-symbols-outlined align-middle text-warning">report_problem</span> Trung bình
                </button>
                <button class="btn btn-outline-danger px-4" @click="markLevel('hard')">
                    <span class="material-symbols-outlined align-middle text-danger">error</span> Khó
                </button>
                <button class="btn btn-outline-secondary px-4" @click="markLevel('known')">
                    <span class="material-symbols-outlined align-middle text-secondary">fast_forward</span> Đã biết
                </button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const currentWord = ref({
    word: "sack",
    type: "noun",
    pronunciation: "sæk",
    audio: "path-to-audio.mp3",
});

const playAudio = () => {
    const audio = new Audio(currentWord.value.audio);
    audio.play();
};

const flipCard = () => {
};

const markLevel = (level: 'easy' | 'medium' | 'hard' | 'known') => {
    console.log("Marked as:", level);
};
</script>
