FROM microsoft/dotnet:2.1-sdk
COPY . /app

WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh