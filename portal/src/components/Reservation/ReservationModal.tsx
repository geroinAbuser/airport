import { useState } from "react";
import { reserveFlight } from "../../services/reservationService";
import { useNavigate } from "react-router-dom";

interface ReservationModalProps {
    flight: { id: string; flightNumber: string };
    closeModal: () => void;
}

interface Passenger {
    passengerName: string;
    seatNumber: number;
}

const ReservationModal = ({ flight, closeModal }: ReservationModalProps) => {
    const [passengers, setPassengers] = useState<Passenger[]>([{ passengerName: "", seatNumber: 0 }]);
    const navigate = useNavigate();
    const handlePassengerChange = (
        index: number,
        field: "passengerName" | "seatNumber",
        value: string
    ) => {
        const updatedPassengers = [...passengers];
        if (field === "seatNumber") {
            updatedPassengers[index][field] = Number(value);
        } else {
            updatedPassengers[index][field] = value;
        }
        setPassengers(updatedPassengers);
    };

    const handleAddPassenger = () => {
        setPassengers([...passengers, { passengerName: "", seatNumber: 0 }]);
    };

    const handleReserve = async () => {
        try {
            const response = await reserveFlight(flight.id, passengers);
            console.log(response);
            alert("Flight reserved successfully!");
            closeModal();
            navigate("/my-reservations");
        } catch (err) {
            alert("Error reserving flight");
        }
    };

    return (
        <div className="modal is-active">
            <div className="modal-background" onClick={closeModal}></div>
            <div className="modal-content">
                <div className="box">
                    <h2 className="title">Reserve Flight {flight.flightNumber}</h2>
                    {passengers.map((passenger, index) => (
                        <div key={index} className="field">
                            <label className="label">Passenger Name</label>
                            <div className="control">
                                <input
                                    type="text"
                                    className="input"
                                    value={passenger.passengerName}
                                    onChange={(e) =>
                                        handlePassengerChange(index, "passengerName", e.target.value)
                                    }
                                    required
                                />
                            </div>
                            <label className="label">Seat Number</label>
                            <div className="control">
                                <input
                                    type="number"
                                    className="input"
                                    value={passenger.seatNumber}
                                    onChange={(e) =>
                                        handlePassengerChange(index, "seatNumber", e.target.value)
                                    }
                                    required
                                />
                            </div>
                        </div>
                    ))}
                    <div className="buttons">
                        <button className="button is-link" onClick={handleAddPassenger}>
                            Add Another Passenger
                        </button>
                        <button className="button is-primary" onClick={handleReserve}>
                            Reserve
                        </button>
                        <button className="button is-danger" onClick={closeModal}>
                            Close
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ReservationModal;
