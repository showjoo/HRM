﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Authentication/Authentication.API/Authentication.API.csproj", "Services/Authentication/Authentication.API/"]
RUN dotnet restore "Services/Authentication/Authentication.API/Authentication.API.csproj"
COPY . .
WORKDIR "/src/Services/Authentication/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app/publish -r linux-x64 --self-contained false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString = "Server=localhost;Database=RecruitingDb;User=sa;Password=StrngPwd1234;TrustServerCertificate=True;"
ENTRYPOINT ["dotnet", "Authentication.API.dll"]
