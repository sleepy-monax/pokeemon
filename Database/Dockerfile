FROM mcr.microsoft.com/mssql/server:2019-latest

WORKDIR /usr/src/app/db
COPY ../Database /usr/src/app/db

ENV ACCEPT_EULA=Y
ENV sa_password=eHd66Cjt7cFRCdgBTsbNgajcwBHYpvc2

RUN sqlcmd -i create-db.sql
RUN sqlcmd -i load-data.sql
