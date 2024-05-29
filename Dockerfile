FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet publish "MikrotikActiveConnectionsExporter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 9071
ENV ASPNETCORE_URLS=http://0.0.0.0:9071
ENTRYPOINT ["dotnet", "MikrotikActiveConnectionsExporter.csproj"]