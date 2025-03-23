import React, { useEffect, useState } from "react";
import { fetchFlights, addFlight, deleteFlight, updateFlight } from "../../services/flightService";
import { fetchAirports } from "../../services/airportService";
import { fetchAirplanes } from "../../services/airplaneService";
import FlightForm from "../../components/Flight/FlightForm";
import EntityList from "../../components/EntityList";
import FlightItem from "../../components/Flight/FlightItem";
import FlightEditModal from "../../components/Flight/FlightEditModal";
import { Flight, CreateFlight } from "../../types/flightTypes";
import { AirportName } from "../../types/airportTypes";
import { AirplaneName } from "../../types/airplaneTypes";

const Flights = () => {
    const [flights, setFlights] = useState<Flight[]>([]);
    const [airports, setAirports] = useState<AirportName[]>([]);
    const [airplanes, setAirplanes] = useState<AirplaneName[]>([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedFlight, setSelectedFlight] = useState<Flight | null>(null);

    const loadFlights = async () => {
        try {
            const data = await fetchFlights();
            setFlights(data);
        } catch (error) {
            console.error("Failed to fetch flights", error);
        }
    };

    useEffect(() => {
        loadFlights();
        loadAirports();
        loadAirplanes();
    }, []);

    const loadAirports = async () => {
        try {
            const data = await fetchAirports();
            setAirports(data);
        } catch (error) {
            console.error("Failed to fetch airports", error);
        }
    };

    const loadAirplanes = async () => {
        try {
            const data = await fetchAirplanes();
            setAirplanes(data);
        } catch (error) {
            console.error("Failed to fetch airplanes", error);
        }
    };

    const handleAddFlight = async (flight: CreateFlight) => {
        try {
            await addFlight(flight);
            loadFlights();
        } catch (error) {
            console.error("Failed to add flight", error);
        }
    };

    const handleEditFlight = (flight: Flight) => {
        setSelectedFlight(flight);
        setIsModalOpen(true);
    };

    const handleUpdateFlight = async (updatedFlight: Flight) => {
        try {
            await updateFlight(updatedFlight.id, updatedFlight);
            loadFlights();
            setIsModalOpen(false);
        } catch (error) {
            console.error("Failed to update flight", error);
        }
    };

    const handleDeleteFlight = async (id: string) => {
        try {
            await deleteFlight(id);
            loadFlights();
        } catch (error) {
            console.error("Failed to delete flight", error);
        }
    };

    return (
        <div className="container">
            <h1 className="title">Manage Flights</h1>

            <FlightForm airports={airports} airplanes={airplanes} onAdd={handleAddFlight} />

            <h2 className="subtitle">Flight List</h2>
            <EntityList
                items={flights}
                renderItem={(flight) => (
                    <FlightItem
                        key={flight.id}
                        flight={flight}
                        actionButton={
                            <div>
                                <button className="button is-warning" onClick={() => handleEditFlight(flight)}>
                                    Edit
                                </button>
                                <button className="button is-danger" onClick={() => handleDeleteFlight(flight.id)}>
                                    Delete
                                </button>
                            </div>
                        }
                    />
                )}
            />

            {isModalOpen && selectedFlight && (
                <FlightEditModal
                    flight={selectedFlight}
                    airports={airports}
                    airplanes={airplanes}
                    onClose={() => setIsModalOpen(false)}
                    onSave={handleUpdateFlight}
                />
            )}
        </div>
    );
};

export default Flights;
