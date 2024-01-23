import styled from 'styled-components';

const ButtonContainer = styled.button`
  background-color: #444;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  margin-top: 8px;
  display: flex;
  align-items: center;
  justify-content: center;  

`;

export default function Button(props) {
    return (
        <>
            <ButtonContainer>{props.children}</ButtonContainer>
        </>
    )
};