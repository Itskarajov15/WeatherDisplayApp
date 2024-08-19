<template>
    <div class="text-center">
        <p class="text-red-400">{{ errorMessage }}</p>
    </div>
</template>

<script setup>
import { defineProps } from 'vue';
defineProps({
    errorMessage: {
        type: String
    }
})
</script>