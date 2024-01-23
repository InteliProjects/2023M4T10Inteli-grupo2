import { useState } from 'react';
import { Container } from './styles';
import Logo from '../../../assets/images/logo.png'

export default function Register() {
    const [name, setName] = useState('');
    const [role, setRole] = useState('');
    const [erros, setErros] = useState([]);

    function handleSubmit(event) {
        event.prevenDefault();
        console.log(name)
    }

    function handleNamechange(event) {
        setName(event.target.value);

        if(event.target.value){
            setErros((prevState) => [
                ...prevState,
                {field: 'name', message: 'Nome é obrigatório'},
            ]);
        }
    }

    return (
        <>
            <Container>
              <div className='container-form'>
                    <div className='form-image'>
                        <img src={Logo} alt='Logo' />
                    </div>
                    <div className='form'>
                        <form action='#' onSubmit={handleSubmit}>
                            <div className='form-header'>
                                <div className='title'>
                                    <h1>Cadastre-se</h1>
                                </div>
                            </div>

                            <div className='input-group'>
                                <div className='input-box'>
                                    <label for='name'>Nome</label>
                                    <input 
                                    id='name' 
                                    type='text' 
                                    placeholder='Digite seu nome' 
                                    value={name}
                                    onChange={handleNamechange}
                                    required/>
                                </div>
                                <div className='select-group'>
                                    <label for='roles'>cargo</label>
                                    <select id='roles'name="select">
                                    <option value="administrador">Administração</option>
                                    <option value="oficina" selected>Oficina</option>
                                    <option value="Campo">Campo</option>
                                    </select>
                                </div>
                            </div>

                            <div className='continue-button'>
                                <button><a href='#'>Continuar</a></button>
                            </div>
                        </form>
                    </div>
              </div>
            </Container>
        </>
    )
}