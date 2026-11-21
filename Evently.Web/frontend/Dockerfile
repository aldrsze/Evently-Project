FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["evently.csproj", "./"]
RUN dotnet restore "./evently.csproj"
COPY . .
RUN dotnet publish "./evently.csproj" --configuration Release --output /app/publish --no-restore /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=3000
EXPOSE 3000
ENTRYPOINT ["sh", "-c", "exec dotnet evently.dll --urls http://0.0.0.0:${PORT:-3000}"]
