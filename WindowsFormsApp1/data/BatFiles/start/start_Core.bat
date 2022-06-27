title Core
CD ..
call app_config.bat

CD %coreOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local

dotnet Auvenir.Web.dll --server.urls=http://cacaudcore.auvnpd02.ase.dmchosting.ca:100

pause