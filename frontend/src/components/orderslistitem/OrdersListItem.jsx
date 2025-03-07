import './OrdersListItem.css'

export default function OrdersListItem({order}){
    return (
        <div content="order-list-item-content">
            <h2>{order.id}</h2>
            <p>{order.departureCity}</p>
            <p>{order.departureLocation}</p>
            <p>{order.arrivalCity}</p>
            <p>{order.arrivalLocation}</p>
            <p>{order.weight} kg</p>
            <p>{order.pickupDate}</p>
        </div>
    );
}