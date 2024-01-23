import React, { useEffect } from "react";
import mqtt from "mqtt";

const host = 'wss://962b82efc4c7479dbd35b51aab35c4b9.s1.eu.hivemq.cloud:8884/mqtt';
const clientId = 'FRNTNDECOTVOS1';

const mqttOptions = {
    username: 'ECOTVOS',
    password: 'Ecotvos1',
    clientId: clientId
};

function ConnectClient() {
    const [client, setClient] = React.useState(null);
    const [connectionStatus, setConnectionStatus] = React.useState(false)

    useEffect(() => {

        const clientInstance = mqtt.connect(host, mqttOptions);

        const onConnect = () => {
            console.log('Connected to MQTT Broker');
            setConnectionStatus(true);
        
            const subTopic = 'ECOTVOSFRMWRPUBTOP';
            clientInstance.subscribe(subTopic);
        }

        console.log('Connecting');
        clientInstance.on('connect', onConnect);

        clientInstance.on('reconnect', () => {
            console.log('Reconnecting');
        });

        setClient(clientInstance);

        return () => {
            console.log('Disconnecting');
            clientInstance.end();
        }

    }, []);


    return {client, connectionStatus};
}

// ai meu deus alguem comeu meu cu


export default ConnectClient;