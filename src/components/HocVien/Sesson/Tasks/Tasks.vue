<script setup lang="ts">
import { ref } from 'vue';
import TaskItem from './TaskItem.vue';
import ShowTask from './ShowTask.vue';

const showDetail = ref(false);
const selectedTaskId = ref<number | null>(null);//chọn task theo courseId để lesson lấy dc hiển thị

const emit = defineEmits(['setTrue', 'setFalse'])

const onShowDetail = () => {
    emit('setTrue', true)
}

const onHiddenDetail: () => void = () => {
    emit('setFalse', false)
}

const openTaskDetail = (id: number) => {
    onHiddenDetail();
    selectedTaskId.value = id;
    showDetail.value = true;
};

const backToList = () => {
    onShowDetail();
    showDetail.value = false;
    selectedTaskId.value = null;
};
</script>

<template>
    <div class="tab-pane fade" id="tasks">
        <div v-if="!showDetail" class="exercise-list">
            <TaskItem @click="openTaskDetail(1)" />
            <TaskItem @click="openTaskDetail(2)" />
        </div>
        <ShowTask v-if="showDetail" :taskId="selectedTaskId" @back="backToList" />
    </div>
</template>
