import React from 'react';
import ReactDOM from 'react-dom';
import App from './components/App';


import { createBrowserRouter, RouterProvider } from 'react-router-dom'

import Solicitacoes from './components/Pages/Admin/Solicitacoes';
import Campo from './components/Pages/Campo';
import OficinaInicio from './components/Pages/Oficina/Inicial';
import Register from './components/Pages/Register';

// const router = createBrowserRouter([
//   {
//     path: '/solicitacoes',
//     element: <Solicitacoes/>,
//   },
//   {
//     path: '/campo',
//     element: <Campo/>,
//   },
//   {
//     path: '/oficina',
//     element: <OficinaInicio/>
//   }
// ])

const router = createBrowserRouter([
  {
    path: '/',
    element: <App/>,
    children: [
      {
        path: '/',
        element:<Solicitacoes/>,
      },
      {
        path: '/campo',
        element: <Campo/>,
      },
      {
        path: '/oficina',
        element: <OficinaInicio/>,
      },
      {
        path: '/register',
        element:<Register/>,
      },
    ]
  }
])

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    {/* <App /> */}
    <RouterProvider router={router} />
  </React.StrictMode>,
  document.getElementById('root'),
);
