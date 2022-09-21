import React, { useState, useEffect } from 'react'
import { FaTrashAlt, FaPen } from "react-icons/fa";
import axios from 'axios';
import {Modal , ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import Proveedores from './Proveedores';
import '../style/tables.css'


const Productos = () => {
  
  const baseUrl="https://localhost:7071/api/Product/getProduct";
  const [data, setData]= useState([]);
  const [modalInsertar, setModalInsertar] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalEliminar, setModalEliminar] = useState(false);
  const [productoSeleccionado, setproductoSeleccionado]= useState({
    idProduct: '',
    product_name: '',
    description: '',
    amount: '',
    price: '',
    idProvider: ''
  });

  const [dataProvedor, setDataProvedor] = useState([]);
  
  const getListProvider = async () => {
     try {
      const {data} = await axios.get("https://localhost:7071/api/Provider");
      setDataProvedor(data);
     }catch(error) {
      console.log(error);
     }
  }

  const handleChangeProvider = event =>{
    console.log(event.target.value);
    setDataProvedor(event.target.value);
  }



  const handleChange= e=>{
    const {name, value}=e.target;
      setproductoSeleccionado({
          ...productoSeleccionado,
          [name]: value
      });
      console.log(productoSeleccionado);
  }


  const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data)
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionPost=async()=>{
    delete productoSeleccionado.idProduct;
    productoSeleccionado.amount=parseInt(productoSeleccionado.amount);
    productoSeleccionado.price=parseFloat(productoSeleccionado.price);//Para que quedo double?
    await axios.post(baseUrl, productoSeleccionado)
    .then(response=>{
      setData(data.concat(response.data));
      abrirCerrarModalInsertar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionPut=async()=>{
    await axios.put(baseUrl+"/"+productoSeleccionado.idProduct, productoSeleccionado)
    .then(response=>{
      var respuesta= response.data;
      var dataAuxiliar=data;
      dataAuxiliar.map(product=>{
        if(product.idProduct===productoSeleccionado.idProduct){
          product.product_name=respuesta.product_name;
          product.description=respuesta.description;
          product.amount=respuesta.amount;
          product.price=respuesta.price;
          product.idProvider=respuesta.idProvider;
        }
      })
      abrirCerrarModalEditar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionDelete=async()=>{
    await axios.delete(baseUrl+"/"+productoSeleccionado.idProduct)
    .then(response=>{
      setData(data.filter(product=>product.idProduct!==response.data));
      abrirCerrarModalEliminar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const seleccionarproducto=(product, caso)=>{
    setproductoSeleccionado(product);
    (caso==="Editar")?
    abrirCerrarModalEditar() : abrirCerrarModalEliminar();
  }

  useEffect(()=>{
    peticionGet();
    getListProvider();
  },[])


  const abrirCerrarModalInsertar=()=>{
    setModalInsertar(!modalInsertar);
  }

  const abrirCerrarModalEditar=()=>{
    setModalEditar(!modalEditar);
  }

  const abrirCerrarModalEliminar=()=>{
    setModalEliminar(!modalEliminar);
  }


  return (
    // TABLA PROVEEDORES
<div className="container col-12 mt-5">
  <div className="row col-12 justify-content-center">
    <div className="card border-primary">
      <div className='card-header  border-primary  fw-semibold fs-5'> Products </div>
        <div className="card-body">
       <button onClick={()=>abrirCerrarModalInsertar()} className="btn btn-small btn-primary  mb-3 ">New Product</button>
           <table className="table table table-striped table-hover">
             <thead>
                <tr>
                   <th scope="col">Id Product</th>
                    <th scope="col">Product</th>
                    <th scope="col">Description</th>
                    <th scope="col">Amount</th>
                    <th scope="col">Price</th>
                    <th scope="col">ProviderId</th>
                    <th ecope="col">Name Provider</th>
                    <th scope="col">Action</th>
                  </tr>
                </thead>

                <tbody>
                  {data.map(product=>(
                    <tr key={product.idProduct}>
                      <td data-label="Id Product"scope="row">{product.idProduct}</td>
                      <td data-label="Product">{product.product_name}</td>
                      <td data-label="Description">{product.description}</td>
                      <td data-label="Amount">{product.amount}</td>
                      <td data-label="Price">$ {product.price}</td>
                      <td data-label="Id Provider">{product.idProvider}</td>
                      <td data-label="Name Provider"></td>
                      <td data-label="Action">
                      <button className="btn btn-small btn-primary me-1" onClick={()=>seleccionarproducto(product,"Editar")}>
                        <FaPen/>
                      </button>
                      <button className="btn btn-small btn-danger" onClick={()=>seleccionarproducto(product, "Eliminar")}>
                        <FaTrashAlt />
                      </button>
                      </td>
                        </tr>
                        ))}
                </tbody> 
               
            </table>

<div>
            {/* MODAL INSERTAR */}

<Modal isOpen={modalInsertar} backdrop={false} >
<ModalHeader>New Product</ModalHeader>
<ModalBody>
    <div className="form-group mb-3">
        <label>Name Product:</label>
        <input type="text" className="form-control mb-3" name="product_name" onChange={handleChange} />
        
        <label>Description:</label>
        <input type="text" className="form-control mb-3" name="description" onChange={handleChange}  />
        
        <label>Amount:</label>
        <input type="number" className="form-control mb-3" name="amount" onChange={handleChange} min="1"  />
        
        <label>Price:</label>
        <input type="numeric" className="form-control mb-3" name="price" onChange={handleChange}  />
        
        <label>idProvider:</label>
        <input type="text" className="form-control mb-3" name="idProvider" onChange={handleChange}/>

        <label>Name Provider</label>
        <select className="form-select mb-3" aria-label=".form-select-lg example" onChange={handleChangeProvider}>
        {dataProvedor.map(elemento=>(
          <option key={elemento.idProvider} value={elemento.idProvider}>{elemento.provider_name}</option>
        )
          
        )}
</select>
        
       
    </div>
</ModalBody>
<ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPost()}>New Product</button>{" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalInsertar()}>Cancel</button>
</ModalFooter>
</Modal>

</div>
             

{/* MODAL Editar */}
<Modal isOpen={modalEditar}  backdrop={false}>
<ModalHeader>Edit Product</ModalHeader>
<ModalBody>
    <div className="form-group">
        <label>ID Product:</label>
        <br />
        <input type="text" className="form-control" name="idProduct" readOnly value={ productoSeleccionado && productoSeleccionado.idProduct}/>
        <br />
        <label>Name Product:</label>
        <br />
        <input type="text" className="form-control" name="product_name" onChange={handleChange} value={ productoSeleccionado && productoSeleccionado.product_name} />
        <br />
        <label>Description:</label>
        <br />
        <input type="text" className="form-control" name="description" onChange={handleChange} value={ productoSeleccionado && productoSeleccionado.description}/>
        <br />
        <label>Amount:</label>
        <br />
        <input type="number" className="form-control" name="amount" min="1" onChange={handleChange} value={ productoSeleccionado && productoSeleccionado.amount}/>
        <br />
        <label>Price:</label>
        <br />
        <input type="number" className="form-control" name="price" onChange={handleChange} value={ productoSeleccionado && productoSeleccionado.price} />
        <br />
        <label>Provider:</label>
        <br />
        <input type="text" className="form-control" name="idProvider" onChange={handleChange}  value={ productoSeleccionado && productoSeleccionado.idProvider}  />
       
    </div>
</ModalBody>
<ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPut()}>Edit</button>{" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalEditar()}>Cancel</button>
</ModalFooter>
</Modal> 


{/* MODAL Eliminar */}
<Modal isOpen={modalEliminar}  backdrop={false}>
        <ModalBody>
            Are you sure you want to delete the selected Customer "{productoSeleccionado && productoSeleccionado. product_name}"?
        </ModalBody>
        <ModalFooter>
            <button className="btn btn-danger" onClick={()=>peticionDelete()}>Yes</button>
            <button className="btn btn-secondary" onClick={()=>abrirCerrarModalEliminar()}>No</button>
        </ModalFooter>
    </Modal> 
             
        </div>
    </div>    
  </div>
</div>

 
  )
}

export default Productos