#include "components/buzzer.hpp"

using namespace components;

Buzzer::Buzzer(uint8_t pin) : pin(pin)
{
    pinMode(pin, OUTPUT);
}

void Buzzer::playRead()
{
    tone(this->pin, 960, 500);
}

void Buzzer::playEmergency()
{
    tone(this->pin, 440, 500);
}