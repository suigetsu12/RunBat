title publish_CommonToolService
CD ..
call app_config.bat
@echo Publishing CommonToolService ...
CD %pm_snSourceUrl%
dotnet restore
dotnet publish -c Local -o %pm_snOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause
