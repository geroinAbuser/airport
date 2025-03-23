import {Airport, CreateAirport} from "../types/airportTypes";
import {request} from "./apiClient";

export const fetchAirports = () => request("airport");
export const addAirport = (data: CreateAirport) => request("airport", "POST", data);
export const updateAirport = (id: string, data: Airport) => request(`airport/${id}`, "PUT", data);
export const deleteAirport = (id: string) => request(`airport/${id}`, "DELETE");