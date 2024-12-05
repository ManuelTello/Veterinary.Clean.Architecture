FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Veterinary.Backend.WebAPI/Veterinary.Backend.WebAPI.csproj", "Veterinary.Backend.WebAPI/"]
RUN dotnet restore "Veterinary.Backend.WebAPI/Veterinary.Backend.WebAPI.csproj"
COPY . .
WORKDIR "/src/Veterinary.Backend.WebAPI"
RUN dotnet build "Veterinary.Backend.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Veterinary.Backend.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Veterinary.Backend.WebAPI.dll"]
