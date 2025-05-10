FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackeryApi/src/BackeryApi/BackeryApi.csproj", "BackeryApi/src/BackeryApi/"]
COPY ["BackeryApi/src/BackeryApi.Application/BackeryApi.Application.csproj", "BackeryApi/src/BackeryApi.Application/"]
COPY ["BackeryApi/src/BackeryApi.Domain/BackeryApi.Domain.csproj", "BackeryApi/src/BackeryApi.Domain/"]
COPY ["BackeryApi/src/BackeryApi.SqlServer/BackeryApi.SqlServer.csproj", "BackeryApi/src/BackeryApi.SqlServer/"]
COPY ["BackeryApi/src/BackeryApi.Messaging/BackeryApi.Messaging.csproj", "BackeryApi/src/BackeryApi.Messaging/"]
RUN dotnet restore "BackeryApi/src/BackeryApi/BackeryApi.csproj"
COPY . .
WORKDIR "/src/BackeryApi/src/BackeryApi"
RUN dotnet build "BackeryApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BackeryApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackeryApi.dll"]
