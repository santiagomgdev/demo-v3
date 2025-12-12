FROM mcr.microsoft.com/dotnet/sdk:9.0 
WORKDIR /src
COPY src/. .
WORKDIR /src/Application
RUN dotnet tool install --global dotnet-ef --version 9.0.11
ENV PATH="$PATH:/root/.dotnet/tools"
ENTRYPOINT ["dotnet", "ef", "database", "update"]