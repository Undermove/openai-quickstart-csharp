FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OpenAiQuickStartCSharp/OpenAiQuickStartCSharp.csproj", "OpenAiQuickStartCSharp/"]
RUN dotnet restore "OpenAiQuickStartCSharp/OpenAiQuickStartCSharp.csproj"
COPY . .
WORKDIR "/src/OpenAiQuickStartCSharp"
RUN dotnet build "OpenAiQuickStartCSharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenAiQuickStartCSharp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenAiQuickStartCSharp.dll"]
