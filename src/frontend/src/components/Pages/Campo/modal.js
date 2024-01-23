import { Background, ModalStyle, ButtonModal, ContainerModal } from './style'

export default function Modal({isOpen, setModalOpen, children}) {

    if(isOpen){
        return (
            <Background>
                <ModalStyle>
                    <div>
                        {children}
                    </div> 
                    <ContainerModal>
                        <ButtonModal>Confirmar</ButtonModal>
                        <ButtonModal onClick={setModalOpen}>Voltar</ButtonModal>
                    </ContainerModal>                    
                </ModalStyle>
            </Background>
          )
    }

    return null

}

