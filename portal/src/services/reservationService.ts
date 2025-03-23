import {request} from "./apiClient";

export const fetchReservations = () => request("reservation");
export const reserveFlight = (flightId: string, passengers: any[]) =>
    request("reservation", "POST", { flightId, passengers });
export const cancelReservation = (reservationId: string) => request(`reservation/${reservationId}`, "DELETE");