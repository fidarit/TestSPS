FROM mcr.microsoft.com/mssql/server:2019-latest

ENV MSSQL_SA_PASSWORD=myStong_Password123#
ENV ACCEPT_EULA=Y

COPY sql/*.sql ./
COPY sql/*.sh ./

RUN /opt/mssql/bin/sqlservr & ./init.sh
