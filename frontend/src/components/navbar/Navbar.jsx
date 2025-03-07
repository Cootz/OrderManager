import { Link } from 'react-router-dom';
import './navbar.css';

function Navbar() {
    return (
        <nav>
            <div className="left">
                <Link to="/" className="orders">Orders</Link>
            </div>

            <div className="right">
                <Link to="/neworder">New order</Link>
            </div>
        </nav>
    );
}

export default Navbar;
