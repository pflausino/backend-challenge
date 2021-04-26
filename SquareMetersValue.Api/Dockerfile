FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY SquareMetersValue.Api/*.csproj ./SquareMetersValue.Api/
COPY SquareMetersValue.Domain/*.csproj ./SquareMetersValue.Domain/
COPY SquareMetersValue.Infra/*.csproj ./SquareMetersValue.Infra/
COPY SquareMetersValue.Api.Tests/*.csproj ./SquareMetersValue.Api.Tests/
COPY SquareMetersValue.Domain.Tests/*.csproj ./SquareMetersValue.Domain.Tests/ 
#
RUN dotnet restore 
#
# copy everything else and build app
COPY SquareMetersValue.Api/. ./SquareMetersValue.Api/
COPY SquareMetersValue.Domain/. ./SquareMetersValue.Domain/
COPY SquareMetersValue.Infra/. ./SquareMetersValue.Infra/ 
#
WORKDIR /app/SquareMetersValue.Api
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app 

COPY --from=build /app/SquareMetersValue.Api/out ./
ENTRYPOINT ["dotnet", "SquareMetersValue.Api.dll"]


