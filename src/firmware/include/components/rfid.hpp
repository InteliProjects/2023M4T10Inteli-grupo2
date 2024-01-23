#include <Arduino.h>
#include <SPI.h>
#include <MFRC522.h>

namespace components
{
    class RFID
    {
    public:
        RFID(uint8_t sdaPin, uint8_t rstPin);

        /**
         * @brief Initializes the RFID reader
         */
        void init();

        /**
         * @brief Returns true if a tag can be read
         */
        bool available();

        /**
         * @brief Returns the UUID of a tag 
         */
        String getUuid();

    private:
        MFRC522 mfrc522;
    };
};