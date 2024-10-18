#!/usr/bin/env bash
until /opt/mssql-tools18/bin/sqlcmd -S localhost -U "SA" -P "$MSSQL_SA_PASSWORD" -C -Q "SELECT 1" &>/dev/null; 
do
    echo "waiting"
    sleep 2
done

DB_EXISTS=$(/opt/mssql-tools18/bin/sqlcmd -S localhost -U "SA" -P "$MSSQL_SA_PASSWORD" -C -Q "SELECT 1 FROM sys.databases WHERE name = 'serverdb'" -h -1)

if ! echo "$DB_EXISTS" | grep -q "1"; then
    /opt/mssql-tools18/bin/sqlcmd -S localhost -U "SA" -P "$MSSQL_SA_PASSWORD" -C -Q "CREATE DATABASE serverdb"

    for script in ./*.sql; 
    do 
        /opt/mssql-tools18/bin/sqlcmd -S localhost -U "SA" -P "$MSSQL_SA_PASSWORD" -C -d serverdb -i "$script"
    done
fi