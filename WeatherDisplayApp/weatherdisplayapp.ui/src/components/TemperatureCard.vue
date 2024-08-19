<template>
    <div class="bg-[#202B3C] w-1/4 p-3 text-left rounded-md">
        <p class="text-[#7c8690] mb-1">Temperature in {{ measurement }}</p>
        <p class="text-white text-xl font-medium">{{ temperature.toFixed(2) }}</p>
    </div>
</template>

<script setup>
import { defineProps } from 'vue';

defineProps({
    temperature: {
        type: Number
    },
    measurement: {
        type: String
    }
})
</script>