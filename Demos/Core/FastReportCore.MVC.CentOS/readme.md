# Intro

This example shows how you can use FastReport on a CentOS docker container created manually.

# Installing the CentOS Container

1. Download and install the docker (run in the host): 

```
https://docs.docker.com/toolbox/toolbox_install_windows/
```

2. Init a new container (run in the host):

```
docker run --name MyCentos -idt centos:centos7
```

3. Start the container and start the console, i.e. bash ^_^ (run in the container):

```
docker exec -it MyCentos /bin/bash
```

4. Next, you need to install .net core and other libraries (run in the container):

```
rpm -Uvh https://packages.microsoft.com/config/rhel/7/packages-microsoft-prod.rpm
yum update
yum install -y epel-release
yum update
yum install -y dotnet-sdk-2.1 libgdiplus xorg-x11-server-Xvfb glibc-devel
yum install curl cabextract xorg-x11-font-utils fontconfig xorg-x11-fonts-100dpi
rpm -i https://downloads.sourceforge.net/project/mscorefonts2/rpms/msttcore-fonts-installer-2.6-1.noarch.rpm
# link the libs
ln -s /usr/lib64/libgdiplus.so.0.0.0 /usr/lib64/libgdiplus.so
# if file /usr/lib64/libdl.so is not exists
ln -s /usr/lib64/libdl.so.2 /usr/lib64/libdl.so

```

5. Now need to define display environment variable (run in the container):

```
echo 'DISPLAY=:99' >> /etc/environment
```

6. Next publish the project (run in the host):

```
dotnet publish -c Release -r centos-x64
```

7. And copy files to container (run in the host):

```
docker cp bin/Release/netcoreapp2.1/centos-x64/publish/. MyCentos:/FastReport.Demo
```

8. Now we need to save the state of the container to the image and then run it as we need. First, look at the container ID (run in the host):

```
docker ps
CONTAINER ID        IMAGE               COMMAND             CREATED             STATUS              PORTS               NAMES
d61e7720f1ca        centos:centos7      "/bin/bash"         31 minutes ago      Up 31 minutes                           MyCentos
```

9. Then save it to the image (run in the host):

```
docker commit d61e7720f1ca fastreport/demo
docker images
REPOSITORY             TAG                 IMAGE ID            CREATED             SIZE
fastreport/demo        latest              fb1175ba8b51        18 seconds ago      2.26GB
```

10. And start the FastReport.Demo (run in the host):

```
docker run -it -p 5000:5000 -w=/FastReport.Demo fastreport/demo:latest dotnet /FastReport.Demo/FastReportCore.MVC.CentOS.dll
```
