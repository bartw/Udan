# Udan
Ubuntu Docker Asp.Net

## Windows build machine

### DNVM
- https://github.com/aspnet/home

- Install dnvm (.NET Version Manager)
```shell
&{$Branch='dev';$wc=New-Object System.Net.WebClient;$wc.Proxy=[System.Net.WebRequest]::DefaultWebProxy;$wc.Proxy.Credentials=[System.Net.CredentialCache]::DefaultNetworkCredentials;Invoke-Expression ($wc.DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}
```
- Check if dnvm is running
```shell
dnvm
```
- Install coreclr using dnvm
```shell
dnvm install 1.0.0-beta8 -r coreclr
```

- Check if the newly installed runtime is active
```shell
dnvm list
```

### Run udan

- Clone this repo local and open a shell in this folder

- Restore packages
```shell
dnu restore
```

- Execute command
```shell
dnx kestrel
```

- Surf to http://localhost:5004/

## Ubuntu with Docker on Azure

### Create the vm on Azure
- Follow the instructions on [this](https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-ubuntu-quickstart/) website.
- Add an Endpoint that maps internal port 80 on external port 80

### SSH on Windows
- http://www.hanselman.com/blog/ItsHappeningOpenSSHForWindowsfromMicrosoft.aspx
- https://github.com/PowerShell/Win32-OpenSSH
- Login on azure using ssh in powershell
```shell
ssh username@xxx.cloudapp.net
```

### Setup vm

- http://blogs.msdn.com/b/webdev/archive/2015/01/14/running-asp-net-5-applications-in-linux-containers-with-docker.aspx

- Install the ASP.NET 5 Preview Docker Image
```shell
docker pull microsoft/aspnet:1.0.0-beta8-coreclr
```

- Clone this repo and cd to the folder

- Build Udan
```shell
docker -t udan .
```

- Check docker images
```shell
docker images
```
There should be 3 images udan, microsoft/aspnet and ubuntu.

- Run udan
```shell
docker run -t -d -p 80:5004 udan
```

- Check running containers
```shell
docker ps
```

- Surf to http://xxx.cloudapp.net/