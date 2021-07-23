FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

WORKDIR /src
COPY ["DesafioLeoMadeira/DesafioLeoMadeira.csproj", "DesafioLeoMadeira/"]
COPY ["DesafioLeoMadeira.ViewObject/DesafioLeoMadeira.ViewObject.csproj", "DesafioLeoMadeira.ViewObject/"]
COPY ["DesafioLeoMandeira.Services/DesafioLeoMandeira.Services.csproj", "DesafioLeoMandeira.Services/"]
COPY ["DesafioLeoMadeira.Domain/DesafioLeoMadeira.Domain.csproj", "DesafioLeoMadeira.Domain/"]
COPY ["DesafioLeoMadeiraTest/DesafioLeoMadeiraTest.csproj", "DesafioLeoMadeiraTest/"]
RUN dotnet restore "DesafioLeoMadeira/DesafioLeoMadeira.csproj"
COPY . .
WORKDIR "/src/DesafioLeoMadeira"
RUN dotnet build "DesafioLeoMadeira.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioLeoMadeira.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioLeoMadeira.dll"]