
import { Link, NavLink } from "react-router-dom";


const Navbar = () => {
  return (
<nav class="navbar navbar-expand-lg bg-info ">
        <div class="container-fluid ms-3">
            <ul class="navbar-nav">
            <Link  to="/" className="nav-link fw-semibold fs-5">Inicio</Link>
                   
            <li class="nav-item ms-2">
                <Link  to="/Ventas" className="nav-link fw-semibold fs-5">Ventas</Link>
            </li>

            <li class="nav-item ms-2">
                <Link to="/Productos"className="nav-link fw-semibold fs-5">Productos</Link>
            </li>

            <li class="nav-item ms-2">
                <Link  to="/CLientes" className="nav-link fw-semibold fs-5"> Clientes </Link>
            </li>
                
            <li class="nav-item ms-2">
                <Link  to="/Proveedores" className="nav-link fw-semibold fs-5"> Proveedores </Link>
            </li>
            </ul>
            <form class="d-flex me-5">
        <button class="btn btn-light my-2 my-sm-0" type="submit">Search</button>
      </form>
        </div>
    </nav>

)
}

export default Navbar







