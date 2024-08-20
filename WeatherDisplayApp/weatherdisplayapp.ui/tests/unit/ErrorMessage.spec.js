import { mount } from '@vue/test-utils'
import ErrorMessage from '@/components/ErrorMessage.vue'

describe('ErrorMessage.vue', () => {
    it('should display error when passed through props', () => {
        const errorMessage = 'Invalid input'
        const wrapper = mount(ErrorMessage, {
            propsData: {
                errorMessage
            }
        })

        console.log(wrapper.html())

        expect(wrapper.find("p").text()).toBe("Invalid input")
    })
})