#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Botex Api/Botex Api/BxApi.csproj", "BotEx Api/"]
RUN dotnet restore "Botex Api/Botex Api/BExApi.csproj"
COPY . .
WORKDIR "/src/BotEx Api"
RUN dotnet build "BExApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BExApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BExApi.dll"]