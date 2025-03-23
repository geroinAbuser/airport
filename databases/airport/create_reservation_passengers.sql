CREATE TABLE main.ReservationPassengers (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    reservation_id UNIQUEIDENTIFIER NOT NULL,  
    passenger_name VARCHAR(100) NOT NULL,  
    seat_number INT NOT NULL,
	created_by UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_passengers_reservation_id FOREIGN KEY (reservation_id) REFERENCES main.Reservations(id) ON DELETE CASCADE
);
