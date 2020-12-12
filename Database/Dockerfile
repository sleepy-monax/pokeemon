FROM mcr.microsoft.com/mssql/server:latest

WORKDIR /usr/src/database
COPY create-db.sql /usr/src/database
COPY load-data.sql /usr/src/database

ENV PATH="/opt/mssql-tools/bin/:${PATH}"
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=eHd66Cjt7cFRCdgBTsbNgajcwBHYpvc2

CMD /bin/bash ./entry-point.sh
