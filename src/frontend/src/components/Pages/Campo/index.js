import { ContainerText, ContainerImg, ContainerWrapper, Button, IconManutencao, IconTrator, TextoMaior, TextoModal} from './style';
import Modal from './modal';
import iconmanutencao from '../../../assets/images/iconmanutencao.png'
import icontrator from '../../../assets/images/icontrator.png'
import { useState } from 'react';


function Campo() {

    const [openModal, setOpenModal] = useState(false)

    return (
      <ContainerWrapper>
        <ContainerText>
          <div>
            <TextoMaior>Solicitar Manutenção</TextoMaior>
            <Button onClick={() => setOpenModal(true)}>Solicitar</Button>
          </div>
        </ContainerText>
        <ContainerImg>
          <div>
            <IconManutencao src={iconmanutencao} />
          </div>
        </ContainerImg>
        <Modal isOpen={openModal} setModalOpen={() => setOpenModal(!openModal)}>
            <TextoModal>Deseja confirmar a solicitação?</TextoModal>
        </Modal>
        <ContainerText>
          <div>
            <TextoMaior>Solicitar Transporte</TextoMaior>
            <Button onClick={() => setOpenModal(true)}>Solicitar</Button>
          </div>
        </ContainerText>
        <ContainerImg>
          <div>
            <IconTrator src={icontrator} />
          </div>
        </ContainerImg>
      </ContainerWrapper>
    );
  }
  
  export default Campo;
