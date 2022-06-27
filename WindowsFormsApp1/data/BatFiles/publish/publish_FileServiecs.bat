title publish_FileServices
CD ..
call app_config.bat
@echo on
@echo Publishing File Services check Processor...
cd %fileServicesUrl%
dotnet restore
dotnet publish -c Local -o %fsOutputUrl%  
@echo -----------------------------------------------
@echo Publishing File Services check Processor...

pause
