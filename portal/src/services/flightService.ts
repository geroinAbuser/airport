import {CreateFlight, Flight} from "../types/flightTypes";
import {request} from "./apiClient";

export const fetchFlights = () => request("flight");
export const addFlight = (flight: CreateFlight) => request("flight", "POST", flight);
export const updateFlight = (id: string, updatedData: Flight) => request(`flight/${id}`, "PUT", updatedData);
export const deleteFlight = (id: string) => request(`flight/${id}`, "DELETE");
