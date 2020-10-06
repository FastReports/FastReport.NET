FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 43105
EXPOSE 44364

RUN apt-get update
RUN echo ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula \
    select true | debconf-set-selections
RUN apt-get install -y wget
RUN wget http://ftp.de.debian.org/debian/pool/contrib/m/msttcorefonts/ttf-mscorefonts-installer_3.6_all.deb -P /Downloads
RUN apt-get install -y /Downloads/ttf-mscorefonts-installer_3.6_all.deb
RUN apt-get install -y xvfb x11vnc x11-xkb-utils xfonts-100dpi xfonts-75dpi xfonts-scalable xfonts-cyrillic x11-apps libgdiplus libx11-dev
ENV DISPLAY :99

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Demos/Core/FastReport.Core.Web21.MVC/FastReport.Core.Web21.MVC.csproj", "Demos/Core/FastReport.Core.Web21.MVC/"]
COPY ["FastReport.Core/FastReport.Core.csproj", "FastReport.Core/"]
COPY ["FastReport.Core.Web/FastReport.Web.csproj", "FastReport.Core.Web/"]
RUN dotnet restore "Demos/Core/FastReport.Core.Web21.MVC/FastReport.Core.Web21.MVC.csproj"
COPY . .
WORKDIR "/src/Demos/Core/FastReport.Core.Web21.MVC"
RUN dotnet build "FastReport.Core.Web21.MVC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FastReport.Core.Web21.MVC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FastReport.Core.Web21.MVC.dll"]