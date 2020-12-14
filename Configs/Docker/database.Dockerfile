FROM mcr.microsoft.com/mssql/server:latest

WORKDIR /usr/src/Database

COPY Database/create-db.sql /usr/src/Database
COPY Database/load-data.sql /usr/src/Database
COPY Configs/Docker/database-deploy.sh /usr/src/Database
COPY Configs/Docker/database-start.sh /usr/src/Database
COPY Configs/Docker/database.env /usr/src/Database

ENV PATH="/opt/mssql-tools/bin/:${PATH}"
ENV ACCEPT_EULA=Y

RUN /bin/sh ./database-start.sh & /bin/sh ./database-deploy.sh
