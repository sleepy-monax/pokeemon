FROM mcr.microsoft.com/mssql/server:latest

WORKDIR /usr/src/database

COPY create-db.sql /usr/src/database
COPY load-data.sql /usr/src/database
COPY populate.sh /usr/src/database

ENV PATH="/opt/mssql-tools/bin/:${PATH}"
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=eHd66Cjt7cFRCdgBTsbNgajcwBHYpvc2

RUN /bin/bash -c "/opt/mssql/bin/sqlservr & ./populate.sh"
