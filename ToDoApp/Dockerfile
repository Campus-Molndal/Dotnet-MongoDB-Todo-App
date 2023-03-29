# syntax=docker/dockerfile:1

# This is a two step Dockerfile that first builds and then creates the final image
# The structure is taken from the Docker getting started documentation
# https://docs.docker.com/language/dotnet/build-images/

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src
COPY ./*.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ToDoApp.dll"]

