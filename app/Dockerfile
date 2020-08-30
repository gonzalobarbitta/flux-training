#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CloudSample.App.Web.csproj", ""]
RUN dotnet restore "./CloudSample.App.Web.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CloudSample.App.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudSample.App.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudSample.App.Web.dll"]