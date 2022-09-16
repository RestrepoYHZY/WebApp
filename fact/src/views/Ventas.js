import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { FaTrashAlt} from "react-icons/fa";
import SearchCliente from "../components/SearchCliente";
import SearchProduct from "../components/SearchProduct";

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
                    <div className="row mb-3 ">
                      <label className="col-sm-3 col-form-label ">Amount</label>
                        <div className="col-sm-9">
                          <input type="number" className="form-control" min="1" />
                        </div>
                    </div>

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
                          
                        <button className="btn btn-danger me-1" >
                           <FaTrashAlt />
                       </button>
                     </td>
                   </tr>
           
           {/* PARA EL MONTO tOTAL*/}
            <tr>
                <td colspan="5"></td>
                <td> Total</td>
                <td> 200000</td>
          </tr>
                   </tbody>
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