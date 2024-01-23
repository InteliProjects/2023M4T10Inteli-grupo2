// index.js
import { Title, Container, Box, RequestContainer, Request, Button } from './style';

export default function OficinaInicio() {
  return (
    <>
      <Title>Solicitações de manutenção</Title>
      <Container>
        <Box>
          <RequestContainer>
            <Request>Solicitação 1</Request>
            <Button>Visualizar</Button>
          </RequestContainer>
          <RequestContainer>
            <Request>Solicitação 2</Request>
            <Button>Visualizar</Button>
          </RequestContainer>
          <RequestContainer>
            <Request>Solicitação 3</Request>
            <Button>Visualizar</Button>
          </RequestContainer>
          <RequestContainer>
            <Request>Solicitação 4</Request>
            <Button>Visualizar</Button>
          </RequestContainer>
        </Box>
      </Container>
    </>
  );
}