FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

EXPOSE 80

COPY CarSite.sln .

COPY AuctionService/AuctionService.csproj AuctionService/
COPY IdentityService/IdentityService.csproj IdentityService/
COPY SearchService/SearchService.csproj SearchService/
COPY GatewayService/GatewayService.csproj GatewayService/
COPY Contracts/Contracts.csproj Contracts/

RUN dotnet restore CarSite.sln

COPY SearchService SearchService
COPY Contracts Contracts
WORKDIR /app/SearchService
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "SearchService.dll"]