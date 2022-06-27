title ArchivalWebAPI
CD ..
call app_config.bat

CD %archiveApiOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet Auvenir.Archiving.WebAPI.dll run --urls "http://cacaudarchiveapi.auvnpd02.ase.dmchosting.ca:44333"

pause