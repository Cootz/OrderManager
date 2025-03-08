import { useState, useEffect } from 'react';
import OrdersList from '../components/orderslist/OrdersList';
import './OrdersOverview.css';
import { getOrders } from '../api/OrdersAPI';

function OrdersOverview() {
    const [orders, setOrders] = useState([]);

    //Pagination is not implemented in this app, but api allows it
    let pagination = 100;
    let currentPageIndex = 0;
  
    useEffect(() => {
      const fetchOrders = async () => setOrders(await getOrders(pagination, currentPageIndex));

      fetchOrders();
    }, []);
  
    return (
      <div className="orders-overview-content">
        <h1>Orders:</h1>
        <OrdersList orders={orders}/>
      </div>
    );
}

export default OrdersOverview;