# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build   #download sdk from ms
WORKDIR /app   #Create folder "app" , docker works inside this directory

COPY CrudTest.csproj ./  #Copy project file into container
RUN dotnet restore    #Download NuGet packages, restore dependencies

COPY . ./  #Copy all project files into container
RUN dotnet publish -c Release -o out  #Build application , create publish-ready output

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0  #Only runs app
WORKDIR /app  #docker works inside this directory

COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "CrudTest.dll"]  #Start app when container runs