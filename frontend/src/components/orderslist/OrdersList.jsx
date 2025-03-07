import './OrdersList.css'
import OrdersListItem from '../orderslistitem/OrdersListItem';

export default function OrdersList({orders}) {
    return (
        <div className="orders-list-content">
            {orders?.length === 0 || null ? (
                <h2>No orders found.</h2>
            ) : (
                orders.map((order, index) => 
                    <OrdersListItem key={index} order={order}/>
                )
            )}
        </div>
    );
}