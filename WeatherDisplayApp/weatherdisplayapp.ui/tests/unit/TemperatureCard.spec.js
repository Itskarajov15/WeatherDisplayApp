import { mount } from '@vue/test-utils'
import TemperatureCard from '@/components/TemperatureCard.vue'

describe('TemperatureCard.vue', () => {
    it('displays correct data for temperature and temperature measurement', () => {
        const temperature = 25.5
        const measurement = 'Celsius'
        const wrapper = mount(TemperatureCard, {
            propsData: {
                temperature,
                measurement
            }
        })

        console.log(wrapper.html())

        const [textMeasurement, textTemperature] = wrapper.findAll("p")

        expect(textMeasurement.text()).toBe("Temperature in Celsius")
        expect(textTemperature.text()).toBe('25.50')
    })
})