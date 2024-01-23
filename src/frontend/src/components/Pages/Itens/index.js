import { Title, Container, Box, RequestContainer, Request, Button } from './style';

export default function OficinaInicio() {
  return (
    <>
      <Title>Peças registradas</Title>
      <Container>
        <Box>
          <RequestContainer>
            <Request>Peça 1</Request>
            <Button>Visualizar</Button>
          </RequestContainer>
        </Box>
      </Container>
    </>
  );
}
