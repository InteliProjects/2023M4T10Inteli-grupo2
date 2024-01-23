#include "stateMachine/MQTTStateMachine.hpp"

#define ID_INDEX 0
#define UUIDS_START_INDEX 2
#define MESSAGE_COMMAND_INDEX 1
#define VEHICLE_TYPE_INDEX 1
#define FIRST_UUID_INDEX 1
#define SECOND_UUID_INDEX 2
#define MAX_MILLISECONDS 10000

using namespace stateMachine;

MQTTSM::MQTTSM(connection::MQTTConnection::Config &mqttConfig, components::RFID &rfid, components::Buzzer &buzzer) 
    : utils(utils::SMUtils(mqttConfig)), rfid(rfid), buzzer(buzzer)
{
    
}

void MQTTSM::init()
{
    utils.initMQTT();
    rfid.init();
    setState(STARTING);
}

void MQTTSM::initTestVersion()
{
    utils.initMQTT();
    rfid.init();
    setState(TESTING);
}

void MQTTSM::loop()
{
    actAccordingToState();
    utils.keepMQTTConnected();
}

void MQTTSM::setState(uint8_t state)
{
    currentState = state;
}

void MQTTSM::actAccordingToState()
{
    switch (currentState)
    {
    case TESTING:
        test();
        break;

    case STARTING:
        start();
        break;

    case REGISTERING_FIRST_TIME:
        registering();
        break;
    
    case READING_IN_TRANSPORT:
        readInTransport();
        break;
    
    case WAITING_MAINTENANCE:
        waitMaintenance();
        break;

    case CONFIRMING_MAINTENANCE_END:
        confirmMaintenanceEnd();
        break;

    case WAITING_FOR_REQUEST:
        waitRequest();
        break;
    
    case READING_FOR_MAINTENANCE:
        readForMaintenance();
        break;
    
    case DELAYED_MAINTENANCE:
        delayedMaintenanceAlert();
        break;
    
    case EMERGENCY:
        emergencyAlert();
        break;
    
    case ESCALATED:
        escalatedAlert();
        break;
    
    case TEST_EMERGENCY:
        testEmergencyAlert();
        break;
    }
}

void MQTTSM::test()
{
    unsigned long startTime = millis();
    bool emergency = millis() - startTime > MAX_MILLISECONDS;
    Serial.println("Tentando ler tag RFID...");

    while (!emergency && !rfid.available())
    {
        emergency = millis() - startTime > MAX_MILLISECONDS;
    }

    if (emergency)
    {
        setState(TEST_EMERGENCY);
        return;
    }
    
    String read = rfid.getUuid();
    
    Serial.print("Tag lida! UUID: ");
    Serial.println(read);
    
    buzzer.playRead();
    
    utils.sendMessage(read);
    
    delay(5000);
}


void MQTTSM::start()
{
    String startMessage = "start";
    utils.sendMessage(startMessage);

    std::vector<String> response = utils.getMessage();

    while (response.empty())
    {
        response = utils.getMessage();
    }

    if (response[MESSAGE_COMMAND_INDEX] == "unregistered")
    {
        setState(REGISTERING_FIRST_TIME);
        return;
    }

    for (int i = UUIDS_START_INDEX; i < response.size(); i++)
    {
        uuids.push_back(response[i]); 
    }

    if (response[VEHICLE_TYPE_INDEX] == "M") // M -> maintenance; T -> transport
    {
        setState(WAITING_FOR_REQUEST);
        return;
    }

    buzzer.playRead();
    setState(READING_IN_TRANSPORT);
}

void MQTTSM::registering()
{
    unsigned long startTime = millis();
    bool timeToSend = millis() - startTime > MAX_MILLISECONDS;
    std::vector<String> uuidsRead;

    while(rfid.available() && !timeToSend)
    {
        String read = rfid.getUuid();

        if (utils.isNotInVector(uuidsRead, read))
        {
            uuidsRead.push_back(read);
        }
    }
    
    utils.sendMessage(utils.concatStrings(uuidsRead));

    uuids.swap(uuidsRead);

    setState(READING_IN_TRANSPORT);
}

void MQTTSM::readInTransport()
{
    std::vector<String> message = utils.getMessage();
    
    if (!message.empty() && message[MESSAGE_COMMAND_INDEX] == "maintenance")
    {
        setState(WAITING_MAINTENANCE);
        return;
    }

    unsigned long startTime = millis();
    bool emergency = false;

    for(int i = 0; i < uuids.size(); i++)
    {
        if (emergency)
        {
            setState(EMERGENCY);
            break;
        }

        String current = uuids[i];

        while(rfid.available())
        {
            if (current == rfid.getUuid())
            {
                startTime = millis();
                break;
            } 

            if ((millis() - startTime) > MAX_MILLISECONDS)
            {
                emergency = true;
                break;
            }
        }
    }
}

