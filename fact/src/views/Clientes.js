import React, { useState, useEffect } from 'react'
import { FaTrashAlt, FaPen } from "react-icons/fa";
import axios from 'axios';
import {Modal , ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const Clientes = () => {
 const Url = "  https://localhost:7071/api/Customer";
const [data, setData]=useState([]);
const [modalInsertar, setModalInsertar]=useState(false);
const [modalEliminar , setModalEliminar]=useState(false);
const [modalEditar, setModalEditar]=useState(false);
const [CustomerSeleccionado, setCustomerSeleccionado]=useState({
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
    setCustomerSeleccionado({
        ...CustomerSeleccionado,
        [name]: value
    });
    console.log(CustomerSeleccionado);
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


const peticionPut = async ()=>{
  CustomerSeleccionado.document=parseInt(CustomerSeleccionado.document);
  CustomerSeleccionado.phoneNumber=parseInt(CustomerSeleccionado.phoneNumber);
  await axios.put(Url + "/" + CustomerSeleccionado.idCustomer, CustomerSeleccionado)
  .then(response=>{
      var respuesta = response.data;
      var dataAuxiliar = data;
      dataAuxiliar.map(Customer=>{
          if (Customer.idCustomer === CustomerSeleccionado.idCustomer) {
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
const seleccionarcustomer=(Customer, caso)=>{
    setCustomerSeleccionado(Customer);
    (caso === "Editar")?
    abrirCerrarModalEditar(): abrirCerrarModalEliminar();
}


useEffect(()=>{
    peticionGet();
},[])

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
                       <th scope="col">idCustomer</th>
                        <th scope="col">Name</th>
                        <th scope="col">Surname</th>
                        <th scope="col">document</th>
                        <th scope="col">Phone Number</th>
                        <th scope="col">Mail</th>
                        <th scope="col">Acción</th>
                      </tr>
                    </thead>
    
                    <tbody>
                    {data.map(Customer=>(
                     <tr key={Customer.idCustomer}>
                         <td>{Customer.idCustomer}</td>
                         <td>{Customer.name}</td>
                         <td>{Customer.surname}</td>
                         <td>{Customer.document}</td>
                         <td>{Customer.phoneNumber}</td>
                         <td>{Customer.mail}</td>
                          <td>
                          <button className="btn btn-small btn-primary me-1" onClick={()=>seleccionarcustomer(Customer,"Editar")}>
                            <FaPen/>
                          </button>
                          <button className="btn btn-small btn-danger" onClick={()=>abrirCerrarModalEliminar(Customer, "Eliminar")}>
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
        <button className="btn btn-primary" onClick={()=>peticionPut()}>New</button>{" "}
        <button className="btn btn-danger" onClick={()=>abrirCerrarModalInsertar()}>Cancel</button>
    </ModalFooter>
    </Modal>
    
    </div>
                 
    
            </div>
        </div>    
      </div>
    </div>
             );
} 
export default Clientes