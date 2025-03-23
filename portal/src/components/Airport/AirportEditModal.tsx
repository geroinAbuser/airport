import React, { useState } from "react";
import { Airport } from "../../types/airportTypes";

interface AirportEditModalProps {
    airport: Airport;
    onClose: () => void;
    onSave: (updatedAirport: Airport) => void;
}

const AirportEditModal = ({ airport, onClose, onSave }: AirportEditModalProps) => {
    const [name, setName] = useState(airport.name);
    const [code, setCode] = useState(airport.code);
    const [city, setCity] = useState(airport.city);
    const [country, setCountry] = useState(airport.country);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onSave({ ...airport, name, code, city, country });
    };

    return (
        <div className="modal is-active">
            <div className="modal-background" onClick={onClose}></div>
            <div className="modal-card">
                <header className="modal-card-head">
                    <p className="modal-card-title">Edit Airport</p>
                    <button className="delete" aria-label="close" onClick={onClose}></button>
                </header>
                <section className="modal-card-body">
                    <form onSubmit={handleSubmit}>
                        <div className="field">
                            <label className="label">Name</label>
                            <input className="input" type="text" value={name} onChange={(e) => setName(e.target.value)} required />
                        </div>
                        <div className="field">
                            <label className="label">Code</label>
                            <input className="input" type="text" value={code} onChange={(e) => setCode(e.target.value)} required />
                        </div>
                        <div className="field">
                            <label className="label">City</label>
                            <input className="input" type="text" value={city} onChange={(e) => setCity(e.target.value)} required />
                        </div>
                        <div className="field">
                            <label className="label">Country</label>
                            <input className="input" type="text" value={country} onChange={(e) => setCountry(e.target.value)} required />
                        </div>
                        <button className="button is-success" type="submit">Save</button>
                        <button className="button" onClick={onClose} type="button">Cancel</button>
                    </form>
                </section>
            </div>
        </div>
    );
};

export default AirportEditModal;
