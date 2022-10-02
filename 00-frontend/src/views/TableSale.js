import React, { useState, useEffect } from 'react';
import axios from 'axios';

const TableSale = ({ result })  => {
    const [clientName, setClientName] = useState([]);
    const [productName, setProductName] = useState([]);
  
    const getDataCustomers = async ()=>{
      try{
        const { data } = await axios.get("http://localhost:5000/customers");
        const [{ nameCustomer }] = data.filter(item=>item.idCustomer===+(result?.client));
        setClientName(nameCustomer);
      }catch(error){
        console.log(error);
      }
    };

    const getDataProducts = async ()=>{
      try{
        const {data} = await axios.get("http://localhost:5000/products");
        const [{productName}] = data.filter(item=>item.idProduct ===+(result?.product));
        setProductName(productName);
      }catch(error){
        console.log(error);
      }
    };
  
    useEffect(() => {
      getDataCustomers();
      getDataProducts();
    }, [result]);

  return (
    <>
        <table className="table table table-striped table-hover">
         <thead>
           <tr>
              <th scope="col">Date</th>
              <th scope="col">Customer</th>
              <th scope="col">Product</th>
              <th scope="col">Price</th>
              <th scope="col">Amount</th>
              <th scope="col">Total Price</th>
              {/* <th scope="col">Acciones</th> */}
            </tr>
         </thead>

          <tbody>
          <tr>
            <td>{ result?.date }</td> 
            <td>{clientName }</td>
            <td>{ productName}</td>
            <td>{ result?.price }</td>
            <td>{ result?.amount }</td>
            <td>{ result?.totalPrice }</td>
            <td></td>
            {/* <td>
              <button className="btn btn-small btn-primary me-1 btnOne" >
                 <FaPen/>
              </button>
              <button className="btn btn-small btn-danger">
                  <FaTrashAlt />
              </button>
            </td> */}
          </tr>          
          </tbody>
           
               

            {/* PARA EL MONTO tOTAL*/}
            <tfoot align="rigth">
            <tr>
            <th colSpan={4}></th>  
            <th  >Total </th>
            <th  >$ 500</th>
          </tr>
          </tfoot>

          </table>
    
    </>
  )
}

export default TableSale;