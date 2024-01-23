import GlobalStyles from '../../assets/styles/global';
import Header from '../Header';
import Footer from '../Footer';
import Campo from '../Pages/Campo';
import Solicitacoes from '../Pages/Admin/Solicitacoes';
import Dashboard from '../Pages/Admin/Dashboard';
import VerSolicitacoes from '../Pages/Oficina/VerSolicitacoes';
import Register from '../Pages/Register';
import Itens from '../Pages/Itens';


import RegisterItens from '../Pages/RegisterItens';


import { Outlet } from 'react-router-dom';

function App() {
    return (
      <>
      <GlobalStyles />
      <Header />
          {/* <Solicitacoes></Solicitacoes> */}
          
          {/* <VerSolicitacoes /> */}
          {/* <Register /> */}
          <Itens></Itens>
          {/* <RegisterItens></RegisterItens> */}
          {/* <Outlet/> */}
      <Footer />
      </>
      )
  }

export default App;
