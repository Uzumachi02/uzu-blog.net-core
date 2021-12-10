#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Uzumachi.UzuBlog.Web/Uzumachi.UzuBlog.Web.csproj", "Uzumachi.UzuBlog.Web/"]
RUN dotnet restore "Uzumachi.UzuBlog.Web/Uzumachi.UzuBlog.Web.csproj"
COPY . .
WORKDIR "/src/Uzumachi.UzuBlog.Web"
RUN dotnet build "Uzumachi.UzuBlog.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Uzumachi.UzuBlog.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Uzumachi.UzuBlog.Web.dll"]