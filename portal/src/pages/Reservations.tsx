import { useEffect, useState } from "react";
import EntityList from "../components/EntityList";
import ReservationItem from "../components/Reservation/ReservationItem";
import { fetchReservations } from "../services/reservationService";

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

const Reservations = () => {
    const [reservations, setReservations] = useState<Reservation[]>([]);

    useEffect(() => {
        loadReservations();
    }, []);

    const loadReservations = async () => {
        try {
            const data = await fetchReservations();
            setReservations(data);
        } catch (error) {
            console.error("Failed to fetch reservations", error);
        }
    };

    const handleCancel = (id: string) => {
        setReservations(reservations.filter((r) => r.id !== id));
    };

    return (
        <div className="container">
            <h1 className="title">Your Reservations</h1>
            <EntityList
                items={reservations}
                renderItem={(reservation) => (
                    <ReservationItem key={reservation.id} reservation={reservation} onCancel={handleCancel} />
                )}
            />
        </div>
    );
};

export default Reservations;
