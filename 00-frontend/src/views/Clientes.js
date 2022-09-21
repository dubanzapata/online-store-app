import React, { useState, useEffect } from 'react'
import { FaTrashAlt, FaPen } from "react-icons/fa";
import axios from 'axios';
import {Modal , ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../style/tables.css'

const Clientes = () => {
const Url = " https://localhost:7071/api/Customer";
const [data, setData]=useState([]);
const [modalInsertar, setModalInsertar]=useState(false);
const [modalEliminar , setModalEliminar]=useState(false);
const [modalEditar, setModalEditar]=useState(false);
const [customerSeleccionado, setcustomerSeleccionado]=useState({
 idCustomer: '',
 name: '',
 surname: '',
 document: '',
 phoneNumber: '',
 mail: '',
 password: ''
});

const handleChange=e=>{
    const {name, value}=e.target;
    setcustomerSeleccionado({
        ...customerSeleccionado,
        [name]: value
    });
    console.log(customerSeleccionado);
}


const abrirCerrarModalInsertar=()=>{
    setModalInsertar(!modalInsertar);
}

const abrirCerrarModalEditar=()=>{
    setModalEditar(!modalEditar);
}

const abrirCerrarModalEliminar=()=>{
    setModalEliminar(!modalEliminar);
}


const peticionGet = async ()=>{
await axios.get(Url)
.then(response=>{
    setData(response.data);
}).catch(error=>{
    console.log(error);
})
}

 const peticionPost=async()=>{
    delete customerSeleccionado.idCustomer;
    await axios.post(Url, customerSeleccionado)
    .then(response=>{
      setData(data.concat(response.data));
      abrirCerrarModalInsertar();
    }).catch(error=>{
      console.log(error);
    })
  }

const peticionPut = async ()=>{
  
  await axios.put(Url + "/" + customerSeleccionado.idCustomer, customerSeleccionado)
  .then(response=>{
      var respuesta = response.data;
      var dataAuxiliar = data;
      dataAuxiliar.map(Customer=>{
          if (Customer.idCustomer === customerSeleccionado.idCustomer) {
              Customer.name = respuesta.name;
              Customer.surname = respuesta.surname;
              Customer.document = respuesta.document;
              Customer.phoneNumber = respuesta.phoneNumber;
              Customer.mail = respuesta.mail; 
          }
      });
      abrirCerrarModalEditar();
  }).catch(error=>{
      console.log(error);
  })
  }

  
  const peticionDelete=async()=>{
    await axios.delete(Url+"/"+ customerSeleccionado.idCustomer)
    .then(response=>{
      setData(data.filter(Customer=>Customer.idCustomer!==response.data));
      abrirCerrarModalEliminar();
    }).catch(error=>{
      console.log(error);
    })
  }
  
const seleccionarCustomer=(Customer, caso)=>{
    setcustomerSeleccionado(Customer);
    (caso === "Editar")?
    abrirCerrarModalEditar(): abrirCerrarModalEliminar();
}


useEffect(()=>{
    peticionGet();
},[]);

    return(
      <div className="container col-12 mt-5">
      <div className="row col-12 justify-content-center">
        <div className="card border-primary">
          <div className='card-header  border-primary  fw-semibold fs-5'> Customers </div>
            <div className="card-body">
           <button onClick={()=>abrirCerrarModalInsertar()} className="btn btn-small btn-primary  mb-3 ">New Customer</button>
               <table className="table table table-striped table-hover">
                 <thead>
                    <tr>
                       <th scope="col">id Customer</th>
                        <th scope="col">Name</th>
                        <th scope="col">Surname</th>
                        <th scope="col">Document</th>
                        <th scope="col">Phone Number</th>
                        <th scope="col">Mail</th>
                        <th scope="col">Action</th>
                      </tr>
                    </thead>
    
                    <tbody>
                    {data.map(Customer=>(
                     <tr key={Customer.idCustomer}>
                         <td data-label="Id Customer">{Customer.idCustomer}</td>
                         <td data-label="Name">{Customer.name}</td>
                         <td data-label="Surname">{Customer.surname}</td>
                         <td data-label="Document">{Customer.document}</td>
                         <td data-label="Phone Number">{Customer.phoneNumber}</td>
                         <td data-label="Mail">{Customer.mail}</td>
                          <td data-label="Action">
                          <button className="btn btn-small btn-primary me-1 btnOne" onClick={()=>seleccionarCustomer(Customer,"Editar")}>
                            <FaPen/>
                          </button>
                          <button className="btn btn-small btn-danger" onClick={()=>seleccionarCustomer(Customer, "Eliminar")}>
                            <FaTrashAlt />
                          </button>
                          </td>
                            </tr>
                            ))}
                    </tbody> 
                   
                </table>
    
    <div>
                {/* MODAL INSERTAR */}
    
    <Modal isOpen={modalInsertar} backdrop={false} toggle={()=>setModalInsertar(!modalInsertar)}>
    <ModalHeader>New Customer</ModalHeader>
            <ModalBody>
                <div className="form-group">
                    <label>Name:</label>
                    <br />
                    <input type="text" className="form-control" name="name" onChange={handleChange} />
                    <br />
                    <label>Surname:</label>
                    <br />
                    <input type="text" className="form-control" name="surname" onChange={handleChange}/>
                    <br />
                    <label>Document:</label>
                    <br />
                    <input type="numeric" className="form-control" name="document" onChange={handleChange}/>
                    <br />
                    <label>Phone Number:</label>
                    <br />
                    <input type="tel" className="form-control" name="phoneNumber" onChange={handleChange} />
                    <br />
                    <label>Mail:</label>
                    <br />
                    <input type="email" className="form-control" name="mail" onChange={handleChange}/>
                    <br />
                    
                </div>
    </ModalBody>
    <ModalFooter>
        <button className="btn btn-primary" onClick={()=>peticionPost()}>New</button>{" "}
        <button className="btn btn-danger" onClick={()=>abrirCerrarModalInsertar()}>Cancel</button>
    </ModalFooter>
    </Modal>
    
    </div>
       
{/* MODAL EDITAR */}

 <Modal isOpen={modalEditar} backdrop={false} >
<ModalHeader>Edit Customers</ModalHeader>
<ModalBody>
<div className="form-group">
                    <label>Id Customer:</label>
                    <br />
                    <input type="text" className="form-control" name="idCustomer" readOnly onChange={handleChange} value={ customerSeleccionado && customerSeleccionado.idCustomer} />
                    <br />
                    <label>Name:</label>
                    <br />
                    <input type="text" className="form-control" name="name"   onChange={handleChange}  value={ customerSeleccionado && customerSeleccionado.name}  />
                    <br />
                    <label>Surname:</label>
                    <br />
                    <input type="text" className="form-control" name="surname" onChange={handleChange}  value={ customerSeleccionado && customerSeleccionado.surname}/>
                    <br />
                    <label>Document:</label>
                    <br />
                    <input type="numeric" className="form-control" name="document"  onChange={handleChange}  value={ customerSeleccionado && customerSeleccionado.document}/>
                    <br />
                    <label>Phone Number:</label>
                    <br />
                    <input type="tel" className="form-control" name="phoneNumber"  onChange={handleChange}  value={ customerSeleccionado && customerSeleccionado.phoneNumber}/>
                    <br />
                    <label>Mail:</label>
                    <br />
                    <input type="email" className="form-control" name="mail" onChange={handleChange}  value={ customerSeleccionado && customerSeleccionado.mail}/>
                    <br />
                    
                </div>
</ModalBody>
<ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPut()}>Edit Customer</button>{" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalEditar()}>Cancel</button>
</ModalFooter>
</Modal> 
 
 
{/* MODAL Eliminar */}
<Modal isOpen={modalEliminar} backdrop={false}>
        <ModalBody>
        Are you sure you want to delete the selected Customer "{customerSeleccionado && customerSeleccionado.name}"?  
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
             );
} 
export default Clientes;