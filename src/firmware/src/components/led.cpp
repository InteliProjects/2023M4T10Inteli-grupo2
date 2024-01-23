#include "components/led.hpp"

using namespace components;

LED::LED(uint8_t redPin, uint8_t greenPin, uint8_t bluePin) : redPin(redPin), greenPin(greenPin), bluePin(bluePin)
{
    pinMode(this->redPin, OUTPUT);
    pinMode(this->greenPin, OUTPUT);
    pinMode(this->bluePin, OUTPUT);
}

void LED::lightUpGreen()
{
    turnOffLight();
    digitalWrite(greenPin, LOW);
}

void LED::lightUpRed()
{
    turnOffLight();
    digitalWrite(redPin, LOW);
}

void LED::lightUpBlue()
{
    turnOffLight();
    digitalWrite(bluePin, LOW);
}

void LED::lightUpMixed(uint8_t red, uint8_t green, uint8_t blue)
{
    turnOffLight();
    digitalWrite(redPin, red);
    digitalWrite(greenPin, green);
    digitalWrite(bluePin, blue);
}

void LED::turnOffLight()
{
    digitalWrite(redPin, HIGH);
    digitalWrite(greenPin, HIGH);
    digitalWrite(bluePin, HIGH);
}