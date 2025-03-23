import { Airplane } from "../../types/airplaneTypes";

interface AirplaneItemProps {
    airplane: Airplane;
    onDelete: (id: string) => void;
    onEdit: (airplane: Airplane) => void;
}

const AirplaneItem = ({ airplane, onDelete, onEdit }: AirplaneItemProps) => {
    return (
        <div className="box">
            <p><strong>Model:</strong> {airplane.model}</p>
            <p><strong>Capacity:</strong> {airplane.capacity}</p>
            <p><strong>Airport:</strong> {airplane.airportName}</p>

            <button className="button is-warning" onClick={() => onEdit(airplane)}>Edit</button>
            <button className="button is-danger" onClick={() => onDelete(airplane.id)}>Delete</button>
        </div>
    );
};

export default AirplaneItem;
