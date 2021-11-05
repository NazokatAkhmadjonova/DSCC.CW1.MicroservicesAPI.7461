#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DSCC.CW1.MicroservicesAPI.7461/DSCC.CW1.MicroservicesAPI.7461.csproj", "DSCC.CW1.MicroservicesAPI.7461/"]
RUN dotnet restore "DSCC.CW1.MicroservicesAPI.7461/DSCC.CW1.MicroservicesAPI.7461.csproj"
COPY . .
WORKDIR "/src/DSCC.CW1.MicroservicesAPI.7461"
RUN dotnet build "DSCC.CW1.MicroservicesAPI.7461.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSCC.CW1.MicroservicesAPI.7461.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSCC.CW1.MicroservicesAPI.7461.dll"]