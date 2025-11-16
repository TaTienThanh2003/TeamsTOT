<script setup lang="ts">
import { defineProps , computed} from 'vue'

const props = defineProps<{
    name : string
    content : string
}>()
</script>
<template>
    <div class="col-md-8">
        <div class="card p-3 mb-3 shadow-sm">
            <strong>{{name}}</strong>
            <div class="text-warning mb-1">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
            </div>
            <p class="mb-0">{{content}}</p>
        </div>
    </div>
</template>