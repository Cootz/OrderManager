import { useState } from "react";
import { Order } from "../data/Order";
import "./NewOrder.css"
import { useNavigate } from "react-router-dom";
import { postOrder } from "../api/OrdersAPI";

function NewOrder() {
  const [orderData, setOrderData] = useState(new Order());
  const [errors, setErrors] = useState({});
  const navigate = useNavigate();

  const validate = (order) => {
    const errors = {};

    if (!order.departureCity) errors.departureCity = 'Departure City is required';
    if (!order.departureLocation) errors.departureLocation = 'Departure Location is required';
    if (!order.arrivalCity) errors.arrivalCity = 'Arrival City is required';
    if (!order.arrivalLocation) errors.arrivalLocation = 'Arrival Location is required';
    if (order.weight <= 0) errors.weight = 'Weight must be more than 0';
    if (!order.pickupDate) errors.pickupDate = 'Pickup Date is required';
    
    return errors;
  };

  const handleChange = (event) => {
    const { name, value } = event.target;
    setOrderData({ ...orderData, [name]: value });
  }
  
  const handleSubmit = async (event) => {
    
    event.preventDefault();

    const validationErrors = validate(orderData);

    if(Object.keys(validationErrors).length > 0)
    {
      setErrors(validationErrors);
    }
    else
    {
      setErrors({});

      const isOk = await postOrder(orderData);

      if (isOk)
      {
        navigate("/");
      }
    }
  }

  return (
    <div className="new-order-content">
        <form onSubmit={handleSubmit}>
          <h2>Новый заказ</h2>

          <div className="form-label">
            Введите город отправителя:
            <input type="text" name="departureCity" value={orderData.departureCity} onChange={handleChange} className={errors.departureCity ? 'errorInput' : ''}/>
          </div>
          <br />
          <div className="form-label">
            Введите адрес отправителя:
            <input type="text" name="departureLocation" value={orderData.departureLocation} onChange={handleChange} className={errors.departureLocation ? 'errorInput' : ''}/>
          </div>
          <br />
          <div className="form-label">
            Введите город получателя:
            <input type="text" name="arrivalCity" value={orderData.arrivalCity} onChange={handleChange} className={errors.arrivalCity ? 'errorInput' : ''}/>
          </div>
          <br />
          <div className="form-label">
            Введите адрес получателя:
            <input type="text" name="arrivalLocation" value={orderData.arrivalLocation} onChange={handleChange} className={errors.arrivalLocation ? 'errorInput' : ''}/>
          </div>
          <br />
          <div className="form-label">
            Введите вес груза (кг):
            <input type="number" step="0.01" name="weight" value={orderData.weight} onChange={handleChange} className={errors.weight ? 'errorInput' : ''}/>
          </div>
          <br />
          <div className="form-label">
            Введите дату забора груза:
            <input type="date" name="pickupDate" value={orderData.pickupDate} onChange={handleChange} className={errors.pickupDate ? 'errorInput' : ''}/>
          </div>
          <br />
          <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default NewOrder;