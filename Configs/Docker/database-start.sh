#!/bin/sh

. ./database.env

export SA_PASSWORD="$PK_DATABASE_ADMIN_PASSWORD"

env

/opt/mssql/bin/sqlservr
