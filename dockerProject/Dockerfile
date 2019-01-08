FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
# Copy csproj and restore as distinct layers
WORKDIR /src

# Copy everything else and build
COPY . .

WORKDIR /src/WebApp
# install npm
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_8.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install --save

FROM build AS publish
RUN dotnet publish "WebApp.csproj" -c Release -r debian.8-x64 -o /app
# Build runtime image

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApp.dll"]