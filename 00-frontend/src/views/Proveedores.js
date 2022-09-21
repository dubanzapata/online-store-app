import React, { useState, useEffect } from 'react'
import { FaTrashAlt, FaPen } from "react-icons/fa";
import axios from 'axios';
import {Modal , ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../style/tables.css'

const Proveedores = () => {
  
  const baseUrl="https://localhost:7071/api/Provider";
  const [data, setData]= useState([]); //Estado
  const [modalInsertar, setModalInsertar] = useState(false);
  const [modalEditar, setModalEditar] = useState(false);
  const [modalEliminar, setModalEliminar] = useState(false);
  const [proveedorSeleccionado, setproveedorSeleccionado]= useState({
    idProvider: '',
    provider_name: '',
    nit: '',
    phone: '',
    address: ''
  });

  const handleChange= e=>{
    const {name, value}=e.target;
      setproveedorSeleccionado({
          ...proveedorSeleccionado,
          [name]: value
      });
      console.log(proveedorSeleccionado);
  }


  const peticionGet=async()=>{
    await axios.get(baseUrl)
    .then(response=>{
      setData(response.data)
console.table(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionPost=async()=>{
    delete proveedorSeleccionado.idProvider;
    await axios.post(baseUrl, proveedorSeleccionado)
    .then(response=>{
      setData(data.concat(response.data));
      abrirCerrarModalInsertar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionPut=async()=>{
    await axios.put(baseUrl+"/"+proveedorSeleccionado.idProvider, proveedorSeleccionado)
    .then(response=>{
      var respuesta= response.data;
      var dataAuxiliar=data;
      dataAuxiliar.map(provider=>{
        if(provider.idProvider===proveedorSeleccionado.idProvider){
          provider.provider_name=respuesta.provider_name;
          provider.nit=respuesta.nit;
          provider.phone=respuesta.phone;
          provider.address=respuesta.address;
        }
      })
      abrirCerrarModalEditar();
    }).catch(error=>{
      console.log(error);
    })
  }

  const peticionDelete=async()=>{
    await axios.delete(baseUrl+"/"+proveedorSeleccionado.idProvider)
    .then(response=>{
      setData(data.filter(provider=>provider.idProvider!==response.data));
      
      abrirCerrarModalEliminar();
    }).catch(error=>{
      console.log(error);
      
    })
  }

  const seleccionarproveedor=(provider, caso)=>{
    setproveedorSeleccionado(provider);
    (caso==="Editar")?
    abrirCerrarModalEditar() : abrirCerrarModalEliminar();
  }

  useEffect(()=>{
    peticionGet();
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
      <div className='card-header  border-primary  fw-semibold fs-5'> Providers </div>
        <div className="card-body">
       <button onClick={()=>abrirCerrarModalInsertar()} className="btn btn-small btn-primary  mb-3 btnNew">New Provider</button>
           <table className="table table table-striped table-hover ">
             <thead>
                <tr>
                   <th scope="col">Id Provider</th>
                    <th scope="col">Name Provider</th>
                    <th scope="col">Nit</th>
                    <th scope="col">Phone Number</th>
                    <th scope="col">Address</th>
                    <th scope="col">Action</th>
                  </tr>
                </thead>

                <tbody>
                  {data.map(provider=>(
                    <tr key={provider.idProvider}>
                      <td data-label="Id Provider" scope="row">{provider.idProvider}</td>
                      <td data-label="Name Provider" >{provider.provider_name}</td>
                      <td data-label="Nit" >{provider.nit}</td>
                      <td data-label="Phone Number" >{provider.phone}</td>
                      <td data-label="Addres" >{provider.address}</td>
                      <td data-label="Action">
                      <button className="btn btn-small btn-primary me-1 btnOne" onClick={()=>seleccionarproveedor(provider,"Editar")}>
                        <FaPen/>
                      </button>
                      <button className="btn btn-small btn-danger" onClick={()=>seleccionarproveedor(provider,"eliminar")}>
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
<ModalHeader>New Provider</ModalHeader>
<ModalBody>
    <div className="form-group mb-3">
        <label>Name Provider:</label>
        <input type="text" className="form-control mb-3" name="provider_name" onChange={handleChange} />

        <label>Nit:</label>
        <input type="text" className="form-control mb-3" name="nit" onChange={handleChange} />

        <label>PhoneNumber:</label>
        <input type="txt" className="form-control mb-3" name="phone" onChange={handleChange} />
        
        <label>Address:</label>
        <input type="text" className="form-control mb-3" name="address" onChange={handleChange}/>
        
       
    </div>
</ModalBody>
<ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPost()}>New Provider</button>{" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalInsertar()}>Cancel</button>
</ModalFooter>
</Modal>

</div>
             

{/* MODAL EDITAR */}

 <Modal isOpen={modalEditar} backdrop={false} >
<ModalHeader>Edit Provider</ModalHeader>
<ModalBody>
    <div className="form-group">
        <label>Id Provider:</label>
        <br />
        <input type="text" className="form-control" name="idProvider" readOnly onChange={handleChange} value={ proveedorSeleccionado && proveedorSeleccionado.idProvider} />
        <br />
        <label>Name Provider:</label>
        <br />
        <input type="text" className="form-control" name="provider_name" onChange={handleChange} value={ proveedorSeleccionado && proveedorSeleccionado.provider_name}/>
        <br />
        <label>Nit:</label>
        <br />
        <input type="number" className="form-control" name="nit" onChange={handleChange}  value={ proveedorSeleccionado && proveedorSeleccionado.nit} />
        <br />
        <label>PhoneNumber:</label>
        <br />
        <input type="number" className="form-control" name="phone" onChange={handleChange} value={ proveedorSeleccionado && proveedorSeleccionado.phone}/>
        <br />
        <label>Address:</label>
        <br />
        <input type="text" className="form-control" name="address" onChange={handleChange}  value={ proveedorSeleccionado && proveedorSeleccionado.address} />
        <br />
       
    </div>
</ModalBody>
<ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPut()}>Edit Provider</button>{" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalEditar()}>Cancel</button>
</ModalFooter>
</Modal> 


{/* MODAL Eliminar */}
 <Modal isOpen={modalEliminar} backdrop={false}>
        <ModalBody>
            Are you sure you want to delete the selected provider "{proveedorSeleccionado && proveedorSeleccionado.provider_name}"? 
        </ModalBody>
        <ModalFooter>
            <button className="btn btn-danger" onClick={()=>peticionDelete() }>Yes</button>
            <button className="btn btn-secondary" onClick={()=>abrirCerrarModalEliminar()}>No</button>
        </ModalFooter>
    </Modal>   
             
        </div>
    </div>    
  </div>
</div>

 
  )
}

export default Proveedores;