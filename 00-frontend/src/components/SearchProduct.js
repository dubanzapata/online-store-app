import {useEffect, useState} from 'react';
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";



function SearchProduct() {

  const [users, setUsers]= useState([]);
  const [Customer, setTablaCustomer]= useState([]);
  const [busqueda, setBusqueda]= useState("");

const peticionGet=async()=>{
  await axios.get("https://localhost:7071/api/Product")
  .then(response=>{
    setUsers(response.data);
    setTablaCustomer(response.data);
  }).catch(error=>{
    console.log(error);
  })
}

const handleChange=e=>{
  setBusqueda(e.target.value);
  filtrar(e.target.value);
}

const filtrar=(terminoBusqueda)=>{
  var results=Customer.filter((e)=>{
    if(e.product_name.toString().toLowerCase().includes(terminoBusqueda.toLowerCase())
    
    ){
      return e;
    }
  });
  setUsers(results);
}

useEffect(()=>{
peticionGet();
},[])

  return (
    <div className="App">
      <div className="containerInput">
        <input
          className="form-control inputBuscar"
          value={busqueda}
          placeholder="Búsqueda por Nombre "
          onChange={handleChange}
          
        />
      
      </div>

     <div className="table-responsive">
       <table className="table table-sm table-bordered">
         <thead>
         <tr>
                       <th scope="col">id Product</th>
                        <th scope="col">Name Product</th>
                        <th scope="col">Amount</th>
                        <th></th>

                      </tr>
         </thead>

         <tbody>
         {users.map((users)=>(
           <tr key={users.idProduct}>
            <td>{users.idProduct}</td>
            <td>{users.product_name}</td>
            <td>{users.amount}</td>
            <td>
              <button className='btn btn-primary'>Add</button>
            </td>
           </tr> 
            ))}
         </tbody>

       </table>

     </div>
    </div>
  );
}

export default SearchProduct;