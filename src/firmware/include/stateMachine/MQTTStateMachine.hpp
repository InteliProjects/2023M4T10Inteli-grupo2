#include <Arduino.h>
#include "components/rfid.hpp"
#include "components/buzzer.hpp"
#include "utils/stateMachineUtils.hpp"
#include <vector>

namespace stateMachine
{
    // MQTT State Machine
    class MQTTSM
    {
        public:
        enum States {
            TESTING,
            STARTING = 1,
            REGISTERING_FIRST_TIME,
            READING_IN_TRANSPORT,
            WAITING_MAINTENANCE,
            CONFIRMING_MAINTENANCE_END,
            WAITING_FOR_REQUEST,
            READING_FOR_MAINTENANCE,
            DELAYED_MAINTENANCE,
            EMERGENCY,
            ESCALATED,
            TEST_EMERGENCY
        };

        MQTTSM(connection::MQTTConnection::Config &mqttConfig, components::RFID &rfid, components::Buzzer &buzzer);

        /**
         * @brief Initializes the MQTT State Machine.
         */
        void init();

        /**
         * @brief Initializes the MQTT State Machine test version.
         */
        void initTestVersion();

        /**
         * @brief Keeps the MQTT State Machine working on loop.
         */
        void loop();

        /**
         * @brief Changes the MQTT State Machine current state.
         */
        void setState(uint8_t state);


        private:

        /**
         * @brief Handles the actions that need to be taken according to the current state.
         */
        void actAccordingToState();

        /**
         * @brief Starts the device in test mode, simply sending UUIDs to the MQTT broker and
         * testing general funcionalities.
         */
        void test();

        /**
         * @brief Starts the device, getting and storing the necessary data from the server.
         * Changes the state to the default state after executing.
         */
        void start();

        /**
         * @brief State of a truck with no registered parts (first time using the device).
         */
        void registering();

        /**
         * @brief Default state for transport trucks, in which they read their own parts' UUIDs
         * constantly and inform the server in case any of them is missing. If that happens, current state
         * is changed to Emergency. Constantly waits for new messages to enter in wating maintenance state.
         */
        void readInTransport();

        /**
         * @brief State of a transport truck that requests a maintenance operation. Waits for a positive
         * response and changes the state to confirming maintenance end.
         */
        void waitMaintenance();

        /**
         * @brief State of a transport truck that is going through a maintenance operation. Waits for the
         * conclusion response and changes the state back to default (reading in transport), or changes the
         * state to delayed maintenance if the operation takes longer than estimated.
         */
        void confirmMaintenanceEnd();

        /**
         * @brief Default state for maintenance trucks, in which they wait for a maintenance request sent by
         * the server. When it gets the request, the state is changed to reading for maintenance.
         */
        void waitRequest();

        /**
         * @brief State of a maintenance truck that is reading both the part of a truck which will be replaced and
         * the new part which will replace it. That action might be executed multiple times in case the wrong parts are
         * read. Once it's completed, state is changed back to default.
         */
        void readForMaintenance();

        /**
         * @brief State of a transport truck under maintenance that has exceeded its estimated maintenance time. An
         * alert is sent to the server. A message defining the amount of time to extend the deadline is expected. Receiving
         * it would change the state back to confirming maintenance end. It's also possible to escalate the situation,
         * changing the state to escalated.    
         */
        void delayedMaintenanceAlert();

        /**
         * @brief State of a transport truck that is missing one or more of its parts. An alert is sent to the server.
         * A message confirming the problem was solved is expected. Receiving it would change the state back to default.
         * It's also possible to escalate the situation, changing the state to escalated.
         */
        void emergencyAlert();

        /**
         * @brief State of emergency on test mode. Only plays the buzzer until a RFID tag is avaiable.
         */
        void testEmergencyAlert();

        /**
         * @brief State of a transport truck that is going through a problem and the situation was escalated by
         * the administration to a higher positioned person in the company hierarchy. An alert is sent to the server.
         * A message confirming the problem was solved is expected. Receiving it would change the state back to default.
         */
        void escalatedAlert();

        /**
         * @brief Returns the index of the UUID of the truck part that will be changed in a maintenance operation.
         */
        int getUuidToChangePos(String uuidToChange);
        
        /**
         * @brief Changes the UUID of the removed truck part on a maintenance operation by a new UUID in the specified
         * position.
         */
        void changeOldUuid(String newUuid, int pos);

        components::RFID rfid;
        components::Buzzer buzzer;
        std::vector<String> uuids;
        utils::SMUtils utils;

        uint8_t currentState;
        uint8_t materialsRead = 0;
        float delayTime;
        unsigned long maintenanceStartTime;
    };
}