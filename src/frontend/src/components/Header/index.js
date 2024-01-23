import { Container, Logo, Icon } from "./style"

import logo from '../../assets/images/logo.png'
import icon from '../../assets/images/icon.png'

export default function Header() {
    return (
        <>
            <Container>
                <Logo src={logo} />
                <Icon src={icon} />
            </Container>
        </>
    );
};