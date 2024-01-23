#include "utils/stateMachineUtils.hpp"

#define ID_INDEX 0

using namespace utils;

SMUtils::SMUtils(connection::MQTTConnection::Config &mqttConfig)
    : MQTT(connection::MQTTConnection(mqttConfig)), clientId(mqttConfig.clientId)
{

}

void SMUtils::initMQTT()
{
    MQTT.init();
}

void SMUtils::keepMQTTConnected()
{
    MQTT.keep();
}

std::vector<String> SMUtils::getMessage()
{
    String message = MQTT.retrieveMessage();

    std::vector<String> content = processMessage(message);

    if (messageIsEmptyOrForOtherVehicle(content[ID_INDEX]))
    {
        content.clear();
    }

    return content;
}

void SMUtils::sendMessage(String msg)
{
    String formattedMsg = formatMessage(msg);
    MQTT.sendMessage(formattedMsg);
}

float SMUtils::getDelayTime(String time)
{
    return time.toFloat();
}

bool SMUtils::isNotInVector(std::vector<String> v, String s)
{
    bool isInside = false;
    
    for(int i = 0; i < v.size(); i++)
    {
        if (v[i] == s)
        {
            isInside = true;
        }
    }

    return isInside;
}

String SMUtils::concatStrings(std::vector<String> v)
{
    String result;
    int size = v.size();

    for(int i = 0; i < size; i++)
    {
        result += v[i];
        
        if (i != size - 1) // if it's not on the last element
        {
            result += ", ";
        }
    }

    return result;
}

std::vector<String> SMUtils::processMessage(String msg)
{
    std::vector<String> separatedContent;

    if (msg == "")
    {
        return separatedContent;
    }

    String substring;
    for(int i = 0; i < msg.length(); i++)
    {
        char c = msg[i];

        if (c == ',' || c == ':')
        {
            separatedContent.push_back(substring);
            substring = "";
            continue;
        }
        
        if (c == ' ')
        {
            continue;
        }

        substring += c;
    }

    return separatedContent;
}

bool SMUtils::messageIsEmptyOrForOtherVehicle(String msg)
{
    const char* id = msg.c_str();
    return id != clientId;
}

String SMUtils::formatMessage(String msg)
{
    return getClientIdForMsg() + msg;
}

String SMUtils::getClientIdForMsg()
{
    char clientIdForMsg[20];

    const char* complement = ": ";

    strncpy(clientIdForMsg, clientId, sizeof(clientIdForMsg));

    return (String)strncat(clientIdForMsg, complement, (sizeof(clientIdForMsg) - strlen(clientIdForMsg)) );
}