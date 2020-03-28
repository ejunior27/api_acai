#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM microsoft/aspnetcore:2.0-stretch AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-stretch AS build
WORKDIR /src
COPY ["api_acai/api_acai.csproj", "api_acai/"]
RUN dotnet restore "api_acai/api_acai.csproj"
COPY . .
WORKDIR "/src/api_acai"
RUN dotnet build "api_acai.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api_acai.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api_acai.dll"]