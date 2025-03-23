CREATE TABLE main.Reservations (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    flight_id UNIQUEIDENTIFIER, 
    user_id UNIQUEIDENTIFIER NULL, 
    status VARCHAR(20), 
    reserved_at DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_reservations_flight_id FOREIGN KEY (flight_id) REFERENCES main.Flights(id) ON DELETE CASCADE
);
