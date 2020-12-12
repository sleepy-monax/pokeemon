# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /usr/src/backend

# copy csproj and restore as distinct layers
COPY *.sln .

COPY Api /usr/src/backend
COPY Extentions /usr/src/backend
COPY Infrastructure /usr/src/backend
COPY Model /usr/src/backend

RUN dotnet build --configuration Release
RUN dotnet publish -c Release -o /usr/src/backend --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /usr/src/backend
COPY --from=build /usr/src/backend ./
ENTRYPOINT ["./Api"]