title publish_FE
CD ..
call app_config.bat
@echo on
@echo Publishing Front End project....
cd %feSourceUrl%
dotnet publish -c Local -o %feOutputUrl%
@echo -----------------------------------------------
@echo -----------------------------------------------

pause