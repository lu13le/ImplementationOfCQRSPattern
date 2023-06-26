FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ImplementationOfCQRSPattern/ImplementationOfCQRSPattern.csproj", "ImplementationOfCQRSPattern/"]
RUN dotnet restore "ImplementationOfCQRSPattern/ImplementationOfCQRSPattern.csproj"
COPY . .
WORKDIR "/src/ImplementationOfCQRSPattern"
RUN dotnet build "ImplementationOfCQRSPattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ImplementationOfCQRSPattern.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ImplementationOfCQRSPattern.dll"]
