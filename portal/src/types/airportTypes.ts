export interface AirportBase {
    name: string;
    code: string;
    city: string;
    country: string;
}

export interface Airport extends AirportBase {
    id: string;
}

export interface CreateAirport extends AirportBase {}

export interface AirportName {
    id: string;
    name: string;
}