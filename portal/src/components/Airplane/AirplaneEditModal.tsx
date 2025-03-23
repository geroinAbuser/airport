import React, { useState } from "react";
import { Airplane } from "../../types/airplaneTypes";
import { AirportName } from "../../types/airportTypes";

interface AirplaneEditModalProps {
    airplane: Airplane;
    airports: AirportName[];
    onClose: () => void;
    onSave: (updatedAirplane: Airplane) => void;
}

const AirplaneEditModal = ({ airplane, airports, onClose, onSave }: AirplaneEditModalProps) => {
    const [model, setModel] = useState(airplane.model);
    const [capacity, setCapacity] = useState(airplane.capacity);
    const [airportId, setAirportId] = useState(airplane.airportId);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onSave({ ...airplane, model, capacity, airportId });
    };

    return (
        <div className="modal is-active">
            <div className="modal-background" onClick={onClose}></div>
            <div className="modal-card">
                <header className="modal-card-head">
                    <p className="modal-card-title">Edit Airplane</p>
                    <button className="delete" onClick={onClose}></button>
                </header>
                <section className="modal-card-body">
                    <form onSubmit={handleSubmit}>
                        <div className="field">
                            <label className="label">Model</label>
                            <div className="control">
                                <input className="input" type="text" value={model} onChange={(e) => setModel(e.target.value)} required />
                            </div>
                        </div>
                        <div className="field">
                            <label className="label">Capacity</label>
                            <div className="control">
                                <input className="input" type="number" value={capacity} onChange={(e) => setCapacity(Number(e.target.value))} required />
                            </div>
                        </div>
                        <div className="field">
                            <label className="label">Airport</label>
                            <div className="control">
                                <div className="select">
                                    <select value={airportId} onChange={(e) => setAirportId(e.target.value)} required>
                                        {airports.map((airport) => (
                                            <option key={airport.id} value={airport.id}>{airport.name}</option>
                                        ))}
                                    </select>
                                </div>
                            </div>
                        </div>
                        <button className="button is-primary" type="submit">Save Changes</button>
                    </form>
                </section>
            </div>
        </div>
    );
};

export default AirplaneEditModal;
