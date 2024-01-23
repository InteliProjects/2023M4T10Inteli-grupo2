#include <Arduino.h>

namespace components
{
    class Buzzer
    {
    public:
        Buzzer(uint8_t pin);

        /**
        * @brief Plays the buzzer for half a second when a RFID tag is correctly read.
        */
        void playRead();

        /**
        * @brief Plays the buzzer for half a second when a RFID tag can't be read (emergency).
        */
        void playEmergency();
        
    private:
        uint8_t pin;
    };
};