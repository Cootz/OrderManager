import { useState } from 'react'
import './App.css'
import OrdersOverview from './pages/OrdersOverview'

function App() {
  return (
      <div className="content">
          <BrowserRouter>
              <Routes>
                  <Route path="/" element={<OrdersOverview/>} />
              </Routes>
          </BrowserRouter>
      </div>
  )
}

export default App