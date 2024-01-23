import styled from 'styled-components';

export const Container = styled.div`
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;

    .container-form {
        width: 80%;
        height: 80vh;
        display: flex;
        box-shadow: 5px 5px 10px rgba(0, 0, 0, .212);
    }

    .form-image {
        width: 50%;
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 1rem;
    }

    .form {
        width: 50%;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        padding: 3rem;
    }

    .form-header {
        margin-bottom: 3rem;
    }

    .form-header h1::after {
        content: '';
        display: block;
        width: 5rem;
        height: 0.3rem;
        background-color: #FFA500;
        margin: 0 auto;
        position: absolute;
        border-radius: 10px;
        
    }

    .input-group {
        display: flex;
        flex-direction:  column;
        justify-content: center;
        align-items: flex-start;    
       /* flex-wrap: wrap;
        justify-content: space-between; */
        padding: 1rem 0;
    }

    .input-box {
        display: flex;
        flex-direction: column;
        margin-bottom: 1.1rem;
    }

    .input-box input {
        margin: 0.6rem 0;
        padding: 0.8rem 1.2rem;
        border: none;
        border-radius: 10px;
        box-shadow: 1px 1px 6px #0000001c;
    }

    .input-box input:hover{
        background-color: #eeeeee75;
    }

    .input-box input:focus-visible{
        outline: 1px solid #FFA500;
    }

    .input-box label,
    .select-group label {   
        font-weight: 600;
        color: #000000c0;
    }

    .input-box input::placeholder {
        color: #000000be;
    }

    .select-group {
        display: block;
    }

    .select-group select {
        margin: 0.6rem 0;
        padding: 0.8rem 1.2rem;
        border: none;
        border-radius: 10px;
        box-shadow: 1px 1px 6px #0000001c;
        margin-left: 10px;
    }

    .select-group select:hover {
        background-color: #eeeeee75;
    }

    .select-group select:focus-visible{
        outline: 1px solid #FFA500;
    }

    
    .select-group select::placeholder {
        color: #000000be;
    }
    .continue-button button {
        width: 100%;
        margin-top: 2.5rem;
        border: none;
        background-color: #FFA500;
        padding: 0.62rem;
        border-radius: 5px;
        cursor: pointer;
    }

    .continue-button button:hover {
        background-color: #e69500;
    }

    .continue-button button a {
        text-decoration: none;
        font-size: 0.93rem;
        font-weight: 500;
        color: #fff;
    }
`;