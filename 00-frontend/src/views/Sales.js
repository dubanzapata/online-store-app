import React, { useState, useEffect } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { FaTrashAlt, FaPen } from "react-icons/fa";
import axios from 'axios';
import '../style/tableSale.css'
import TableSale from "./TableSale";

const Sales = () => {

  const [date, setDate] = useState(new Date());
  const [clientData, setClientData] = useState([]);
  const [productsData, setProductsData] = useState([]);
  const [client, setClient] = useState("");
  const [product, setProduct] = useState("");
  const [price, setPrice] = useState(0);
  const [amount, setAmount] = useState(0);
  const [totalPrice, setTotalPrice] = useState(0);
  const [result, setResult] = useState({
    date:"",
    client:"",
    product:"",
    price:"",
    amount:"",
    totalPrice:""
  });

  const filterPriceProduct = (array,idProduct) =>{
    const [{ price }] = array.filter(item=>item.idProduct===idProduct);
    setPrice(price);
  };

 
    const handleChange = (e,input)=>{
      switch(input){
        case "date":
          setDate(e.target.value);
        break;
        case "client":
          setClient(e.target.value);
        break;
        case "product":
          setProduct(e.target.value);
          filterPriceProduct(productsData,+( e.target.value));
        break;
        case "price":
          setPrice(e.target.value);
        break;
        case "amount":
          setAmount(e.target.value)
        break;
        case "totalPrice":   
          setTotalPrice(e.target.value);
        break;
      }
    };
  
    const handleSubmit = (e)=>{
      e.preventDefault();
  
      const impresion = {
        date,
        client,
        product,
        price,
        amount,
        totalPrice : price*amount
      };
  
      setResult(impresion);
    };


    
    const getListCustomers = async () => {
      try {
       const {data} = await axios.get("http://localhost:5000/customers");
       setClientData(data);
      }catch(error) {
       console.log(error);
      }
   }

   const getListProducts = async () => {
    try {
     const {data} = await axios.get("http://localhost:5000/products");
     setProductsData(data);
    }catch(error) {
     console.log(error);
    }
 }

  useEffect(() => {
    getListCustomers();
    getListProducts();
  }, []);

  return (
  <>
    <div className='container col-12  mt-5'>
     <div className="row">
      <div className='containerLeftC col-5 '>
        {/* DATOS DE VENTA*/}
      <div className="card border-primary">
      <div className="card-header border-primary  fw-semibold fs-5">Invoce Data</div>
       <div className="card-body">
          <form onSubmit={handleSubmit}>

          <div className="row mb-3">
            <label htmlFor="invoceDate" className="col-sm-3 col-form-label ">Date</label>
              <div className="col-sm-9">
                <input type="date"  className="form-control" name="date" onChange={ (e)=>handleChange(e,"date") } value={ date } />
               </div>
          </div>

          <div className="row mt-5 mb-3">
              <label htmlFor="nameProduct" className="col-sm-3 col-form-label">Customer</label>
                <div className="col-sm-9">
                <select   className="form-select mb-3"name="client" onChange={ (e)=>handleChange(e,"client") } value={ client }>
                  <option value="">Choose a Customer</option>
                { clientData.map(item=>(
                  <option key={ item.idCustomer } value={ item.idCustomer  } >{ item.nameCustomer  }</option>
                )) }
              </select>
             </div>
          </div>

          <div className="row mt-5 mb-3">
              <label htmlFor="nameProduct" className="col-sm-3 col-form-label"> Product</label>
                <div className="col-sm-9">
                  <select name="product" className="form-control"onChange={ (e)=>handleChange(e,"product") }  value={ product }>
                      <option value="">Choose a Product</option>
                      { productsData.map(item=>(
                        <option key={ item.idProduct } value={ item.idProduct  } >{ item.productName  }</option>
                      )) }
                  </select>
              </div>
          </div>

          <div className="row mb-3">
             <label htmlFor="price" className="col-sm-3 col-form-label ">Price</label>
               <div className="col-sm-9">
               <input type="number" className="form-control" name="price" onChange={ (e)=>handleChange(e,"price") } value={ price } readOnly/>
              </div>
          </div>

          <div className="row mb-3">
            <label htmlFor="amount" className="col-sm-3 col-form-label ">Amount</label>
              <div className="col-sm-9">
                <input type="number" className="form-control" name="amount" onChange={ (e)=>handleChange(e,"amount") } value={ amount } min={0} />
              </div>
          </div>

          <div className="row mb-5">
            <label htmlFor="totalPrice" className="col-sm-3 col-form-label ">Total Price</label>
              <div className="col-sm-9">
              <input type="number"className="form-control" name="totalPrice" onChange={ (e)=>handleChange(e,"totalPrice") } value={amount*price} readOnly/>
              </div>
          </div>
              
          <div className="card-footer border-primary bg-light fw-semibold fs-5 ">
             <button type="submit" className="btn btn-primary">Add Invoce </button>
         </div>

          </form>
      </div>
      </div>
      </div>

      {/* TABLE SALE*/}  

      <div className='containerRigth col-7 '>
       <div className="card border-primary">
        <div className="card-header border-primary  fw-semibold fs-5">Invoce</div>
         <div className="card-body">

         <TableSale result={ result } />

         <div className="card-footer border-primary bg-light fw-semibold fs-5 p-3">
              <button className="btn btn-primary">Save Invoce</button>

            </div>
         </div>

         </div>
         </div>




    </div>
   </div>
  
  
  </>

  )
}

export default Sales;