export interface AirplaneBase {
    model: string;
    capacity: number;
    airportName: string;
    airportId: string;
}

export interface Airplane extends AirplaneBase {
    id: string;
}

export interface CreateAirplane {
    model: string;
    capacity: number;
    airportId: string;
}

export interface AirplaneName {
    id: string;
    model: string;
}