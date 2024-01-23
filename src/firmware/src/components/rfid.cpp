#include "components/rfid.hpp"

using namespace components;

RFID::RFID(uint8_t sdaPin, uint8_t rstPin) : mfrc522(MFRC522(sdaPin, rstPin))
{
}

void RFID::init()
{
    SPI.begin();
    mfrc522.PCD_Init();
}

bool RFID::available()
{
    return mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial();
}

String RFID::getUuid()
{
    byte *uid = mfrc522.uid.uidByte;
    String uuid = "";

    for (byte i = 0; i < mfrc522.uid.size; i++)
    {
        uuid += String(uid[i], HEX);
        if (i < mfrc522.uid.size - 1)
        {
            uuid += ":";
        }
    }
    return uuid;
}