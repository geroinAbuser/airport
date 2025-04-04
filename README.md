# Flight Booking System with Admin Panel

## Project Overview
A full-stack flight booking system that allows users to search for flights and make reservations. The admin panel provides full CRUD functionality for managing flights, airports, and airplanes.

---

## Project Structure
```plaintext
airport/
├── api-airport/          # C# API for managing airports, airplanes, flights and reservations
├── sign-service/         # Golang authorization service (PostgreSQL)
├── databases/            # MSSQL and PostgreSQL database scripts
├── portal/               # React frontend
├── docker-compose.yml    # Docker environment setup for running all services in containers
└── README.md             # Project documentation
