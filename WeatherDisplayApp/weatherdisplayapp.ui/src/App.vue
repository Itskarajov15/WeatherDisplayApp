<template>
  <div class="h-full w-full p-10 bg-[#111b2c]">
    <div class="w-1/2 mx-auto">
      <form class="flex gap-2 align-center justify-center" @submit.prevent="onSearch">
        <input type="text" v-model="cityName" value="Sofia" class="p-2 bg-[#202B3D] text-white rounded-md border-none outline-none">
        <button class="bg-transparent text-white outline-none border-none" type="submit">Search</button>
      </form>
      <ErrorMessage class="mt-1" v-if="errorMessage != null" :error-message="errorMessage" />
    </div>

    <CityWeatherDetails v-if="weather != null" class="mt-10" :city-name="cityName" :weatherDetails="weather" />
  </div>
</template>

<script setup>
import { ref, watch } from 'vue';
import CityWeatherDetails from './components/CityWeatherDetails.vue';
import ErrorMessage from './components/ErrorMessage.vue';
import { getWeather } from './services/getWeatherService';

const cityName = ref('');
const weather = ref(null);
const errorMessage = ref(null);

async function onSearch() {  
  errorMessage.value = null;

  try {
    const data = await getWeather(cityName.value);

    weather.value = data;
  } catch (err) {
    errorMessage.value = err.message;
  }
}

watch(cityName, () => {
  weather.value = null;
});
</script>

<style>
#app {
  height: 100vh;
  width: 100%;
}
</style>