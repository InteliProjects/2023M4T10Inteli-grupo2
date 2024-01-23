import { Link } from 'react-router-dom';

import { Container } from "./style";
import Button from "../../../Button";

import arrow from '../../../../assets/images/voltar.png';

export default function VerSolicitacoes() {
    return (
        <>
            <Container>
                <Link to='/oficina'>
                    <img src={arrow} alt='voltar'/>
                </Link>
                <div className="container-1">
                    <h1 className='solicitacoes'>Solicitações de manutenção</h1>
                    <div className="info">
                        <div className="title">
                            <p>Nome</p>
                            <p>Veículo</p>
                            <p>Tempo</p>
                            <p>Status</p>
                        </div>
                        <div className="boxes">
                            <div className="box"></div>
                            <div className="box"></div>
                            <div className="box"></div>
                            <div className="box"></div>
                        </div>
                    </div>
                </div>
                <div className="container-2">
                    <h3>Indicar as peças a serem trocadas</h3>
                    <Button>Ler Peças</Button>
                </div>
            </Container>
        </>
    );
}