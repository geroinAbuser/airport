import {Airplane, CreateAirplane} from "../types/airplaneTypes";
import {request} from "./apiClient";

export const fetchAirplanes = () => request("airplane");
export const addAirplane = (data: CreateAirplane) => request("airplane", "POST", data);
export const updateAirplane = (id: string, data: Airplane) => request(`airplane/${id}`, "PUT", data);
export const deleteAirplane = (id: string) => request(`airplane/${id}`, "DELETE");
