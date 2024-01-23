import React, { useEffect } from 'react';
import './App.css';
import connectClient from '../MQTT/MQTT.js'


function App() {
    const [messages, setMessages] = React.useState('Nenhuma leitura recebida.')
    const [receivedId, setReceivedId] = React.useState('Nenhum id recebido.')

    const { client, connectionStatus } = connectClient();

    useEffect(() => {
        if (client && connectionStatus) {
            const handleMessage = (topic, payload, packet) => {
                const message = payload.toString();
                const processedMsg = processMessage(message);
                setReceivedId(processMessage[0])
                setMessages(processedMsg[1])
                console.log('Nova mensagem recebida: ' + processedMsg[1])
            }

            client.on('message', handleMessage);

            return () => {
                if (client.connected) {
                    console.log('Desubscribe');
                    client.removeListener('message', handleMessage);
                }
            };
        }
    }, [client, connectionStatus]);

    if (messages === "emergency") {
        return (
            <h1>Emergência! Nenhuma etiqueta disponível para leitura!</h1>
        );
    }

    return (
        <h1>ID lido: {messages}</h1>
    );
}

function processMessage(message) {
    return message.split(': ')
}

export default App;
