import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { FaTrashAlt} from "react-icons/fa";
import SearchCliente from "../components/SearchCliente";
import SearchProduct from "../components/SearchProduct";
import '../style/tableSale.css'

const Ventas = () => {
  return (
    
    <div className='container col-12  mt-5'>
      <div className="row">
         <div className='containerLeftC col-5 '>

              {/* PARA EL CLIENTE*/}
              <div className="card border-primary">
                  <div className="card-header border-primary  fw-semibold fs-5">Clients</div>
                    <div className="card-body">

                        <SearchCliente/>
                        </div>

                        <div className="card-footer border-primary bg-light fw-semibold fs-5 p-3">
                           <button className="btn btn-primary">Add Client</button>
                        </div>
                 </div>

                {/* PARA EL PRODUCTO*/}
                
            <div className="card border-primary mt-4">
                  <div className="card-header border-primary  fw-semibold fs-5 p-3">Products</div>
                    <div className="card-body">
                    <form>
                    <SearchProduct/>

                    </form>

                    </div>

                    <div className="card-footer border-primary bg-light fw-semibold fs-5 p-3">
                        <button className="btn btn-primary">Add Product</button>

                    </div>
                  
            </div>
          </div>
            
              
          <div className='containerRigth col-7 '>
                <div className="card border-primary">
                  <div className="card-header border-primary  fw-semibold fs-5">Sale</div>
                    <div className="card-body">

                    <div className="row mb-2 border-primary">
                      <label className="col-sm-2 col-form-label  fw-normal fs-5">Customer</label>
                        <div className="col-sm-10">
                          <input type="text" className="form-control" readOnly/>
                        </div>
                    </div >
                    

                    <table className="table table table-striped table-hover">
                     <thead>
                      <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Cliente</th>
                        <th scope="col">Producto</th>
                        <th scope="col">Cantidad</th>
                        <th scope="col">Precio</th>
                        <th scope="col">Fecha</th>
                        <th scope="col">Acciones</th>
                     </tr>
                   </thead>

                   <tbody>
             
                    <tr>
                      <td></td> 
                      <td></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td>
                          
                        {/* <button className="btn btn-danger me-1" >
                           <FaTrashAlt />
                       </button> */}
                       <button class="btn btn-info btn-sm m-1">+</button>
                      <button class="btn btn-danger btn-sm">-</button>
                     </td>
                   </tr>
                   </tbody>
           
           {/* PARA EL MONTO tOTAL*/}
           <tfoot>
            <tr>
            <th scope="row" colspan="3">Total Products</th>
        
        
        <td>10</td>
        <td class="font-weight-bold" colspan="2">$ <span>5000</span></td>
        <td>
            <button class="btn btn-danger btn-sm" id="vaciar-carrito">
                vaciar todo
            </button>
        </td>
          </tr>
          </tfoot>
                   
                 </table>
                        
                        
                    </div>
                    <div className="card-footer border-primary bg-light fw-semibold fs-5 p-3">
                        <button className="btn btn-primary">Add Sale</button>

                    </div>
                  
            </div>
          </div>
                 
        </div>   
    </div>
    
  )
}

export default Ventas;