export async function getWeather(cityName) {
    const response = await fetch(`https://localhost:7279/api/weather/${cityName}`);

    if (response.status === 400) {
      throw new Error("Bad Request: The name of the city is required.");
    } else if (response.status === 404) {
      throw new Error("Not Found: The city was not found.");
    } else if (!response.ok) {
      throw new Error("An error occurred while fetching the data.");
    }

    const data = await response.json();

    return data;
}