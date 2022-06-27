title ArchivalWebjob
CD ..
call app_config.bat

CD %archiveOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet Auvenir.Archiving.WebJob.dll

pause