import './App.css';
import Home from './Components/Home';
import { Route, Routes, NavLink, BrowserRouter} from 'react-router-dom';
import  UsersPage  from './Components/Users';

function App() {
  return (
    <BrowserRouter>
    <div className="App  container">
      <h3 className="d-flex justify-content-center m-3">
        User Api Frontend
      </h3>

      <nav className="navbar navbar-expand-sm bg-light navbar-dark">
        <ul className='navbar-nav'>
          <li className='nav-item- m-1'>
          <NavLink className="btn btn-ligh btn-outline-primary" to="/home">
            Home
          </NavLink>
          </li>
          <li className='nav-item- m-1'>
          <NavLink className="btn btn-ligh btn-outline-primary" to="/users">
            Users
          </NavLink>
          </li>
        </ul>
      </nav>
      <Routes>
        <Route path='/home' element={<Home />}/>
        <Route path='/users' element={<UsersPage />}/>
        </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
