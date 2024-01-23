#include "connection/MQTTConnection.hpp"

using namespace connection;

MQTTConnection::MQTTConnection(Config &mqttConfig) 
    : mqttConfig(mqttConfig), mqtt(PubSubClient(mqttConfig.wifiConnection.wifiClient)), wifi(mqttConfig.wifiConnection)
{
    
}

String MQTTConnection::message = "";

void MQTTConnection::init()
{
    mqttConfig.connectionLed.lightUpMixed(0, 0, 1); // yellow stands for connecting
    wifi.connectWifi();
    mqtt.setServer(mqttConfig.broker, mqttConfig.port);
    mqtt.setCallback(receiveDataCallback);
    connectMQTT();
}

void MQTTConnection::keep()
{
    maintainConnection();
    mqtt.loop();
}

void MQTTConnection::sendMessage(String payload)
{
    Serial.print("Publicando mensagem: ");
    Serial.println(payload);

    mqtt.publish(mqttConfig.publishTopic, payload.c_str());
}

void MQTTConnection::receiveDataCallback(char* topic, byte* payload, unsigned int length)
{
        String msg;

        for(int i = 0; i < length; i++)
        {
            char c = (char)payload[i];
            msg += c;
        }

        message = msg;
        Serial.println("Received message: [" + message + "].");
}

String MQTTConnection::retrieveMessage()
{
    return message;
}

void MQTTConnection::maintainConnection()
{
    if (wifi.isWifiNotConnected())
    {
        wifi.connectWifi();
    }

    if (isMQTTNotConnected())
    {
        connectMQTT();
    }
}

bool MQTTConnection::isMQTTNotConnected()
{
    return !mqtt.connected();
}

void MQTTConnection::connectMQTT()
{

    while (isMQTTNotConnected()) {
        Serial.print("Conectando ao Broker MQTT: ");
        Serial.println(mqttConfig.broker);

        if (mqtt.connect(mqttConfig.clientId, mqttConfig.username, mqttConfig.password)) {
            Serial.println("Conectado ao Broker com sucesso!");
            
            Serial.print("Publicando no tópico: ");
            Serial.println(mqttConfig.publishTopic);

            mqtt.subscribe(mqttConfig.subTopic);
            
            Serial.print("Inscrito no tópico: ");
            Serial.println(mqttConfig.subTopic);
        }

        else {
            Serial.println("Não foi possível se conectar ao broker.");
            Serial.println("Nova tentativa de conexão em 5s");
            delay(5000);
        }
    }

    mqttConfig.connectionLed.lightUpGreen(); // green stands for connected
}