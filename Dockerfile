#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app

COPY WX.sln .
COPY src/Application/Application.csproj ./src/Application/Application.csproj
COPY src/Common/Common.csproj ./src/Common/Common.csproj
COPY src/Domain/Domain.csproj ./src/Domain/Domain.csproj
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/Infrastructure.csproj
COPY src/WebAPI/WebAPI.csproj ./src/WebAPI/WebAPI.csproj

COPY tests/Application.UnitTests/Application.UnitTests.csproj ./tests/Application.UnitTests/Application.UnitTests.csproj
COPY tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj ./tests/Infrastructure.IntegrationTests/Infrastructure.IntegrationTests.csproj
COPY tests/WebAPI.IntegrationTests/WebAPI.IntegrationTests.csproj ./tests/WebAPI.IntegrationTests/WebAPI.IntegrationTests.csproj

RUN dotnet restore
COPY . .

WORKDIR /app/src/WebAPI
RUN dotnet build WebAPI.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish WebAPI.csproj -c Release -o /app/publish -r linux-x64 -f netcoreapp3.1 --no-restore


WORKDIR /app/tests/Application.UnitTests
RUN dotnet test

WORKDIR /app/tests/Infrastructure.IntegrationTests
RUN dotnet test

WORKDIR /app/tests/WebAPI.IntegrationTests
RUN dotnet test

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebAPI.dll"]