FROM mcr.microsoft.com/mssql/server:latest

WORKDIR /usr/src/Database

COPY Database/create-db.sql /usr/src/Database
COPY Database/load-data.sql /usr/src/Database
COPY Configs/Docker/database-deploy.sh /usr/src/Database

ENV PATH="/opt/mssql-tools/bin/:${PATH}"
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=eHd66Cjt7cFRCdgBTsbNgajcwBHYpvc2

RUN /bin/bash -c "/opt/mssql/bin/sqlservr & ./database-deploy.sh"
