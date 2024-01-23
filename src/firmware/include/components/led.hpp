#include <Arduino.h>

namespace components
{
    class LED
    {
    public:
        LED(uint8_t redPin, uint8_t greenPin, uint8_t bluePin);

        /**
        * @brief Lights the LED up with the color green.
        */
        void lightUpGreen();

        /**
        * @brief Lights the LED up with the color red.
        */
        void lightUpRed();

        /**
        * @brief Lights the LED up with the color blue.
        */
        void lightUpBlue();

        /**
        * @brief Lights the LED up mixing colors. The parameters should be 0 or 1 always.
        */
        void lightUpMixed(uint8_t red, uint8_t green, uint8_t blue);
        
    private:
        /**
        * @brief Turns the LED off.
        */
        void turnOffLight();
        uint8_t redPin;
        uint8_t greenPin;
        uint8_t bluePin;
    };
};