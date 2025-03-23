CREATE TABLE main.Flights (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    flight_number VARCHAR(20) NOT NULL,
    departure_airport_id UNIQUEIDENTIFIER, 
    arrival_airport_id UNIQUEIDENTIFIER NULL,
    departure_time DATETIME, 
    arrival_time DATETIME,
    airplane_id UNIQUEIDENTIFIER, 
    status VARCHAR(20),
	available_seats INT NOT NULL,
    CONSTRAINT FK_flights_departure_airport FOREIGN KEY (departure_airport_id) REFERENCES main.Airports(id) ON DELETE CASCADE,
    CONSTRAINT FK_flights_arrival_airport FOREIGN KEY (arrival_airport_id) REFERENCES main.Airports(id) ON DELETE NO ACTION,
    CONSTRAINT FK_flights_airplane FOREIGN KEY (airplane_id) REFERENCES main.Airplanes(id) ON DELETE SET NULL
);
