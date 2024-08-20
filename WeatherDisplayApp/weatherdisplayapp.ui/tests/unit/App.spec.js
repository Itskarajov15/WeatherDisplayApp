import { mount } from '@vue/test-utils'
import App from '@/App.vue'
import { getWeather } from '@/services/getWeatherService'

jest.mock('@/services/getWeatherService');

describe('App.vue', () => {
    
    const weatherData = {
        "weather": [
            {
                "main": "Clouds",
                "description": "broken clouds",
                "icon": "04n"
            }
        ],
        "main": {
            "temp": 293.15,
            "tempInCelsius": 20,
            "tempInFarenhait": 68
        }
    }

    const cityName = 'Sofia'

    afterEach(() => {
        jest.clearAllMocks();
    });

    it('should search for weather details', () => {
        jest.mocked(getWeather).mockResolvedValueOnce(weatherData);

        const wrapper = mount(App)

        wrapper.find('input').setValue(cityName);
        wrapper.find('button').trigger('submit');

        expect(getWeather).toHaveBeenCalledTimes(1);
    })

    it('should catch error when city name is not found', async () => {
        jest.mocked(getWeather).mockRejectedValueOnce({message: 'Not Found: The city was not found.'});

        const wrapper = mount(App)

        wrapper.find('input').setValue(cityName);
        wrapper.find('button').trigger('submit');

        await wrapper.vm.$nextTick();
        await wrapper.vm.$nextTick();
        await wrapper.vm.$nextTick();
        await wrapper.vm.$nextTick();
        await wrapper.vm.$nextTick();

        expect(wrapper.html()).toContain('Not Found: The city was not found.');
    })
})