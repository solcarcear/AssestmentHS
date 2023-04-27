#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./CaaoBakery.Api/CaaoBakery.Api.csproj", "CaaoBakery.Api/"]
COPY ["./CaaoBakery.Contracts", "CaaoBakery.Contracts/"]
COPY ["./CaaoBakery.Application/CaaoBakery.Application.csproj", "CaaoBakery.Application/"]
COPY ["./CaaoBakery.Domain/CaaoBakery.Domain.csproj", "CaaoBakery.Domain/"]
COPY ["./CaaoBakery.Infrastructure/CaaoBakery.Infrastructure.csproj", "CaaoBakery.Infrastructure/"]
RUN dotnet restore "./CaaoBakery.Api/CaaoBakery.Api.csproj"
COPY . .
WORKDIR "/src/CaaoBakery.Api"
RUN dotnet build "./CaaoBakery.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./CaaoBakery.Api.csproj" -c Release -o /app/publish 


FROM base AS final
WORKDIR /app
EXPOSE 7029
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaaoBakery.Api.dll"]