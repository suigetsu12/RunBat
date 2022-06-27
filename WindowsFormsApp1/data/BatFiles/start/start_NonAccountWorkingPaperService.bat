title NonAccountWorkingPaperService
CD ..
call app_config.bat

CD %pm_vsaOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet Auvenir.NonAccountWorkingPaperService.dll   --server.urls=http://cacaudnonaccountwp.auvnpd02.ase.dmchosting.ca:500

pause