<template>
    <div class="text-center">
        <h1 class="text-5xl text-white font-bold capitalize">{{ cityName }}</h1>
        <div class="flex gap-2 align-center justify-center">
            <div class="flex gap-2 align-center justify-center">
                <img class="w-40 h-40" :src="`https://openweathermap.org/img/w/${weatherDetails.weather[0].icon}.png`" alt="Weather Icon">
            </div>
        </div>
        <p class="text-white text-3xl">{{ weatherDetails.weather[0].main }}</p>

        <div class="flex justify-around mt-10 w-3/4 mx-auto">
            <TemperatureCard :temperature="weatherDetails.main.temp" measurement="Kelvin" />
            <TemperatureCard :temperature="weatherDetails.main.tempInCelsius" measurement="Celsius" />
            <TemperatureCard :temperature="weatherDetails.main.tempInFarenhait" measurement="Farenhait" />
        </div>  
    </div>
</template>

<script setup>
import { defineProps } from 'vue';
import TemperatureCard from './TemperatureCard.vue';

defineProps({
    cityName: {
        type: String
    },
    weatherDetails: {
        type: Object
    }
})
</script>