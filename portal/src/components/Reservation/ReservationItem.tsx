import { cancelReservation } from "../../services/reservationService";

interface Passenger {
    passengerName: string;
    seatNumber: number;
}

interface Reservation {
    id: string;
    flightNumber: string;
    userId: string;
    status: string;
    reservedAt: string;
    date: string;
    passengers: Passenger[];
}

interface ReservationItemProps {
    reservation: Reservation;
    onCancel: (id: string) => void;
}

const ReservationItem = ({ reservation, onCancel }: ReservationItemProps) => {

    const handleCancel = async () => {
        try {
            await cancelReservation(reservation.id);
            alert("Reservation canceled successfully!");
            onCancel(reservation.id);
        } catch (error) {
            alert("Failed to cancel reservation");
        }
    };

    return (
        <div className="box">
            <p><strong>Reservation ID:</strong> {reservation.id}</p>
            <p><strong>Flight Number:</strong> {reservation.flightNumber}</p>
            <p><strong>User ID:</strong> {reservation.userId}</p>
            <p><strong>Status:</strong> {reservation.status}</p>
            <p><strong>Reserved At:</strong> {new Date(reservation.reservedAt).toLocaleString()}</p>
            {reservation.date && <p><strong>Date:</strong> {reservation.date}</p>}

            <div>
                <strong>Passengers:</strong>
                {reservation.passengers.length > 0 ? (
                    <ul>
                        {reservation.passengers.map((passenger, index) => (
                            <li key={index}>
                                {passenger.passengerName} (Seat {passenger.seatNumber})
                            </li>
                        ))}
                    </ul>
                ) : (
                    <p>No passengers listed.</p>
                )}
            </div>

            <button className="button is-danger" onClick={handleCancel}>
                Cancel Reservation
            </button>
        </div>
    );
};

export default ReservationItem;