#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/NotificationsService/Notifications.API/Notifications.API.csproj", "src/NotificationsService/Notifications.API/"]
COPY ["src/NotificationsService/Notifications.Core/Notifications.Core.csproj", "src/NotificationsService/Notifications.Core/"]
COPY ["src/NotificationsService/Notifications.Application/Notifications.Application.csproj", "src/NotificationsService/Notifications.Application/"]
COPY ["src/NotificationsService/Notifications.Persistance/Notifications.Persistance.csproj", "src/NotificationsService/Notifications.Persistance/"]
RUN dotnet restore "./src/NotificationsService/Notifications.API/./Notifications.API.csproj"
COPY . .
WORKDIR "/src/src/NotificationsService/Notifications.API"
RUN dotnet build "./Notifications.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notifications.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifications.API.dll"]