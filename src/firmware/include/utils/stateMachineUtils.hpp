#include <Arduino.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <vector>
#include "connection/MQTTConnection.hpp"

namespace utils
{
    // State Machine Utils
    class SMUtils
    {
        public:

        SMUtils(connection::MQTTConnection::Config &mqttConfig);

        /**
         * @brief Initializes the MQTT connection.
         */
        void initMQTT();

        /**
         * @brief Keeps the MQTT connection online.
         */
        void keepMQTTConnected();

        /**
        * @brief Returns the expected message processed by "processMessage".
        */
        std::vector<String> getMessage();

         /**
         * @brief Publishes a message on the configured publish topic in the following format:
         * "clientId: msg".
         */
        void sendMessage(String msg);

        /**
        * @brief Returns a float of the estimated time for a maintenance operation in milliseconds.
        */
        float getDelayTime(String time);

        /**
        * @brief Returns true if the string "s" is not in the vector "v", false otherwise.
        */
        bool isNotInVector(std::vector<String> v, String s);

        /**
        * @brief Returns a string containing all strings in the vector "v", separated by ", ".
        */
        String concatStrings(std::vector<String> v);

        private:

        /**
         * @brief Returns a vector with the client ID in the message as the first element and with the message's content
         * separated as the other elements.
         */
        std::vector<String> processMessage(String msg);

        /**
        * @brief Returns true if the message is empty or if it is destinated to other vehicle (to a different client ID).
        * Returns false otherwise.
        */
        bool messageIsEmptyOrForOtherVehicle(String msg);

         /**
         * @brief Formats the message, concatenating both arguments.
         */
        String formatMessage(String msg);

        /**
         * @brief Returns the clientId + ": " (for formatting purposes).
         */
        String getClientIdForMsg();

        connection::MQTTConnection MQTT;
        const char* clientId;
    };
}