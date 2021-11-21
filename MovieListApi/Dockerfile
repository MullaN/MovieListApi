FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MovieListApi/MovieListApi.csproj", "MovieListApi/"]
RUN dotnet restore "MovieListApi/MovieListApi.csproj"
COPY . .
WORKDIR "/src/MovieListApi"
RUN dotnet build "MovieListApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieListApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieListApi.dll"]
