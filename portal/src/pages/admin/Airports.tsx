import React, { useState, useEffect } from "react";
import { fetchAirports, addAirport, deleteAirport, updateAirport } from "../../services/airportService";
import AirportItem from "../../components/Airport/AirportItem";
import EntityList from "../../components/EntityList";
import AirportForm from "../../components/Airport/AirportForm";
import AirportEditModal from "../../components/Airport/AirportEditModal";
import {Airport, CreateAirport} from "../../types/airportTypes";

const Airports = () => {
    const [airports, setAirports] = useState<Airport[]>([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedAirport, setSelectedAirport] = useState<Airport | null>(null);

    const loadAirports = async () => {
        try {
            const data = await fetchAirports();
            setAirports(data);
        } catch (error) {
            console.error("Failed to fetch airports", error);
        }
    };

    useEffect(() => {
        loadAirports();
    }, []);

    const handleAddAirport = async (airport: CreateAirport) => {
        try {
            await addAirport(airport);
            loadAirports();
        } catch (error) {
            console.error("Failed to add airport", error);
        }
    };

    const handleEditAirport = (airport: Airport) => {
        setSelectedAirport(airport);
        setIsModalOpen(true);
    };

    const handleUpdateAirport = async (updatedAirport: Airport) => {
        try {
            await updateAirport(updatedAirport.id, updatedAirport);
            loadAirports();
            setIsModalOpen(false);
        } catch (error) {
            console.error("Failed to update airport", error);
        }
    };

    const handleDeleteAirport = async (id: string) => {
        try {
            await deleteAirport(id);
            loadAirports();
        } catch (error) {
            console.error("Failed to delete airport", error);
        }
    };

    return (
        <div className="container">
            <h1 className="title">Manage Airports</h1>

            <AirportForm onAdd={handleAddAirport} />

            <h2 className="subtitle">Airport List</h2>
            <EntityList
                items={airports}
                renderItem={(airport) => (
                    <AirportItem
                        key={airport.id}
                        airport={airport}
                        onDelete={handleDeleteAirport}
                        onEdit={handleEditAirport}
                    />
                )}
            />

            {isModalOpen && selectedAirport && (
                <AirportEditModal
                    airport={selectedAirport}
                    onClose={() => setIsModalOpen(false)}
                    onSave={handleUpdateAirport}
                />
            )}
        </div>
    );
};

export default Airports;
