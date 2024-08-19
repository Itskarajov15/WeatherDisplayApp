<template>
  <div class="h-full w-full p-10 bg-[#111b2c]">
    <div class="w-1/2 mx-auto">
      <form class="flex gap-2 align-center justify-center" @submit.prevent="onSearch">
        <input type="text" v-model="cityName" class="p-2 bg-[#202B3D] text-white rounded-md border-none outline-none">
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

const cityName = ref('');
const weather = ref(null);
const errorMessage = ref(null);

async function onSearch() {
  errorMessage.value = null;

  try {
    const response = await fetch(`https://localhost:7279/api/weather/${cityName.value}`);

    if (response.status === 400) {
      throw new Error("Bad Request: The name of the city is required.");
    } else if (response.status === 404) {
      throw new Error("Not Found: The city was not found.");
    } else if (!response.ok) {
      throw new Error("An error occurred while fetching the data.");
    }

    const data = await response.json();
    console.log(data);

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