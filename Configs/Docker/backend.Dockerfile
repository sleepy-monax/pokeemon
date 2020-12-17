# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app/Backend

COPY Backend/Pokeemon.sln .

COPY Backend/Api /app/Backend/Api
COPY Backend/Infrastructure /app/Backend/Infrastructure
COPY Backend/Model /app/Backend/Model
COPY Assets /app/Assets

RUN dotnet dev-certs https -ep /app/Backend/pokeemon/cert.pfx -p localhost
RUN ls -la /app/Backend/

RUN dotnet build --configuration Release
RUN dotnet publish -c Release -o /app/Backend/pokeemon --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app/Backend/pokeemon
COPY --from=build /app/Backend/pokeemon ./

ENTRYPOINT ["./Api"]