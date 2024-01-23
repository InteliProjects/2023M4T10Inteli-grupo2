import styled from 'styled-components';

export const ContainerWrapper = styled.div`
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(2, 1fr);
  gap: 10px;
  width: 100%;
  height: 75vh;
  align-items: center;
  justify-items: center;
  max-width: 100%;
`;

export const ContainerText = styled.div`
  width: 50%;
  height: 50%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: left;
  background: #ffff;
`;

export const ContainerImg = styled.div`
  width: 50%;
  height: 50%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: left;
  background: #ffff;
  margin-left: 150px;
`;

export const ContainerModal = styled.div`
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background: #ffff;
`;

export const Button = styled.button`
  background-color: #444;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  margin-top: 8px;
  width: 150px; 
  height: 45px;
`;

export const ButtonModal = styled.button`
  background-color: #444;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  margin-top: 8px;
  width: 125px;
  margin-right: 10px;
  &:last-child {
    margin-right: 0;
  }
`;

export const IconTrator = styled.img`
  width: 185px;
  height: 150px;
  align-self: flex-end;
`;

export const IconManutencao = styled.img`
  width: 200x;
  height: 150px;
  align-self: flex-end;
`;

export const TextoMaior = styled.p`
  font-size: 30px;
  font-weight: bold;
`;

export const TextoModal = styled.p`
  font-size: 20px;
  font-weight: bold;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  margin-bottom: 16px; 
`;


export const Background = styled.div`
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.7);
  z-index: 1000;
`;


export const ModalStyle = styled.div`
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%,-50%);
  padding: 50px;
  background-color: #fff;
  border-radius: 20px;
  border: 6px solid #ccc; 
`;