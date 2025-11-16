<script setup lang="ts">
import { ref, onMounted, watch } from 'vue';
import TasksModel from './TasksModel.vue';

const emit = defineEmits(['back']);

const questions = ref<any[]>([]);
const currentQuestionIndex = ref(0);
const selectedAnswers = ref(questions.value.map(() => null))

const totalQuestions = ref(0);
const isLoading = ref(true);
const showModel = ref(false)

onMounted(async () => {
    try {
        const response = await fetch('https://script.google.com/macros/s/AKfycbwz31wK7enHmPzg6kzT6nuW6RJ2izTx75YiLMb55azJhoHJPK6A8-BeAGd2D0TZQvwL/exec');
        if (!response.ok) throw new Error('Lỗi khi tải dữ liệu');

        const data = await response.json();
        questions.value = data;
        totalQuestions.value = data.length;
    } catch (err) {
        console.log(err)
    } finally {
        isLoading.value = false;
    }
});

function goToQuestion(index: number) {
    if (index >= 0 && index < totalQuestions.value) {
        currentQuestionIndex.value = index;
    }
}

const checkResults = questions.value.map((q, i) => {
    const userAnswer = selectedAnswers.value[i];
    const correctAnswer = q.answers[q.correct_index];
    const isCorrect = userAnswer === correctAnswer;
    return {
        question: q.question,
        userAnswer,
        correctAnswer,
        isCorrect
    };
});

const correctCount = checkResults.filter(r => r.isCorrect).length;

const handelSubmit = () => {
    console.log('Selected:', selectedAnswers.value) // ✅ kiểm tra xem mảng có dữ liệu chưa

    if (selectedAnswers.value.some(a => a === null)) {
        alert('Bạn chưa chọn hết đáp án')
        return
    }
    showModel.value = true;
}

</script>


<template>
    <TasksModel v-if="showModel" :correctCount="correctCount" />
    <div class="container">
        <div class="test-container">
            <div v-if="isLoading">Đang tải dữ liệu...</div>

            <div v-else>
                <div class="row mb-4">
                    <div class="col-md-9">
                        <button class="btn btn-sm btn-outline-secondary mb-3" @click="emit('back')">← Quay lại danh
                            sách</button>
                        <h2 class="text-center font-blue bold fs-3">Bài kiểm tra số 1</h2>
                        <div class="d-flex justify-content-between mb-3">
                            <strong>Câu hỏi {{ currentQuestionIndex + 1 }}</strong>
                        </div>

                        <p>{{ questions[currentQuestionIndex].question }}</p>

                        <form>
                            <div class="form-check" v-for="(option, index) in questions[currentQuestionIndex].answers"
                                :key="index">
                                <input class="form-check-input" type="radio" :name="'answer' + currentQuestionIndex"
                                    :id="'a' + currentQuestionIndex + '-' + index" :value="option"
                                    v-model="selectedAnswers[currentQuestionIndex]" />
                                <label class="form-check-label" :for="'a' + currentQuestionIndex + '-' + index">
                                    {{ option }}
                                </label>
                            </div>

                            <div class="d-flex justify-content-between mb-3 mt-3">
                                <button class="btn btn-primary" @click.prevent="goToQuestion(currentQuestionIndex - 1)"
                                    :disabled="currentQuestionIndex === 0">
                                    &larr; Trước
                                </button>
                                <button class="btn btn-primary" @click.prevent="goToQuestion(currentQuestionIndex + 1)"
                                    :disabled="currentQuestionIndex === totalQuestions - 1">
                                    Tiếp &rarr;
                                </button>
                            </div>
                        </form>
                    </div>

                    <div class="col-md-3">
                        <div class="mb-3">
                            <strong>Thời gian còn lại</strong><br />
                            00 : 15 : 30
                        </div>
                        <div class="mb-3">
                            <button class="btn btn-primary" @click="handelSubmit">Nộp bài</button>
                        </div>
                        <p class="text-warning mb-3">
                            Chú ý: bạn có thể click vào số thứ tự câu hỏi trong bài để đánh dấu review
                        </p>
                        <div class="mb-3">
                            <strong>Câu hỏi</strong><br />
                            <div class="mt-2 d-flex flex-wrap gap-2 question-nav">
                                <button v-for="(q, i) in questions" :key="i"
                                    class="btn btn-customer btn-outline-secondary btn-sm"
                                    :class="{ active: !!selectedAnswers[i] }" @click="goToQuestion(i)">
                                    {{ i + 1 }}
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<style scoped>
.test-container {
    background-color: #fff;
    border-radius: 10px;
    padding: 30px;
    margin: 30px auto;
    max-width: 1000px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.question-nav button.active {
    background-color: #4a89ff !important;
    color: white !important;
}

.btn-customer {
    min-width: 2rem;
}
</style>
