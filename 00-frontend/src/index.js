import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import App from './App';
import "bootswatch/dist/pulse/bootstrap.min.css" ;
import 'bootstrap/dist/css/bootstrap.min.css'
import Productos from './views/Productos';         
import Clientes from './views/Clientes';
import Ventas from './views/Ventas';
import ListVentas from './views/ListVentas';
import Proveedores from './views/Proveedores';

import 'bulma/css/bulma.min.css';


//import Inicio from './views/Inicio';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
  <Routes>
  <Route path="/" element={<App />} >
 
      <Route path="Productos" element={<Productos />} />
      <Route path="Clientes" element={<Clientes />} />
      <Route path="ListVentas" element={<ListVentas />} />
      <Route path="Ventas" element={<Ventas />} />
      <Route path="Proveedores" element={<Proveedores />} />
  </Route>
  </Routes>
  
  </BrowserRouter>
);

