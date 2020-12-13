#!/bin/sh

WAIT_TIME=30s

. ./database.env

echo "Importing data will start in $WAIT_TIME..."
sleep "$WAIT_TIME"
echo "Staring data importation..."

echo "USERNAME: $PK_DATABASE_ADMIN_USERNAME; PASSWORD: $PK_DATABASE_ADMIN_PASSWORD; "

sqlcmd \
    -U "$PK_DATABASE_ADMIN_USERNAME" \
    -P "$PK_DATABASE_ADMIN_PASSWORD" \
    -i create-db.sql

sqlcmd \
    -U "$PK_DATABASE_ADMIN_USERNAME" \
    -P "$PK_DATABASE_ADMIN_PASSWORD" \
    -i load-data.sql
