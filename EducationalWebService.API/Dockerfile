FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EducationalWebService.API/EducationalWebService.API.csproj", "EducationalWebService.API/"]
COPY ["EducationalWebService.Data/EducationalWebService.Data.csproj", "EducationalWebService.Data/"]
COPY ["EducationalWebService.Logic/EducationalWebService.Logic.csproj", "EducationalWebService.Logic/"]
RUN dotnet restore "./EducationalWebService.API/./EducationalWebService.API.csproj"
COPY . .
WORKDIR "/src/EducationalWebService.API"
RUN dotnet build "./EducationalWebService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EducationalWebService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EducationalWebService.API.dll"]