FROM microsoft/aspnet:1.0.0-beta8-coreclr

RUN apt-get -qq update
RUN apt-get -qqy install libsqlite3-dev

COPY . /app
WORKDIR /app
RUN ["dnu", "restore"]

EXPOSE 5004
ENTRYPOINT ["dnx", "-p", "project.json", "kestrel"]