title AuvenirDuplicateFileProcessor
CD ..
call app_config.bat

CD %AuvenirDuplicateFileProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolNet6Path% host start --port 7083 -c Local
pause 
