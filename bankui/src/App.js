import { Routes, Route } from 'react-router-dom';
import Navbar from './components/static/Navbar';
import Home from './components/static/Home';
import SignUp from './components/register/SignUp';
import Footer from './components/static/Footer';

function App() {
  return (
    <div className="container">
      <Navbar/>
      <Routes>
        <Route path='/' element={ <Home/> } />
        <Route path='/sign-up' element={ <SignUp/> } />

      </Routes>
      <Footer />
    </div>
  );
}

export default App;
