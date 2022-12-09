#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Rick_And_Morty.csproj", "."]
RUN dotnet restore "./Rick_And_Morty.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Rick_And_Morty.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rick_And_Morty.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rick_And_Morty.dll"]