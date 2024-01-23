import styled from 'styled-components';

export const Container = styled.div`
    display: flex;
    height: 100%;

    .container-barra {
        width: 40%;
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 20px;
    }

    .graficos {
        width: 90%;
        height: 90%;
        border: 1px solid #000;
        display: flex;
        flex-direction: column;
        justify-content: space-around;
    }

    .grafico-barra {
        height: 40%;
    }

    .container-infos {
        height: 100%;
        width: 60%;
        display: flex;
        flex-direction: column;
        margin-right: 40px;
        margin-top: 10px;
    }

    .pizza {
        height: 200px;
        max-height: 200px;
        width: 100%;
        border: 1px solid #000;
        display: flex;
        justify-content: center;
        flex-direction: column;
        align-items: center;
        margin-top: 10px;
    }

    .pizza-graphic {
        height: 150px;
        display: flex;
    }

    .legend {
        display: flex;
        flex-direction: column;
        font-family: Arial, sans-serif;
        margin-top: 40px;
        font-size: 16px;
    }

    .legend-item {
        display: flex;
        align-items: center;
        margin-bottom: 5px;
    }

    .color-box {
        width: 20px;
        height: 20px;
        margin-right: 10px;
    }


    .info {
        width: 100%;
        height: 250px;
    }

    .sub-container-info{
        height: 108px;
        width: 100%;
        display: flex;
        justify-content: space-between;
        align-items: center; 
    }

    .box{
        border: 1px solid #000;
        height: 90px;
        width: 260px; 
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    .title{
        display: flex;
        justify-content: center;
        align-items: flex-start;
        margin-top: 5px;
    }

    .number {
        margin-top: 25px;
        width: 100px;
        display: flex;
        justify-content: center;
        border: 1px solid #000;
    }
`;

export const ContainerBarras = styled.div`
    width: 40%;
    height: 471px;
    border: 1px solid #000;
    display: flex;
    justify-content: center;
    align-items: center;
`;

export const Grafico = styled.div`
    width: 90%;
    height: 90%;
    border: 1px solid #000;
`;

export const ContainerPizza = styled.div`
    height: 500px;
`;