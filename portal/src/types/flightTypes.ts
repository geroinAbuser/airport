export interface FlightBase {
    flightNumber: string;
    departureAirportName: string;
    departureAirportId: string;
    arrivalAirportName: string;
    arrivalAirportId: string;
    departureTime: string;
    arrivalTime: string;
    airplaneModel: string;
    airplaneId: string;
    status: string;
    availableSeats: number;
}

export interface Flight extends FlightBase {
    id: string;
}

export interface CreateFlight {
    flightNumber: string;
    departureAirportId: string;
    arrivalAirportId: string;
    departureTime: string;
    arrivalTime: string;
    airplaneId: string;
}
