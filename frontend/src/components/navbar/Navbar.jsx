import './navbar.css';

function Navbar() {
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
