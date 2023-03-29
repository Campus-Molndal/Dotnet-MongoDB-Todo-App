# Dotnet-MongoDB-Todo-App

export TODO_SERVICE_IMPLEMENTATION=MongoDb
export ASPNETCORE_ENVIRONMENT=Docker

docker run -d -p 5000:80 -e TODO_SERVICE_IMPLEMENTATION=MongoDb -e ASPNETCORE_ENVIRONMENT=Docker --network todoapp_default larsappel/todoapp
