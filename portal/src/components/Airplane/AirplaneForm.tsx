import React, { useState } from "react";
import {CreateAirplane} from "../../types/airplaneTypes";

interface AirplaneFormProps {
    airports: { id: string; name: string }[];
    onAdd: (airplane: CreateAirplane) => void;
}

const AirplaneForm = ({ airports, onAdd }: AirplaneFormProps) => {
    const [formData, setFormData] = useState<CreateAirplane>({
        model: "",
        capacity: 0,
        airportId: "",
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setFormData((prev) => ({
            ...prev,
            [name]: name === "capacity" ? parseInt(value, 10) || 0 : value,
        }));
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onAdd(formData);
        setFormData({ model: "", capacity: 0, airportId: "" }); // Очистка формы
    };

    return (
        <form onSubmit={handleSubmit} className="box">
            {[
                { label: "Model", name: "model", type: "text" },
                { label: "Capacity", name: "capacity", type: "number" },
            ].map(({ label, name, type }) => (
                <div className="field" key={name}>
                    <label className="label">{label}:</label>
                    <div className="control">
                        <input
                            className="input"
                            type={type}
                            name={name}
                            value={formData[name as keyof CreateAirplane].toString()}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
            ))}

            <div className="field">
                <label className="label">Airport:</label>
                <div className="control">
                    <div className="select is-fullwidth">
                        <select name="airportId" value={formData.airportId} onChange={handleChange} required>
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
                <div className="control">
                    <button className="button is-primary" type="submit">
                        Add Airplane
                    </button>
                </div>
            </div>
        </form>
    );
};

export default AirplaneForm;
