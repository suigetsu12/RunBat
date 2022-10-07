title publish_IntegrationHubService 
CD ..
call app_config.bat
@echo Publishing IntegrationHubService ...
CD %IntegrationHubServiceUrl%
dotnet restore
dotnet publish -c Local -o %integrationHubOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause
