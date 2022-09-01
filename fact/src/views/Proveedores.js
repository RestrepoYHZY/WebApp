import React from 'react'

const Proveedores = () => {
  return (
    <div class="container  mt-5">
        
    <div class="card">
        <div class="card-body">
          <button class="btn btn-small btn-primary mb-2 ">Nuevo Proveedor</button>
          
           <table class="table table-hover  align-middle">
             <thead>
                <tr>
                   <th scope="col">Código</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Apellido</th>
                    <th scope="col">Documento</th>
                    <th scope="col">Télefono</th>
                    <th scope="col">Dirección</th>
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

export default Proveedores