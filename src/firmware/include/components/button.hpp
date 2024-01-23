#include <Arduino.h>

namespace components
{
    class Button
    {
    public:
        Button(uint8_t pin);

        /**
        * @brief Returns true if the button is being pressed.
        */
        bool isPressed();

    private:
        uint8_t pin;
    };
};