# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /usr/src/backend

# copy csproj and restore as distinct layers
COPY *.sln .

COPY Api /usr/src/backend/Api
COPY Extentions /usr/src/backend/Extentions
COPY Infrastructure /usr/src/backend/Infrastructure
COPY Model /usr/src/backend/Model

RUN ls -la
RUN dotnet build --configuration Release
RUN dotnet publish -c Release -o /usr/src/backend/pokeemon --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /usr/src/backend/pokeemon
COPY --from=build /usr/src/backend/pokeemon ./
ENTRYPOINT ["./Api"]