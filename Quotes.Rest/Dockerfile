#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Quotes.Rest/Quotes.Rest.csproj", "Quotes.Rest/"]
COPY ["Quotes.Core/Quotes.Core.csproj", "Quotes.Core/"]
COPY ["Quotes.Repositories/Quotes.Repositories.csproj", "Quotes.Repositories/"]
COPY ["Quotes.Models/Quotes.Models.csproj", "Quotes.Models/"]
RUN dotnet restore "Quotes.Rest/Quotes.Rest.csproj"
COPY . .
WORKDIR "/src/Quotes.Rest"
RUN dotnet build "Quotes.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quotes.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quotes.Rest.dll"]