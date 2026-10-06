# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and project files (adjust paths for repo layout)
COPY ["BugTracker_Backend.sln", "./"]
COPY ["BugTracker_Backend/BugTracker_Backend.csproj", "BugTracker_Backend/"]

# Restore using the solution to keep caching effective
RUN dotnet restore "BugTracker_Backend.sln"

# Copy the rest of the source and publish
COPY . .
WORKDIR /src/BugTracker_Backend
RUN dotnet publish "BugTracker_Backend.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Listen on port 80
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BugTracker_Backend.dll"]
