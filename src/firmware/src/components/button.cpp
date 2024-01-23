#include "components/button.hpp"

using namespace components;

Button::Button(uint8_t pin) : pin(pin)
{
    pinMode(pin, INPUT_PULLUP);
}

bool Button::isPressed()
{
    return digitalRead(pin) == HIGH;
}