import './navbar.css';
import { useState } from 'react';

function Navbar() {
    const [open, setOpen] = useState(false);

    return (
        <nav>
            <div className="left">
                <a href="/" className="orders">Orders</a>
            </div>

            <div className="right">
                <a href="/neworder">New order</a>
            </div>
        </nav>
    );
}

export default Navbar;
