import React, { useState } from "react";
import {CreateAirport} from "../../types/airportTypes";

interface AirportFormProps {
    onAdd: (airport: CreateAirport) => void;
}

const AirportForm = ({ onAdd }: AirportFormProps) => {
    const [formData, setFormData] = useState<CreateAirport>({
        name: "",
        code: "",
        city: "",
        country: "",
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onAdd(formData);
        setFormData({ name: "", code: "", city: "", country: "" }); // Очистка формы после добавления
    };

    return (
        <form onSubmit={handleSubmit} className="box">
            {["name", "code", "city", "country"].map((field) => (
                <div className="field" key={field}>
                    <label className="label">{field.charAt(0).toUpperCase() + field.slice(1)}:</label>
                    <div className="control">
                        <input
                            className="input"
                            type="text"
                            name={field}
                            value={formData[field as keyof CreateAirport]}
                            onChange={handleChange}
                            required
                        />
                    </div>
                </div>
            ))}

            <div className="field">
                <div className="control">
                    <button className="button is-primary" type="submit">
                        Add Airport
                    </button>
                </div>
            </div>
        </form>
    );
};

export default AirportForm;
