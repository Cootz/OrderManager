import { useLocation } from 'react-router-dom';
import './OrderOverview.css'

function OrderOverview() {
  const location = useLocation();
  const order  = location.state;

  if (!order)
  {
    return (
      <h2>Order not found</h2>
    );
  }

  return (
    <div className="order-overview-content">
      <h2>Заказ №{order.id}</h2>
      <p>
        Город отправителя: {order.departureCity}
      </p>
      <p>
        Адрес отправителя: {order.departureLocation}
      </p>
      <p>
        Город получателя: {order.arrivalCity}
      </p>
      <p>
        Адрес получателя: {order.arrivalLocation}
      </p>
      <p>
        Вес груза: {order.weight} кг
      </p>
      <p>
        Дата забора груза: {order.pickupDate}
      </p>
    </div>
  );
}

export default OrderOverview;