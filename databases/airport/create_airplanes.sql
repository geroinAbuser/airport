CREATE TABLE main.Airplanes (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    model VARCHAR(100) NOT NULL,
    capacity INT NOT NULL, 
    airport_id UNIQUEIDENTIFIER NULL,  
    CONSTRAINT FK_airplanes_airport_id FOREIGN KEY (airport_id) REFERENCES main.Airports(id)
    ON DELETE SET NULL
);
