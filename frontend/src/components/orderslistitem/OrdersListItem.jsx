import { useNavigate } from 'react-router-dom';
import './OrdersListItem.css'

export default function OrdersListItem({order}){
    const navigate = useNavigate();

    function handleClick() {
        navigate("/order", {state: order});
    }

    return (
        <a className="order-list-item-content" onClick={handleClick}>
            <p>{order.id}</p>
            <p>From {order.departureCity}</p>
            <p>To {order.arrivalCity}</p>
            <p>{order.weight} kg</p>
            <p>{order.pickupDate}</p>
        </a>
    );
}