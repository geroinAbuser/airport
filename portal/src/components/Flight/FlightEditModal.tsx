import React, { useState } from "react";
import { Flight} from "../../types/flightTypes";
import { AirportName } from "../../types/airportTypes";
import { AirplaneName } from "../../types/airplaneTypes";

interface FlightEditModalProps {
    flight: Flight;
    airports: AirportName[];
    airplanes: AirplaneName[];
    onClose: () => void;
    onSave: (Flight: Flight) => void;
}

const FlightEditModal = ({ flight, airports, airplanes, onClose, onSave }: FlightEditModalProps) => {
    const [departureTime, setDepartureTime] = useState(flight.departureTime);
    const [arrivalTime, setArrivalTime] = useState(flight.arrivalTime);
    const [departureAirportId, setDepartureAirportId] = useState(flight.departureAirportId);
    const [arrivalAirportId, setArrivalAirportId] = useState(flight.arrivalAirportId);
    const [airplaneId, setAirplaneId] = useState(flight.airplaneId);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onSave({ ...flight, departureTime, arrivalTime, departureAirportId, arrivalAirportId, airplaneId });
    };

    return (
        <div className="modal is-active">
            <div className="modal-background" onClick={onClose}></div>
            <div className="modal-card">
                <header className="modal-card-head">
                    <p className="modal-card-title">Edit Flight</p>
                    <button className="delete" aria-label="close" onClick={onClose}></button>
                </header>
                <section className="modal-card-body">
                    <form onSubmit={handleSubmit}>
                        <div className="field">
                            <label className="label">Departure Time</label>
                            <input className="input" type="datetime-local" value={departureTime}
                                   onChange={(e) => setDepartureTime(e.target.value)} required/>
                        </div>
                        <div className="field">
                            <label className="label">Arrival Time</label>
                            <input className="input" type="datetime-local" value={arrivalTime}
                                   onChange={(e) => setArrivalTime(e.target.value)} required/>
                        </div>
                        <div className="select is-fullwidth">
                            <select value={departureAirportId} onChange={(e) => setDepartureAirportId(e.target.value)}
                                    required>
                                <option value="">Select an airport</option>
                                {airports.map((airport) => (
                                    <option key={airport.id} value={airport.id}>
                                        {airport.name}
                                    </option>
                                ))}
                            </select>
                        </div>
                        <div className="select is-fullwidth">
                            <select value={arrivalAirportId} onChange={(e) => setArrivalAirportId(e.target.value)}
                                    required>
                                <option value="">Select an airport</option>
                                {airports.map((airport) => (
                                    <option key={airport.id} value={airport.id}>
                                        {airport.name}
                                    </option>
                                ))}
                            </select>
                        </div>
                        <div className="select is-fullwidth">
                            <select value={airplaneId} onChange={(e) => setAirplaneId(e.target.value)} required>
                                <option value="">Select an airplane</option>
                                {airplanes.map((airplane) => (
                                    <option key={airplane.id} value={airplane.id}>
                                        {airplane.model}
                                    </option>
                                ))}
                            </select>
                        </div>
                        <button className="button is-success" type="submit">Save</button>
                        <button className="button" onClick={onClose} type="button">Cancel</button>
                    </form>
                </section>
            </div>
        </div>
    );
};

export default FlightEditModal;
