import { Link } from 'react-router-dom';

export default function Navbar() {


    return(
        <div className="nav nav-tab justify-content-end fixed-top bg-dark">
            <div className='nav-item'>
                <Link to='/' className='nav-link text-danger'>Home</Link>
            </div>
            <div className='nav-item'>
                <Link to='/sign-up' className='nav-link text-danger'>Sign Up</Link>
            </div>
            <div className='nav-item'>
                <Link to='/sign-in' className='nav-link text-danger'>Sign In</Link>
            </div>
        </div>
    )
}