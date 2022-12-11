import React from 'react';
import jwtDecode from 'jwt-decode';

const Dashboard = () => {
    const decodeJwT = jwtDecode(sessionStorage.getItem("Authorization"));

  return (
    <div className='col-md-12 mt-5'>
        <div className="row mt-5">
            <div className="col-md-4"/>
            <div className="col-md-4 border border-5 border-danger text-center p-3 mx-auto">
                <h2 className="text-danger">
                    Horrorbank
                </h2>
            </div>
            <div className="col-md-4"/>
        </div>
        <div className='row mt-5'>
            <div className='col-md-4'/>
            <div className='col-md-4 border border-5 border-danger text-center p-3 mx-auto'>
                <h3>
                    {decodeJwT.FirstName}
                </h3>
            </div>
            <div className='col-md-4'/>
        </div>
    </div>
  )
}

export default Dashboard