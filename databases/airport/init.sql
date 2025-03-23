INSERT INTO main.Airports (name, code, city, country)
VALUES 
('Sheremetyevo International Airport', 'SVO', 'Moscow', 'Russia'),
('John F. Kennedy International Airport', 'JFK', 'New York', 'USA'),
('Heathrow Airport', 'LHR', 'London', 'UK'),
('Charles de Gaulle Airport', 'CDG', 'Paris', 'France'),
('Haneda Airport', 'HND', 'Tokyo', 'Japan');


DECLARE @Airport1 UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM main.Airports WHERE code = 'SVO');
DECLARE @Airport2 UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM main.Airports WHERE code = 'JFK');
DECLARE @Airport3 UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM main.Airports WHERE code = 'LHR');
DECLARE @Airport4 UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM main.Airports WHERE code = 'CDG');
DECLARE @Airport5 UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM main.Airports WHERE code = 'HND');


INSERT INTO main.Airplanes (model, capacity, airport_id)
VALUES
('Boeing 737', 180, @Airport1),
('Airbus A320', 160, @Airport2),
('Boeing 777', 320, @Airport3),
('Airbus A380', 555, @Airport4),
('Embraer E190', 100, @Airport5);


DECLARE @Airplane1 UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM main.Airplanes WHERE model = 'Boeing 737');
DECLARE @Airplane2 UNIQUEIDENTIFIER = (SELECT TOP 1 id FROM main.Airplanes WHERE model = 'Airbus A320');

INSERT INTO main.Flights (flight_number, departure_airport_id, arrival_airport_id, departure_time, arrival_time, airplane_id, status, available_seats)
SELECT 
    'SU100', 
    @Airport1, 
    @Airport2, 
    GETDATE() + 1, 
    GETDATE() + 1.5, 
    @Airplane1, 
    'Scheduled', 
    capacity
FROM main.Airplanes
WHERE id = @Airplane1;

INSERT INTO main.Flights (flight_number, departure_airport_id, arrival_airport_id, departure_time, arrival_time, airplane_id, status, available_seats)
SELECT 
    'DL200', 
    @Airport3, 
    @Airport4, 
    GETDATE() + 2, 
    GETDATE() + 2.5, 
    @Airplane2, 
    'Scheduled', 
    capacity
FROM main.Airplanes
WHERE id = @Airplane2;

