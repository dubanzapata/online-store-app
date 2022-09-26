
import 'bootstrap/dist/css/bootstrap.min.css';
import { FaTrashAlt, FaPen } from "react-icons/fa";

import '../style/tableSale.css'

const Sales = () => {
  return (
    
  <div className='container col-12  mt-5'>
    <div className="row">
      <div className='containerLeftC col-5 '>

         {/* PARA EL CLIENTE*/}
        <div className="card border-primary">
          <div className="card-header border-primary  fw-semibold fs-5">Clients</div>
            <div className="card-body">
            <form>

              <div className="row mb-3">
                <label for="name" className="col-sm-3 col-form-label">Name Client</label>
                    <div className="col-sm-9">
                      <select className="form-control">
                        <option selected>Cliente1</option>
                      </select>
                    </div>
              </div>

              <div className="row mb-3">
                  <label for="date" className="col-sm-3 col-form-label ">Date</label>
                    <div className="col-sm-9">
                        <input type="date" className="form-control" id="date"/>
                    </div>
              </div>
            </form>

            </div>

              <div className="card-footer border-primary bg-light fw-semibold fs-5 p-3">
                <button className="btn btn-primary">Add </button>
                  </div>
              </div>

          {/* PARA EL PRODUCTO*/}
                
          <div className="card border-primary mt-4">
              <div className="card-header border-primary  fw-semibold fs-5 p-3">Products</div>
                <div className="card-body">
                  <form>

                    <div className="row mb-3">
                       <label for="nameProduct" className="col-sm-3 col-form-label">Name Product</label>
                          <div className="col-sm-9">
                            <select className="form-control">
                              <option selected>Product 1</option>
                            </select>
                          </div>
                    </div>

                    <div className="row mb-3">
                        <label for="amountSale" className="col-sm-3 col-form-label ">Amount</label>
                          <div className="col-sm-9">
                              <input type="number" className="form-control" id="amountSale" min={0} />
                          </div>
                    </div>
                  </form>

                </div>

                  <div className="card-footer border-primary bg-light fw-semibold fs-5 p-3">
                    <button className="btn btn-primary">Add Product</button>
                  </div>
                  
            </div>
          </div>
            

            {/* TABLE SALE*/}  
          <div className='containerRigth col-7 '>
                <div className="card border-primary">
                  <div className="card-header border-primary  fw-semibold fs-5">Sale</div>
                    <div className="card-body">

                    {/* <div className="row mb-2 border-primary">
                      <label className="col-sm-2 col-form-label  fw-normal fs-5">Customer</label>
                        <div className="col-sm-10">
                          <input type="text" className="form-control" readOnly/>
                        </div>
                    </div > */}
                    

                    <table className="table table table-striped table-hover">
                     <thead>
                      <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Product</th>
                        <th scope="col">Price</th>
                        <th scope="col">Amount</th>
                        <th scope="col">Total</th>
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
                      <td>
                          
                      <button className="btn btn-small btn-primary me-1 btnOne" >
                            <FaPen/>
                          </button>
                          <button className="btn btn-small btn-danger">
                            <FaTrashAlt />
                     </button>
                     </td>
                   </tr>
                   </tbody>
           
           {/* PARA EL MONTO tOTAL*/}
           {/* <tfoot>
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
                    */}
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

export default Sales;