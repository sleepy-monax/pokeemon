FROM mcr.microsoft.com/mssql/server:latest

WORKDIR /app/Database

COPY Database/create-db.sql /app/Database
COPY Database/load-data.sql /app/Database
COPY Configs/Docker/database-deploy.sh /app/Database
COPY Configs/Docker/database-start.sh /app/Database
COPY Configs/Docker/database.env /app/Database

ENV PATH="/opt/mssql-tools/bin/:${PATH}"
ENV ACCEPT_EULA=Y

RUN /bin/sh ./database-start.sh & /bin/sh ./database-deploy.sh
