title Planning
CD ..
call app_config.bat

CD %pm_psOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet Auvenir.PlanningStep.dll --server.urls=http://cacaudplanning.auvnpd02.ase.dmchosting.ca:600

pause