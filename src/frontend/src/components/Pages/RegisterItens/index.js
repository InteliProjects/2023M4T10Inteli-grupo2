// Importando as bibliotecas necessárias
import React, { useState } from 'react';
import styled from 'styled-components';
import axios from 'axios';

// Definindo estilos para o formulário
const FormContainer = styled.form`
  max-width: 400px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ddd;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
`;

const FormGroup = styled.div`
  margin-bottom: 15px;
`;

const Label = styled.label`
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
`;

const Input = styled.input`
  width: 100%;
  padding: 8px;
  font-size: 16px;
  border: 1px solid #ccc;
  border-radius: 4px;
`;

const Button = styled.button`
  background-color: #007bff;
  color: #fff;
  padding: 10px 15px;
  font-size: 16px;
  border: none;
  border-radius: 4px;
  cursor: pointer;

  &:hover {
    background-color: #0056b3;
  }
`;

// Componente do formulário
const RegisterItens = () => {
  // Estado para armazenar os dados do formulário
  const [formData, setFormData] = useState({
    description: '',
    branch: '',
  });

  // Função para lidar com a mudança nos campos do formulário
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  // Função para lidar com o envio do formulário
  const handleSubmit = async (e) => {
    e.preventDefault();
    // Adicione aqui a lógica para lidar com os dados do formulário, por exemplo, enviando para um servidor, etc.

    try {
        console.log('Resposta do servidor:', response.data); 

      const response = await axios.post('https://localhost:7197/swagger/Material/AddMaterial', formData);

      console.log('Resposta do servidor:', response.data);

      // Limpar o formulário após o envio bem-sucedido, se necessário
      setFormData({
        description: '',
        branch: '',
      });
    } catch (error) {
      console.error('Erro ao enviar dados:', error);
    }
    console.log('Dados do formulário:', formData);
  };

  // Renderização do componente do formulário
  return (
    <FormContainer onSubmit={handleSubmit}>
      <FormGroup>
        <Label htmlFor="descricao">Descrição:</Label>
        <Input
          type="text"
          id="description"
          name="description"
          value={formData.description}
          onChange={handleChange}
          required
        />
      </FormGroup>
      <FormGroup>
        <Label htmlFor="branch">Unidade da Atvos:</Label>
        <Input
          type="text"
          id="branch"
          name="branch"
          value={formData.branch}
          onChange={handleChange}
          required
        />
      </FormGroup>
      <Button type="submit">Cadastrar Peça</Button>
    </FormContainer>
  );
};

export default RegisterItens;