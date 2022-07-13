
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DojoProject.Api/DojoProject.Api.csproj", "DojoProject.Api/"]
COPY ["DojoProject.Domain/DojoProject.Domain.csproj", "DojoProject.Domain/"]
COPY ["DojoProject.Application/DojoProject.Application.csproj", "DojoProject.Application/"]
COPY ["DojoProject.Infrastructure/DojoProject.Infrastructure.csproj", "DojoProject.Infrastructure/"]
RUN dotnet restore "DojoProject.Api/DojoProject.Api.csproj"
COPY . .
WORKDIR "/src/DojoProject.Api"
RUN dotnet build "DojoProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DojoProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DojoProject.Api.dll"]