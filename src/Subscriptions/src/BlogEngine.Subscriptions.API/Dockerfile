#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Subscriptions/src/BlogEngine.Subscriptions.API/BlogEngine.Subscriptions.API.csproj", "src/Subscriptions/src/BlogEngine.Subscriptions.API/"]
RUN dotnet restore "src/Subscriptions/src/BlogEngine.Subscriptions.API/BlogEngine.Subscriptions.API.csproj"
COPY . .
WORKDIR "/src/src/Subscriptions/src/BlogEngine.Subscriptions.API"
RUN dotnet build "BlogEngine.Subscriptions.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogEngine.Subscriptions.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogEngine.Subscriptions.API.dll"]