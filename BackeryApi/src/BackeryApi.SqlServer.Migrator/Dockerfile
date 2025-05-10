FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackeryApi/src/BackeryApi.SqlServer.Migrator/BackeryApi.SqlServer.Migrator.csproj", "BackeryApi/src/BackeryApi.SqlServer.Migrator/"]
COPY ["BackeryApi/src/BackeryApi.SqlServer/BackeryApi.SqlServer.csproj", "BackeryApi/src/BackeryApi.SqlServer/"]
COPY ["BackeryApi/src/BackeryApi.Domain/BackeryApi.Domain.csproj", "BackeryApi/src/BackeryApi.Domain/"]
RUN dotnet restore "BackeryApi/src/BackeryApi.SqlServer.Migrator/BackeryApi.SqlServer.Migrator.csproj"
COPY . .
WORKDIR "/src/BackeryApi/src/BackeryApi.SqlServer.Migrator"
RUN dotnet build "BackeryApi.SqlServer.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BackeryApi.SqlServer.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackeryApi.SqlServer.Migrator.dll"]
