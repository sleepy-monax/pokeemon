#!/bin/bash

WAIT_TIME=30s

echo "Importing data will start in $WAIT_TIME..."
sleep $WAIT_TIME
echo "Staring data importation..."

sqlcmd -U SA -P $SA_PASSWORD -i create-db.sql
sqlcmd -U SA -P $SA_PASSWORD -i load-data.sql
