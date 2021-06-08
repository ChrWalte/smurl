# DockerHub image for dotnet core sdk 3.1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# Change directory into source
WORKDIR /source

# Copy all csproj and move into current source directory
COPY smurl.api/smurl.api.csproj ./smurl.api/
COPY smurl.data/smurl.data.csproj ./smurl.data/
COPY smurl.domain/smurl.domain.csproj ./smurl.domain/
COPY smurl.services/smurl.services.csproj ./smurl.services/

# Restore packages
RUN dotnet restore ./smurl.api/smurl.api.csproj

# Copy everything else into current source directory 
COPY . ./

# Change directory into smurl.api
WORKDIR /source/smurl.api

# Build the project as Release and output into bin folder
RUN dotnet publish -c Release -o bin

# DockerHub image for dotnet core aspnet 3.1
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# Change directory into bin
WORKDIR /bin

# Copy everything from the build image
# Copy all bin files into current directory
COPY --from=build /source/smurl.api/bin .

# Start the application using dotnet
ENTRYPOINT ["dotnet", "smurl.api.dll"]