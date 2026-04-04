FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Trax.BlazorApp/Trax.BlazorApp.csproj",          "Trax.BlazorApp/"]
COPY ["Trax.Application/Trax.Application.csproj",       "Trax.Application/"]
COPY ["Trax.Infrastructure/Trax.Infrastructure.csproj", "Trax.Infrastructure/"]
COPY ["Trax.Domain/Trax.Domain.csproj",                 "Trax.Domain/"]

RUN dotnet restore "Trax.BlazorApp/Trax.BlazorApp.csproj"

COPY . .

WORKDIR "/src/Trax.BlazorApp"
RUN dotnet publish "Trax.BlazorApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Trax.BlazorApp.dll"]