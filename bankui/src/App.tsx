import React from 'react';
import './App.scss';
import Navbar from './components/static/Navbar';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import Home from './components/static/Home';
import Register from './components/register/Register';

function App() {
  return (
    <Router>
      <div className='mt-5 container'>
        <Navbar/>
        <Routes>
          <Route path='/' element={ <Home/>}/>
          <Route path='/signup' element={ <Register />}/>
        </Routes>
      </div>
      <ToastContainer />
    </Router>
  );
}

export default App;