void MQTTSM::waitMaintenance()
{
    std::vector<String> message = utils.getMessage();
    
    if (message.empty())
    {
        return;
    }

    int uuidToChangePos = getUuidToChangePos(message[FIRST_UUID_INDEX]);

    changeOldUuid(message[SECOND_UUID_INDEX], uuidToChangePos);

    delayTime = utils.getDelayTime(message[3]);

    maintenanceStartTime = millis();
    
    setState(CONFIRMING_MAINTENANCE_END);
}

void MQTTSM::confirmMaintenanceEnd()
{
    unsigned long currentTime = millis();

    bool isNotDelayed = (currentTime - maintenanceStartTime) < delayTime;

    std::vector<String> message = utils.getMessage();

    if (isNotDelayed && message.empty())
    {
        return;
    }

    if (!isNotDelayed)
    {
        setState(DELAYED_MAINTENANCE);
        return;
    }

    // might not be necessary (always the same) *
    if (message[MESSAGE_COMMAND_INDEX] == "completed")
    {
        setState(READING_IN_TRANSPORT);
    }
}

void MQTTSM::waitRequest()
{
    std::vector<String> message = utils.getMessage();

    if (message.empty())
    {
        return;
    }

    // might not be necessary (always the same) *
    if (message[MESSAGE_COMMAND_INDEX] == "request")
    {
        setState(READING_FOR_MAINTENANCE);
    }
}

void MQTTSM::readForMaintenance()
{
    if(!rfid.available())
    {
        return;
    }

    String read = rfid.getUuid();
    buzzer.playRead();

    ++materialsRead;

    utils.sendMessage(read);

    std::vector<String> response = utils.getMessage();

    while (response.empty())
    {
        response = utils.getMessage();
    }

    if (response[MESSAGE_COMMAND_INDEX] == "repeat")
    {
        --materialsRead;
        return;
    }

    if (response[MESSAGE_COMMAND_INDEX] == "success" && materialsRead == 2)
    {
        materialsRead = 0;
        setState(WAITING_FOR_REQUEST);
    }
}

void MQTTSM::delayedMaintenanceAlert()
{
    String alert = "delayed";
    utils.sendMessage(alert);

    std::vector<String> response = utils.getMessage();

    while (response.empty())
    {
        response = utils.getMessage();
    }

    if (response[MESSAGE_COMMAND_INDEX] == "extended")
    {
        delayTime = utils.getDelayTime(response[2]);
        maintenanceStartTime = millis();
        setState(CONFIRMING_MAINTENANCE_END);
    }

    if (response[MESSAGE_COMMAND_INDEX] == "escalated")
    {
        setState(ESCALATED);
    }
}

void MQTTSM::emergencyAlert()
{
    String alert = "emergency";
    utils.sendMessage(alert);

    std::vector<String> response = utils.getMessage();

    while (response.empty())
    {
        response = utils.getMessage();
    }

    if (response[MESSAGE_COMMAND_INDEX] == "solved")
    {
        setState(READING_IN_TRANSPORT);
    }

    if (response[MESSAGE_COMMAND_INDEX] == "escalated")
    {
        setState(ESCALATED);
    }
}

void MQTTSM::escalatedAlert()
{
    std::vector<String> response = utils.getMessage();

    while (response.empty())
    {
        response = utils.getMessage();
    }

    if (response[MESSAGE_COMMAND_INDEX] == "solved")
    {
        setState(READING_IN_TRANSPORT);
    }
}

void MQTTSM::testEmergencyAlert()
{
    if (rfid.available())
    {
        setState(TESTING);
        return;
    }

    Serial.println("Nenhuma tag RFID encontrada! Emergência!");

    buzzer.playEmergency();
    utils.sendMessage("emergency");
    delay(2000);
}

int MQTTSM::getUuidToChangePos(String uuidToChange)
{
    int pos;

    for (int i = 0; i < uuids.size(); i++)
    {
        if (uuidToChange == uuids[i])
        {
            pos = i;
            break;
        }
    }

    return pos;
}

void MQTTSM::changeOldUuid(String newUuid, int pos)
{
    uuids[pos] = newUuid;
}