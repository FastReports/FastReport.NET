FROM fastreport/demo:latest AS base
WORKDIR /app
EXPOSE 5000

FROM fastreport/demo:latest AS build
WORKDIR /src
COPY ["Demos/Core/FastReportCore.MVC.CentOS/FastReportCore.MVC.CentOS.csproj", "Demos/Core/FastReportCore.MVC.CentOS/"]
COPY ["FastReport.Web.Core/FastReport.Web/FastReport.Web.csproj", "FastReport.Web.Core/FastReport.Web/"]
COPY ["FastReport.Core/FastReportCore.csproj", "FastReport.Core/"]
RUN dotnet restore "Demos/Core/FastReportCore.MVC.CentOS/FastReportCore.MVC.CentOS.csproj"
COPY . .
WORKDIR "/src/Demos/Core/FastReportCore.MVC.CentOS"
RUN dotnet build "FastReportCore.MVC.CentOS.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FastReportCore.MVC.CentOS.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FastReportCore.MVC.CentOS.dll"]