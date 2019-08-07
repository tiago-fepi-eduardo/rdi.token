FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY Token.Presentation/Token.Api.csproj Token.Presentation/
COPY Token.Service/Token.Service.csproj Token.Service/
COPY Token.Domain/Token.Domain.csproj Token.Domain/
COPY Token.Infra.CrossCutting/Token.Infra.CrossCutting.csproj Token.Infra.CrossCutting/
COPY Token.Infra.Data/Token.Infra.Data.csproj Token.Infra.Data/
RUN dotnet restore Token.Presentation/Token.Api.csproj
COPY . .
WORKDIR /src/Token.Presentation
RUN dotnet build Token.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Token.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Token.Api.dll"]
