# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/UserProfileMicroservice.WebHost/UserProfileMicroservice.WebHost.csproj", "WebApi/UserProfileMicroservice.WebHost/"]
COPY ["BusinessLogic/UserProfileMicroservice.BusinessLogic.Contracts/UserProfileMicroservice.BusinessLogic.Contracts.csproj", "BusinessLogic/UserProfileMicroservice.BusinessLogic.Contracts/"]
COPY ["Common/UserProfileMicroservice.Common/UserProfileMicroservice.Common.csproj", "Common/UserProfileMicroservice.Common/"]
COPY ["BusinessLogic/UserProfileMicroservice.BusinessLogic.Services.Abstractions/UserProfileMicroservice.BusinessLogic.Services.Abstractions.csproj", "BusinessLogic/UserProfileMicroservice.BusinessLogic.Services.Abstractions/"]
COPY ["BusinessLogic/UserProfileMicroservice.BusinessLogic.Services.Implementations/UserProfileMicroservice.BusinessLogic.Services.Implementations.csproj", "BusinessLogic/UserProfileMicroservice.BusinessLogic.Services.Implementations/"]
COPY ["DataAccess/UserProfileMicroservice.DataAccess.Entities/UserProfileMicroservice.DataAccess.Entities.csproj", "DataAccess/UserProfileMicroservice.DataAccess.Entities/"]
COPY ["DataAccess/UserProfileMicroservice.DataAccess.ValueObjects/UserProfileMicroservice.DataAccess.ValueObjects.csproj", "DataAccess/UserProfileMicroservice.DataAccess.ValueObjects/"]
COPY ["DataAccess/UserProfileMicroservice.DataAccess.Repositories.Abstractions/UserProfileMicroservice.DataAccess.Repositories.Abstractions.csproj", "DataAccess/UserProfileMicroservice.DataAccess.Repositories.Abstractions/"]
COPY ["DataAccess/UserProfileMicroservice.DataAccess.EntityFramework/UserProfileMicroservice.DataAccess.EntityFramework.csproj", "DataAccess/UserProfileMicroservice.DataAccess.EntityFramework/"]
COPY ["DataAccess/UserProfileMicroservice.DataAccess.Repositories.Implementations/UserProfileMicroservice.DataAccess.Repositories.Implementations.csproj", "DataAccess/UserProfileMicroservice.DataAccess.Repositories.Implementations/"]
RUN dotnet restore "./WebApi/UserProfileMicroservice.WebHost/UserProfileMicroservice.WebHost.csproj"
COPY . .
WORKDIR "/src/WebApi/UserProfileMicroservice.WebHost"
RUN dotnet build "./UserProfileMicroservice.WebHost.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UserProfileMicroservice.WebHost.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserProfileMicroservice.WebHost.dll"]