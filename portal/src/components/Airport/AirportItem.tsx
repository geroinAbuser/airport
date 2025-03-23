import { Airport } from "../../types/airportTypes";

interface AirportItemProps {
    airport: Airport;
    onDelete: (id: string) => void;
    onEdit: (airport: Airport) => void;
}

const AirportItem = ({ airport, onDelete, onEdit }: AirportItemProps) => {
    return (
        <div className="box">
            <p><strong>Name:</strong> {airport.name}</p>
            <p><strong>Code:</strong> {airport.code}</p>
            <p><strong>City:</strong> {airport.city}</p>
            <p><strong>Country:</strong> {airport.country}</p>

            <button className="button is-warning" onClick={() => onEdit(airport)}>Edit</button>
            <button className="button is-danger" onClick={() => onDelete(airport.id)}>Delete</button>
        </div>
    );
};

export default AirportItem;
