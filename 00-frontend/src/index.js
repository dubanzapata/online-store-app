import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import App from './App';
import "bootswatch/dist/pulse/bootstrap.min.css" ;
import 'bootstrap/dist/css/bootstrap.min.css'
import Products from './views/Products';         
import Costumers from './views/Costumers';
import Sales from './views/Sales';
import ListSales from './views/ListSales';
import Providers from './views/Providers';

import 'bulma/css/bulma.min.css';


//import Inicio from './views/Inicio';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
  <Routes>
  <Route path="/" element={<App />} >
 
      <Route path="Products" element={<Products />} />
      <Route path="Costumers" element={<Costumers />} />
      <Route path="ListSales" element={<ListSales />} />
      <Route path="Sales" element={<Sales />} />
      <Route path="Providers" element={<Providers />} />
  </Route>
  </Routes>
  
  </BrowserRouter>
);

