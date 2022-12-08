#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5006

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestProject/TestProject.csproj", "TestProject/"]
COPY ["TestProject.Data/TestProject.Data.csproj", "TestProject.Data/"]
COPY ["TestProject.Interfaces/TestProject.Interfaces.csproj", "TestProject.Interfaces/"]
COPY ["TestProject.Models/TestProject.Models.csproj", "TestProject.Models/"]
COPY ["TestProject.Mvc/TestProject.Mvc.csproj", "TestProject.Mvc/"]
COPY ["TestProject.ViewModels/TestProject.ViewModels.csproj", "TestProject.ViewModels/"]
RUN dotnet restore "TestProject/TestProject.csproj"
COPY . .
WORKDIR "/src/TestProject"
RUN dotnet build "TestProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestProject.dll"]
