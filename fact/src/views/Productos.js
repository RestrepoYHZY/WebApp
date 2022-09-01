import React from 'react'
import { Bitrash } from "react-icons/bi";

const Productos = () => {
  return (
    
    <div class="container  mt-5">
        
    <div class="card">
        <div class="card-body">
          <button class="btn btn-small btn-primary mb-2 ">Nuevo Producto</button>
          
           <table class="table table-hover  align-middle">
             <thead>
                <tr>
                   <th scope="col">Código</th>
                    <th scope="col">Producto</th>
                    <th scope="col">Cantidad</th>
                    <th scope="col">Precio</th>
                    <th scope="col">Proveedor</th>
                    <th scope="col">Acción</th>
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
                          <button class="btn btn-small btn-primary me-1">Editar</button>
                          <button class="btn btn-small btn-danger" >Eliminar</button>
                      </td>
                        </tr>
                </tbody>  
            </table>
        </div>
    </div>
    </div>
  )
}

export default Productos