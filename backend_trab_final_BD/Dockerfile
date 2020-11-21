#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["backend_trab_final_BD/backend_trab_final_BD.csproj", "backend_trab_final_BD/"]
RUN dotnet restore "backend_trab_final_BD/backend_trab_final_BD.csproj"
COPY . .
WORKDIR "/src/backend_trab_final_BD"
RUN dotnet build "backend_trab_final_BD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend_trab_final_BD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend_trab_final_BD.dll"]