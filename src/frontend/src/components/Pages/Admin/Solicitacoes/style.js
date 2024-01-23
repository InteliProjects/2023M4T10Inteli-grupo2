import styled from 'styled-components';

export const Title = styled.h2`
    display: flex;
    justify-content: center;
    margin-top: 10px;
`;

export const Container = styled.div`
    display: flex;
    align-items: center;
    justify-content: space-between;

`;


export const Box = styled.div`
    width: 180px;
    height: 180px;
    border: 1px solid #000;
    margin-top: 5px;
    margin-left: 100px;
    margin-right: 100px;


    h3 {
        display: flex;
        justify-content: center;
    }
`;

export const CardActive = styled.div`
    width: 100%;
    background-color: red;
    display: flex;
    justify-content: space-around;
    align-items: center;
    height: 30px;
`;

export const CardRunning = styled.div`
    width: 100%;
    background-color: yellow;
    display: flex;
    justify-content: space-around;
    align-items: center;
    height: 30px;
`;

export const CardFinish = styled.div`
    width: 100%;
    background-color: green;
    display: flex;
    justify-content: space-around;
    align-items: center;
    height: 30px;
`;
