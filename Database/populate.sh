#!/bin/bash

WAIT_TIME=90s

echo "Importing data will start in $WAIT_TIME..."
sleep $WAIT_TIME

sqlcmd -i create-db.sql
sqlcmd -i load-data.sql
