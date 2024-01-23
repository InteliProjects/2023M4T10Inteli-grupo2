#include <WiFi.h>
#include <PubSubClient.h>
#include "connection/wifiConnection.hpp"
#include "components/led.hpp"

namespace connection 
{
    class MQTTConnection
    {
        public:
        struct Config
        {
            const char* broker;
            const uint16_t port;
            const char* clientId;
            const char* username;
            const char* password;
            const char* publishTopic;
            const char* subTopic;
            connection::WifiConnection &wifiConnection;
            components::LED &connectionLed;
        };

        MQTTConnection(Config &mqttConfig);

        /**
        * @brief Receives the data from the subscribed topic in the MQTT connection and stores it in the 
        * message string.
        */
        static void receiveDataCallback(char* topic, byte* payload, unsigned int length);

        /**
         * @brief Initializes the MQTT.
         */
        void init();

        /**
         * @brief Keeps the MQTT connection working on loop.
         */
        void keep();

        /**
         * @brief Publishes a message on the configured publish topic.
         */
        void sendMessage(String payload);

        /**
         * @brief Returns an empty string or the message received in the configured subscribe topic.
         */
        String retrieveMessage();

        private:
        /**
        * @brief Maintains the MQTT and the wifi connections.
        */
        void maintainConnection();

        /**
        * @brief Returns true is the MQTT is not connected and false otherwise.
        */
        bool isMQTTNotConnected();

        /**
        * @brief Establishes the MQTT connection.
        */
        void connectMQTT();

        /**
        * @brief Establishes the MQTT connection in test version.
        */
        void connectMQTTTestVersion();

        WifiConnection wifi;
        Config mqttConfig;
        PubSubClient mqtt;
        static String message;
    };
}
