import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/js/dist/collapse';
import 'bootstrap/js/dist/dropdown';

import { Link } from "react-router-dom";


const Navbar = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
      <div className="container-fluid">
        <a className="navbar-brand ms-3" to="#">WebApp</a>
         <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#opciones">
            <span className="navbar-toggler-icon"></span>
         </button>
           <div className="collapse navbar-collapse ms-3 " id="opciones">
          
              <ul className="navbar-nav ms-auto ms-2">
                <Link  to="/" className="nav-link fw-normal fs-5">Home</Link>
                    
                <li className="nav-item dropdown ms-2">
                    <a className="nav-link dropdown-toggle fw-normal fs-5" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Sale
                    </a>
                    <ul className="dropdown-menu">
                        <li><Link className="dropdown-item fw-normal fs-5" to="/Ventas">New Sale</Link></li>
                        <li><Link className="dropdown-item fw-normal fs-5" to="/ListVentas">Sales List </Link></li>
                    </ul>
                </li>

                <li className="nav-item ms-2">
                    <Link to="/Productos"className="nav-link fw-normal fs-5">Products</Link>
                </li>

                <li className="nav-item ms-2">
                    <Link  to="/Clientes" className="nav-link fw-normal fs-5"> Clients </Link>
                </li>
                    
                <li className="nav-item ms-2">
                    <Link  to="/Proveedores" className="nav-link fw-normal fs-5"> Providers </Link>
                </li>
                
                <li className="nav-item ms-2">
                    <Link  to="/" className=" btn btn-small btn-primary nav-link fw-normal fs-5"> Inicia </Link>
                </li>

              </ul>
          </div>
      </div>  
    </nav>

)
}

<script src='js/bootstrap.bundle.min.js' type='text/javascript'></script>


export default Navbar







