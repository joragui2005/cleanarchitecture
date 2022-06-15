FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CleanArchitecture.Presentation/CleanArchitecture.Presentation.csproj", "CleanArchitecture.Presentation/"]
RUN dotnet restore "CleanArchitecture.Presentation/CleanArchitecture.Presentation.csproj"
COPY . .
WORKDIR "/src/CleanArchitecture.Presentation"
RUN dotnet build "CleanArchitecture.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecture.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.Presentation.dll"]
