import { Link } from 'react-router-dom';

function Navbar(){
    return(
        <>
            <div className='text-center'>
                <h3>
                    Horrorbank
                </h3>
            </div>
            <ul className="nav nav-pills nav-fill fixed-top bg-dark">
                <li className="nav-item">
                    <Link className="nav-link text-light" aria-current="page" to="/">Home</Link>
                </li>
                <li className="nav-item">
                    <Link className="nav-link text-light" to="/signup">Sign Up</Link>
                </li>
                <li className="nav-item">
                    <Link className="nav-link text-light" to="/signin">Sign In</Link>
                </li>
            </ul>
        </>
    )
}

export default Navbar;