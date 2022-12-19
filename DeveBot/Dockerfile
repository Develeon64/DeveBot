FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DeveBot/DeveBot.csproj", "DeveBot/"]
RUN dotnet restore "DeveBot/DeveBot.csproj"
COPY . .
WORKDIR "/src/DeveBot"
RUN dotnet build "DeveBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeveBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeveBot.dll"]
