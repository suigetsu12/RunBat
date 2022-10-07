title IntegrationHubProccessor

CD ..
call app_config.bat

CD %AuvenirIntegrationHubProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolPath% host start --port 8087 -c Local
pause 
