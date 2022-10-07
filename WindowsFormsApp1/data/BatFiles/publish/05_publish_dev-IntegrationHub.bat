CD ..
call app_config.bat
@echo on

@echo Publishing IntegrationHubService ...
CD %IntegrationHubServiceUrl%
dotnet restore
dotnet publish -c Local -o %integrationHubOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing AuvenirIntegrationHubProcessor ...
CD %AuvenirIntegrationHubProcessorUrl%
dotnet restore
dotnet publish -c Local -o %AuvenirIntegrationHubProcessorOutputUrl%  
@echo Publish successfully---------------------------------------

pause