import './App.css'
import OrdersOverview from './pages/OrdersOverview'
import OrderOverview from './pages/OrderOverview';
import NewOrder from './pages/NewOrder'
import Navbar from './components/navbar/Navbar'
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function App() {
    return (
        <div className="layout">
            <div className="navbar">
                <Navbar/>
            </div>
            <div className="content">
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<OrdersOverview/>} />
                        <Route path="/neworder" element={<NewOrder/>} />
                        <Route path="/order" element={<OrderOverview/>} />
                    </Routes>
                </BrowserRouter>
            </div>
      </div>
  )
}

export default App