FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FarmTradeApp/FarmTradeApp.csproj", "FarmTradeApp/"]
RUN dotnet restore "FarmTradeApp/FarmTradeApp.csproj"
COPY . .
WORKDIR "/src/FarmTradeApp"
RUN dotnet build "FarmTradeApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FarmTradeApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FarmTradeApp.dll"]
