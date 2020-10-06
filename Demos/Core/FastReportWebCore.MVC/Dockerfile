# IMPORTANT: The Reports folder must be copied in current folder before building the image
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY FastReportWebCore.MVC.sln .
COPY /FastReportWebCore.MVC/*.csproj ./FastReportWebCore.MVC/
RUN dotnet restore

# copy everything else and build app
COPY /FastReportWebCore.MVC/ ./FastReportWebCore.MVC/
WORKDIR /app/FastReportWebCore.MVC/
RUN dotnet publish -c Release -o out

#ENV ASPNETCORE_URLS http://*:5000
#EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 as runtime

RUN apt-get update \ 
    && apt-get install -y --allow-unauthenticated \ 
        libc6-dev \ 
        libgdiplus \ 
        libx11-dev \ 
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY --from=build /app/FastReportWebCore.MVC/out ./
COPY /Reports/ ./Reports/
ENTRYPOINT ["dotnet", "FastReportWebCore.MVC.dll"]
