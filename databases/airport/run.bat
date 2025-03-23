@echo off
echo run

set SERVER=DESKTOP-S9AMOT7\SQLEXPRESS
set DATABASE=Airport

set SCRIPTS_DIR=%~dp0

echo creating database
sqlcmd -S %SERVER% -E -i "%SCRIPTS_DIR%\create_database.sql"

echo creating scheme
sqlcmd -S %SERVER% -E -d %DATABASE% -i "%SCRIPTS_DIR%\create_schema.sql"

echo creating tables

sqlcmd -S %SERVER% -E -d %DATABASE% -i "%SCRIPTS_DIR%\create_airports.sql"
sqlcmd -S %SERVER% -E -d %DATABASE% -i "%SCRIPTS_DIR%\create_airplanes.sql"
sqlcmd -S %SERVER% -E -d %DATABASE% -i "%SCRIPTS_DIR%\create_flights.sql"
sqlcmd -S %SERVER% -E -d %DATABASE% -i "%SCRIPTS_DIR%\create_reservations.sql"
sqlcmd -S %SERVER% -E -d %DATABASE% -i "%SCRIPTS_DIR%\create_reservation_passengers.sql"

echo success
pause
