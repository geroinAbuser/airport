import { useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import Modal from "./Modal";
import Login from "./Login";
import Register from "./Register";
import "bulma/css/bulma.min.css";

const Navbar = () => {
    const { user, logout } = useAuth();
    const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
    const [isRegisterModalOpen, setIsRegisterModalOpen] = useState(false);

    return (
        <nav className="navbar">
            <div className="navbar-start">
                <Link to="/" className="navbar-item">Home</Link>

                {/* Показываем "Admin Panel" только для админов */}
                {user?.role === "Admin" && (
                    <div className="navbar-item has-dropdown is-hoverable">
                        <div className="navbar-link">Admin Panel</div>
                        <div className="navbar-dropdown">
                            <Link to="/admin/airplanes" className="navbar-item">Airplanes</Link>
                            <Link to="/admin/airports" className="navbar-item">Airports</Link>
                            <Link to="/admin/flights" className="navbar-item">Flights</Link>
                        </div>
                    </div>
                )}
            </div>

            <div className="navbar-end">
                {user ? (
                    <>
                        <div className="navbar-item">Hello, {user.username}</div>
                        <div className="navbar-item has-dropdown is-hoverable">
                            <div className="navbar-link">My Profile</div>
                            <div className="navbar-dropdown">
                                <Link to="/reservations" className="navbar-item">My Reservations</Link>
                                <button className="navbar-item" onClick={logout}>Logout</button>
                            </div>
                        </div>
                    </>
                ) : (
                    <>
                        <button className="navbar-item" onClick={() => setIsLoginModalOpen(true)}>Login</button>
                        <button className="navbar-item" onClick={() => setIsRegisterModalOpen(true)}>Register</button>
                    </>
                )}
            </div>

            <Modal isOpen={isLoginModalOpen} closeModal={() => setIsLoginModalOpen(false)}>
                <Login closeModal={() => setIsLoginModalOpen(false)} />
            </Modal>

            <Modal isOpen={isRegisterModalOpen} closeModal={() => setIsRegisterModalOpen(false)}>
                <Register closeModal={() => setIsRegisterModalOpen(false)} />
            </Modal>
        </nav>
    );
};

export default Navbar;
