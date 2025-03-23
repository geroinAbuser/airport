import { Flight } from "../../types/flightTypes";

interface FlightItemProps {
    flight: Flight;
    actionButton: React.ReactNode;
}

const FlightItem = ({ flight, actionButton }: FlightItemProps) => {
    return (
        <div className="box">
            <p><strong>Flight:</strong> {flight.flightNumber}</p>
            <p><strong>Route:</strong> {flight.departureAirportName} → {flight.arrivalAirportName}</p>
            <p><strong>Departure:</strong> {new Date(flight.departureTime).toLocaleString()}</p>
            <p><strong>Arrival:</strong> {new Date(flight.arrivalTime).toLocaleString()}</p>
            <p><strong>Airplane:</strong> {flight.airplaneModel}</p>
            <p><strong>Status:</strong> {flight.status}</p>
            <p><strong>Available seats:</strong> {flight.availableSeats}</p>
            {actionButton}
        </div>
    );
};

export default FlightItem;
