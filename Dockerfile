# Nos fijamos en el csproj con el net
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
EXPOSE 2022 
ENV dinero Dolar
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "AAServidor.dll"]