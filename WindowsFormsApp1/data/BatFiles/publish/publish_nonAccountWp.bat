title publish_nonAccountWp
CD ..
call app_config.bat
@echo on
@echo Publishing workingpaper project....

@echo -----------------------------------------------

@echo Publishing NonAccountWorkingPaperService...
CD %pm_vsaSourceUrl%
dotnet restore
dotnet publish -c Local -o %pm_vsaOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------
pause
