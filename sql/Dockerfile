FROM mcr.microsoft.com/mssql/server:2019-latest

ENV MSSQL_SA_PASSWORD=myStong_Password123#
ENV ACCEPT_EULA=Y

USER root

RUN mkdir -p /scripts
COPY sql/*.sql /scripts
COPY sql/*.sh /scripts

USER mssql

RUN /opt/mssql/bin/sqlservr & /scripts/init.sh
