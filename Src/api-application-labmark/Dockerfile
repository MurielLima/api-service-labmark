#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["api-application-labmark.csproj", "api-application-labmark/"]
RUN dotnet restore "api-application-labmark/api-application-labmark.csproj"
WORKDIR /src/api-application-labmark
COPY . .
WORKDIR "/src/api-application-labmark"
RUN dotnet build "api-application-labmark.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api-application-labmark.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Labmark.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet Labmark.dll