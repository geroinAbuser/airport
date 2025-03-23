import React, { useState, useEffect } from "react";
import { fetchFlights } from "../services/flightService";
import ReservationModal from "./Reservation/ReservationModal";
import FlightItem from "./Flight/FlightItem";
import EntityList from "./EntityList";
import { Flight } from "../types/flightTypes";

const Home = () => {
    const [flights, setFlights] = useState<Flight[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const [selectedFlight, setSelectedFlight] = useState<Flight | null>(null);
    const [showModal, setShowModal] = useState<boolean>(false);

    useEffect(() => {
        const loadFlights = async () => {
            try {
                const data = await fetchFlights();
                setFlights(data);
            } catch (err) {
                setError((err as Error).message);
            } finally {
                setLoading(false);
            }
        };

        loadFlights();
    }, []);

    const handleReserveClick = (flightId: string) => {
        const flight = flights.find(f => f.id === flightId);
        if (flight) {
            setSelectedFlight(flight);
            setShowModal(true);
        }
    };

    return (
        <div className="container">
            <h1 className="title">Welcome to the Flights</h1>

            {loading && <p>Loading flights...</p>}
            {error && <p className="has-text-danger">{error}</p>}

            <EntityList
                items={flights}
                renderItem={(flight) => <FlightItem key={flight.id} flight={flight} actionButton={
                    <button className="button is-primary" onClick={() => handleReserveClick(flight.id)}>
                        Reserve
                    </button>
                } />}
            />

            {showModal && selectedFlight && (
                <ReservationModal flight={selectedFlight} closeModal={() => setShowModal(false)} />
            )}
        </div>
    );
};

export default Home;
