FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ONIS.API.Catalog/ONIS.API.Catalog/ONIS.API.Catalog.csproj", "ONIS.API.Catalog/"]
RUN dotnet restore "ONIS.API.Catalog/ONIS.API.Catalog.csproj"
COPY . .
WORKDIR "/src/ONIS.API.Catalog"
RUN dotnet build "ONIS.API.Catalog/ONIS.API.Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ONIS.API.Catalog/ONIS.API.Catalog.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ONIS.API.Catalog.dll","--environment=Developer","--launch-profile https"]