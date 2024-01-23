import styled from 'styled-components';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    height: 500px;
    width: 100%;
    min-width: 768px;

    img {
        height: 25px;
        width: 30px;
    }
    .solicitacoes {
        margin-bottom: 35px;
    }

    .container-1 {
        height: 55%;
        width: 100%;
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    .info {
        width: 800px;
        height: 175px;
        border: 1px solid #000;
    }

    .title{
        display: flex;
        align-items: center;
        justify-content: space-around;
        height: 50%;
    }

    .boxes {
        height: 50%;
        display: flex;
        justify-content: space-around;
        align-items: flex-start;   
    }

    .box {
        border: 1px solid #000;
        height: 50px;
        width: 150px;
    }

    .container-2 {
        height: 45%;
        display: flex;
        flex-direction: column;
        align-items: center;
        width: 100%;
        min-width: 600px;

        h3 {
            margin-top: 40px;
        }

        button {
            width: 120px;
            height: 70px;
            margin-top: 30px;
        }
    }
`;