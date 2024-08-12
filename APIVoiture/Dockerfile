FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["APIVoiture/APIVoiture.csproj", "APIVoiture/"]
RUN dotnet restore "./APIVoiture/APIVoiture.csproj"
COPY . .
WORKDIR "/src/APIVoiture"
RUN dotnet build "./APIVoiture.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./APIVoiture.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIVoiture.dll"]