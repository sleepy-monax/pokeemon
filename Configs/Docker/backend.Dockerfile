# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /usr/src/Backend

COPY Backend/Pokeemon.sln .

COPY Backend/Api /usr/src/Backend/Api
COPY Backend/Infrastructure /usr/src/Backend/Infrastructure
COPY Backend/Model /usr/src/Backend/Model

RUN dotnet build --configuration Release
RUN dotnet publish -c Release -o /usr/src/Backend/pokeemon --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /usr/src/Backend/pokeemon
COPY --from=build /usr/src/Backend/pokeemon ./

ENTRYPOINT ["./Api"]