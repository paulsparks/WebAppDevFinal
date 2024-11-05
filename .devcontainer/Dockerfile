FROM mcr.microsoft.com/dotnet/aspnet:8.0

RUN apt-get update &&\
    apt-get install wget -y &&\
    apt-get install git -y &&\
    wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb &&\
    dpkg -i packages-microsoft-prod.deb &&\
    rm packages-microsoft-prod.deb &&\
    apt-get update &&\
    apt-get install -y dotnet-sdk-8.0 &&\
    dotnet tool install --global dotnet-ef
