#include <Arduino.h>
#include "connection/connectionData.hpp"
#include "stateMachine/MQTTStateMachine.hpp"

#include "components/button.hpp"

components::RFID rfid(21, 22);

components::Buzzer buzzer(17);

components::LED led(32, 33, 25);

components::Button deactivateSystemButton(26);

components::Button activateSystemButton(27);

connection::WifiConnection::Config wifiConfig =
{
    .ssid = connectionData::SSID,
    .password = connectionData::password,
    .certificate = connectionData::rootCA
};

connection::WifiConnection wifiConnection(wifiConfig);

connection::MQTTConnection::Config mqttConfig =
{
    .broker = connectionData::broker,
    .port = connectionData::port,
    .clientId = connectionData::clientId,
    .username = connectionData::mqttUsername,
    .password = connectionData::mqttPassword,
    .publishTopic = connectionData::publishTopic,
    .subTopic = connectionData::subTopic,
    .wifiConnection = wifiConnection,
    .connectionLed = led
};

stateMachine::MQTTSM MQTTStateMachine(mqttConfig, rfid, buzzer);