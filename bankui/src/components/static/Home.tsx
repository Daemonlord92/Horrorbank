import { Link } from 'react-router-dom';

export default function Home(){
    return(
        <>
            <div className='col-md-2'/>
            <div className='col-md-8 d-flex justify-content-between'>
                <div className="card col-md-4 m-3 h-25">
                    <div className="card-body">
                        <h5 className="card-title">Slasher Funds</h5>
                        <p className="card-text overflow-auto">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        <Link className="btn btn-primary" to='/signup'>Go somewhere</Link>
                    </div>
                </div>
                <div className="card col-md-4 m-3 h-25">
                    <div className="card-body">
                        <h5 className="card-title">Trap House Loans</h5>
                        <p className="card-text overflow-auto">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        <Link className="btn btn-primary" to='/signup'>Go somewhere</Link>
                    </div>
                </div>
                <div className="card col-md-4 m-3 h-25">
                    <div className="card-body">
                        <h5 className="card-title">Victum Slaugter Clean-Up Funds</h5>
                        <p className="card-text overflow-auto">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        <Link className="btn btn-primary" to='/signup'>Go somewhere</Link>
                    </div>
                </div>
                <div className="card col-md-4 m-3 h-25">
                    <div className="card-body">
                        <h5 className="card-title">Serial Killer Funding</h5>
                        <p className="card-text overflow-auto">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        <Link className="btn btn-primary" to='/signup'>Go somewhere</Link>
                    </div>
                </div>
            </div>
            <div className='col-md-2'/>
        </>
    )
}