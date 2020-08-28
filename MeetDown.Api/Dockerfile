#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MeetDown.Api/MeetDown.Api.csproj", "MeetDown.Api/"]
RUN dotnet restore "MeetDown.Api/MeetDown.Api.csproj"
COPY . .
WORKDIR "/src/MeetDown.Api"
RUN dotnet build "MeetDown.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeetDown.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeetDown.Api.dll"]