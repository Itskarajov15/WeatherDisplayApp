import { mount } from '@vue/test-utils'
import CityWeatherDetails from '@/components/CityWeatherDetails.vue'

describe('CityWeatherDetails.vue', () => {
    let wrapper;
    let cityName;

    beforeEach(() => {
        cityName = 'Sofia'
        const weatherDetails = {
            main: {
                temp: 25.5,
                tempInCelsius: 25.5,
                tempInFarenhait: 77.9,
            },
            weather: [
                {
                    main: 'Clouds',
                    desciption: 'broken clouds',
                    icon: '04n'
                }
            ]
        }
    
        wrapper = mount(CityWeatherDetails, {
            propsData: {
                cityName,
                weatherDetails
            }
        })
    })

    it('should display correct image', () => {
        const imagePath = 'https://openweathermap.org/img/w/04n.png'

        console.log(wrapper.html())

        const img = wrapper.find('img');
        expect(img.exists()).toBe(true);
        expect(img.attributes('src')).toBe(imagePath);
    })

    it('should contains correct name of city', () => {
        console.log(wrapper.html())

        const h1 = wrapper.find('h1');
        expect(h1.exists()).toBe(true);
        expect(h1.text()).toBe(cityName);
    })
})