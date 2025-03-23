FROM mcr.microsoft.com/mssql/server:latest

# Выполнение команд с правами root
USER root

# Устанавливаем необходимые зависимости
RUN apt-get update && \
    apt-get install -y gnupg curl lsb-release && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev

# Перезапускаем SQL Server (это можно оставить для запуска SQL Server)
CMD /opt/mssql/bin/sqlservr
