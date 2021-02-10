#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
RUN apt-get update && apt-get -y install libxml2 libgdiplus libc6-dev
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Src/api-application-labmark/api-application-labmark.csproj", "Src/api-application-labmark/"]
RUN dotnet restore "Src/api-application-labmark/api-application-labmark.csproj"
COPY . .
WORKDIR "/src/Src/api-application-labmark"
RUN dotnet build "api-application-labmark.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api-application-labmark.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Labmark.dll"]