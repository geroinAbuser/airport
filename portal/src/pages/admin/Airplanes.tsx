import React, { useState, useEffect } from "react";
import { fetchAirplanes, addAirplane, deleteAirplane, updateAirplane} from "../../services/airplaneService";
import { fetchAirports } from "../../services/airportService";
import AirplaneItem from "../../components/Airplane/AirplaneItem";
import EntityList from "../../components/EntityList";
import AirplaneForm from "../../components/Airplane/AirplaneForm";
import AirplaneEditModal from "../../components/Airplane/AirplaneEditModal";
import { Airplane, CreateAirplane} from "../../types/airplaneTypes";
import { AirportName } from "../../types/airportTypes";


const Airplanes = () => {
    const [airplanes, setAirplanes] = useState<Airplane[]>([]);
    const [airports, setAirports] = useState<AirportName[]>([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedAirplane, setSelectedAirplane] = useState<Airplane | null>(null);

    const loadAirplanes = async () => {
        try {
            const data = await fetchAirplanes();
            setAirplanes(data);
        } catch (error) {
            console.error("Failed to fetch airplanes", error);
        }
    };

    const loadAirports = async () => {
        try {
            const data = await fetchAirports();
            setAirports(data);
        } catch (error) {
            console.error("Failed to fetch airplanes", error);
        }
    };

    useEffect(() => {
        loadAirplanes();
        loadAirports();
    }, []);

    const handleAddAirplane = async (airplane: CreateAirplane) => {
        try {
            await addAirplane(airplane);
            loadAirplanes();
        } catch (error) {
            console.error("Failed to add airplane", error);
        }
    };

    const handleEditAirplane = (airplane: Airplane) => {
        setSelectedAirplane(airplane);
        setIsModalOpen(true);
    };

    const handleUpdateAirplane = async (updatedAirplane: Airplane) => {
        try {
            await updateAirplane(updatedAirplane.id, updatedAirplane);
            loadAirplanes();
            setIsModalOpen(false);
        } catch (error) {
            console.error("Failed to update airplane", error);
        }
    };


    const handleDeleteAirplane = async (id: string) => {
        try {
            await deleteAirplane(id);
            loadAirplanes();
        } catch (error) {
            console.error("Failed to delete airplane", error);
        }
    };

    return (
        <div className="container">
            <h1 className="title">Manage Airplanes</h1>

            <AirplaneForm airports={airports} onAdd={handleAddAirplane} />

            <h2 className="subtitle">Airplane List</h2>
            <EntityList
                items={airplanes}
                renderItem={(airplane) => (
                    <AirplaneItem
                        key={airplane.id}
                        airplane={airplane}
                        onDelete={handleDeleteAirplane}
                        onEdit={handleEditAirplane}
                    />
                )}
            />

            {isModalOpen && selectedAirplane && (
                <AirplaneEditModal
                    airplane={selectedAirplane}
                    airports={airports}
                    onClose={() => setIsModalOpen(false)}
                    onSave={handleUpdateAirplane}
                />
            )}
        </div>
    );
};

export default Airplanes;
