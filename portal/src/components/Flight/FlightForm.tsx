import React, { useState } from "react";
import { CreateFlight } from "../../types/flightTypes";

interface FlightFormProps {
    airports: { id: string; name: string }[];
    airplanes: { id: string; model: string }[];
    onAdd: (flight: CreateFlight) => void;
}

const FlightForm = ({ airports, airplanes, onAdd }: FlightFormProps) => {
    const [flightNumber, setFlightNumber] = useState("");
    const [departureAirportId, setDepartureAirportId] = useState("");
    const [arrivalAirportId, setArrivalAirportId] = useState("");
    const [departureTime, setDepartureTime] = useState("");
    const [arrivalTime, setArrivalTime] = useState("");
    const [airplaneId, setAirplaneId] = useState("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onAdd({
            flightNumber,
            departureAirportId,
            arrivalAirportId,
            departureTime,
            arrivalTime,
            airplaneId
        });
        setFlightNumber("");
        setDepartureAirportId("");
        setArrivalAirportId("");
        setDepartureTime("");
        setArrivalTime("");
        setAirplaneId("");
    };

    return (
        <form onSubmit={handleSubmit} className="box">
            <div className="field">
                <label className="label">Flight Number:</label>
                <div className="control">
                    <input className="input" type="text" value={flightNumber}
                           onChange={(e) => setFlightNumber(e.target.value)} required/>
                </div>
            </div>

            <div className="field">
                <label className="label">Departure airport:</label>
                <div className="control">
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
                </div>
            </div>

            <div className="field">
                <label className="label">Arrival airport:</label>
                <div className="control">
                    <div className="select is-fullwidth">
                        <select value={arrivalAirportId} onChange={(e) => setArrivalAirportId(e.target.value)} required>
                            <option value="">Select an airport</option>
                            {airports.map((airport) => (
                                <option key={airport.id} value={airport.id}>
                                    {airport.name}
                                </option>
                            ))}
                        </select>
                    </div>
                </div>
            </div>

            <div className="field">
                <label className="label">Departure Time:</label>
                <div className="control">
                    <input className="input" type="datetime-local" value={departureTime}
                           onChange={(e) => setDepartureTime(e.target.value)} required/>
                </div>
            </div>

            <div className="field">
                <label className="label">Arrival Time:</label>
                <div className="control">
                    <input className="input" type="datetime-local" value={arrivalTime}
                           onChange={(e) => setArrivalTime(e.target.value)} required/>
                </div>
            </div>

            <div className="field">
                <label className="label">Airplane:</label>
                <div className="control">
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
                </div>
            </div>

            <div className="field">
                <div className="control">
                    <button className="button is-primary" type="submit">Add Flight</button>
                </div>
            </div>
        </form>
    );

};

export default FlightForm;
