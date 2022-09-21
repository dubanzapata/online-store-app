import React from 'react'
import { FaTrashAlt, FaPen} from "react-icons/fa";
import {GrFormView} from "react-icons/gr";
import {useState , useEffect} from 'react';
import axios from 'axios';
import {Modal , ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';



const ListVentas = () => {

    const baseUrl = "";
    const [data, setData]=useState([]);
    const [modalInsert, setModalInsert] = useState(false);
  const [ventaSeleccionada, setVentasSeleccionada]=useState({
      idPedido: '',
      idProducto:'',
      idCliente: '',
      precio:'',
      fecha_emision: '',
      direccion: ''
      
     });

    const handleChange=e=>{
      const {name, value}=e.target;
      setVentasSeleccionada({
          ...ventaSeleccionada,
          [name]: value
      });
      console.log(ventaSeleccionada);
  }
  


  const abrirCerrarModalInsertar=()=>{
    setModalInsert(!modalInsert);
  }

  const peticionGet = async ()=>{
    await axios.get(baseUrl)
    .then(response=>{
        setData(response.data);
    }).catch(error=>{
        console.log(error);
    })
    }
    const peticionPost = async ()=>{
      delete ventaSeleccionada.idPedido;
      await axios.post(baseUrl, ventaSeleccionada)
      .then(response=>{
          setData(data.concat(response.data));
          abrirCerrarModalInsertar();
      }).catch(error=>{
          console.log(error);
      })
      }
    useEffect(()=>{
      peticionGet();
  },[])
  
  return (
   
<div className="container col-12 mt-5">
  <div className="row col-12 justify-content-center">
    <div className="card border-primary">
      <div className='card-header  border-primary  fw-semibold fs-5'> Ventas </div>
        <div className="card-body">
       <button onClick={()=>abrirCerrarModalInsertar()} className="btn btn-small btn-primary  mb-2 ">Nueva Venta</button>
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
                    <th scope="col">Factura</th>
                  </tr>
                  </thead>
                  <tbody>
             {data.map(Ventas =>(
                 <tr key={Ventas.idPedido}>
                  <td>{Ventas.idPedido}</td> 
                  <td>{Ventas.idProducto}</td>
                     <td>{Ventas.idCliente}</td>
                     <td>{Ventas.precio}</td>
                     <td>{Ventas.fecha_emision}</td>
                     <td>
                        <button className="btn  btn-primary me-1" >
                          <FaPen/>
                        </button> 
                    
                        <button className="btn btn-danger me-1" >
                          <FaTrashAlt />
                        </button>
                        </td>
                        <td>
                        <button className="btn btn-info" >
                          <GrFormView/>
                        </button>
                        </td>
                 </tr>
             ))}
         </tbody>
            </table>
             

<Modal isOpen={modalInsert} >
<ModalHeader>Nueva Venta</ModalHeader>
<ModalBody>
    <div className="form-group">
        <label>Cliente</label>
        <br />
        <input type="number" className="form-control" name="idCliente" onChange={handleChange}  />
        <br />
        <label>Producto</label>
        <br />
        <input type="number" className="form-control" name="idProducto" onChange={handleChange} />
        <br />
        <label>Precio</label>
        <br />
        <input type="number" className="form-control" name="precio" onChange={handleChange}/>
        <br />
        <label>Fecha:</label>
        <br />
        <input type="date" className="form-control" name="fecha_emision" onChange={handleChange}/>
        <br />
  
    </div>
</ModalBody>
<ModalFooter>
    <button className="btn btn-primary" onClick={()=>peticionPost()} >New</button>{" "}
    <button className="btn btn-danger" onClick={()=>abrirCerrarModalInsertar}>Cancel</button>
</ModalFooter>
</Modal>






        </div>
    </div>
  </div>
</div>
  )
}
  

export default ListVentas;