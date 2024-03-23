#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/QuotesService/Quotes.API/Quotes.API.csproj", "src/QuotesService/Quotes.API/"]
COPY ["src/QuotesService/Quotes.Persistance/Quotes.Persistance.csproj", "src/QuotesService/Quotes.Persistance/"]
COPY ["src/QuotesService/Quotes.Core/Quotes.Core.csproj", "src/QuotesService/Quotes.Core/"]
COPY ["src/QuotesService/Quotes.Application/Quotes.Application.csproj", "src/QuotesService/Quotes.Application/"]
RUN dotnet restore "./src/QuotesService/Quotes.API/./Quotes.API.csproj"
COPY . .
WORKDIR "/src/src/QuotesService/Quotes.API"
RUN dotnet build "./Quotes.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Quotes.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quotes.API.dll"]