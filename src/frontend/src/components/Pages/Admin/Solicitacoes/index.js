import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import { Title, Container, Box, CardActive, CardRunning, CardFinish } from './style';

export default function Solicitacoes() {
    const [Operations, setActiveOperations] = useState([]);
    const [RunningOperations, setRunningOperations] = useState([]);
    const [completedOperations, setCompletedOperations] = useState([]);
    
    useEffect(() => {
    fetch('https://localhost:7197/swagger/Operation/GetAllOperations')
    .then(async (response) => {
        const json = await response.json();
        setActiveOperations(json);
    })
    .catch((error) => {
        console.log('error', error);
    });
    }, []) 

    

    // useEffect(() => {
    //     fetch('https://localhost:7197/swagger')
    //     .then(async (response) => {
    //         const json = await response.json();
    //         setRunningOperations(json);
    //     })
    //     .catch((error) => {
    //         console.log('error', error);
    //     });
    //     }, []) 


    // useEffect(() => {
    //     fetch('http://localhost:7197/Operation/GetFinishedOperations')
    //     .then(async (response) => {
    //         const json = await response.json();
    //         setCompletedOperations(json);
    //     })
    //     .catch((error) => {
    //         console.log('error', error);
    //     });
    //     }, []) 

    



    return (
        <>  
            {/* <Link to='/dashboards' />  */}
            <Title>Solicitações de manutenção</Title>
            <Container>
                <Box>
                    <h3>Ativos</h3>
                    {Operations.map((operations) => (
                        <CardActive key={operations.id}>
                        <p>{operations.id}</p>
                        <p>{operations.estimatedDuration}</p>
                    </CardActive>
                    ))}
                </Box>
                <Box>
                    <h3>Em andamento</h3>
                    {RunningOperations.map((operation) => (
                        <CardRunning key={operation.id}>
                        <p>{operation.id}</p>
                        <p>{operation.beginHour}</p>
                    </CardRunning>
                    ))}
                </Box>
                <Box>
                    <h3>Finalizados</h3>
                    {RunningOperations.map((operation) => (
                        <CardFinish key={operation.id}>
                        <p>{operation.id}</p>
                        <p>{operation.duration}</p>
                    </CardFinish>
                    ))}
                </Box>  
            </Container>
            <Title>Solicitações de transporte</Title>
            <Container class="transport-container">
                <Box><h3>Ativos</h3></Box>
                <Box><h3>Em andamento</h3></Box>
                <Box><h3>Finalizados</h3></Box>  
            </Container>

        </>
    )
};