# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ["BugTracker_Backend.csproj", "./"]
RUN dotnet restore "BugTracker_Backend.csproj"

# copy everything else and publish
COPY . .
RUN dotnet publish "BugTracker_Backend.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Listen on port 80
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BugTracker_Backend.dll"]
