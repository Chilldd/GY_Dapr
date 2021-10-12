#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DaprSystemManage/DaprSystemManage.csproj", "DaprSystemManage/"]
RUN dotnet restore "DaprSystemManage/DaprSystemManage.csproj"
COPY . .
WORKDIR "/src/DaprSystemManage"
RUN dotnet build "DaprSystemManage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprSystemManage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprSystemManage.dll"]
