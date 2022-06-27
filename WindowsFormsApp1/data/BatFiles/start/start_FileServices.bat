title FileService
CD ..
call app_config.bat

CD %fsOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet Auvenir.FileService.WebApi.dll --server.urls=http://cacaudfile.auvnpd02.ase.dmchosting.ca:300
pause 