import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import NavBar from "./components/NavBar";
import HomePage from "./pages/HomePage";
import Reservations from "./pages/Reservations";
import Airplanes from "./pages/admin/Airplanes";
import Airports from "./pages/admin/Airports";
import Flights from "./pages/admin/Flights";
import ProtectedRoute from "./components/ProtectedRoute";

const App = () => {
    return (
        <AuthProvider>
            <Router>
                <NavBar />
                <Routes>
                    <Route element={<ProtectedRoute requiredRole="Admin" />}>
                        <Route path="/admin/airplanes" element={<Airplanes />} />
                        <Route path="/admin/airports" element={<Airports />} />
                        <Route path="/admin/flights" element={<Flights />} />
                    </Route>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/reservations" element={<Reservations />} />
                </Routes>
            </Router>
        </AuthProvider>
    );
};

export default App;
