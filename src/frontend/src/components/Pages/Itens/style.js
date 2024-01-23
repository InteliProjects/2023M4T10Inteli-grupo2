import styled from 'styled-components';

export const Box = styled.div`
  width: 750px;
  height: 400px;
  border: 1px solid #000;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  padding: 20px;
  margin-top: 10px;
  overflow-y: auto;
`;

export const Title = styled.h2`
  display: flex;
  justify-content: center;
  margin-top: 10px;
`;

export const Container = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
`;

export const RequestContainer = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  margin-bottom: 75px;
`;

export const Request = styled.h3`
  flex: 1;
`;

export const Button = styled.button`
  background-color: #444;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  margin-left: 20px;
`;
