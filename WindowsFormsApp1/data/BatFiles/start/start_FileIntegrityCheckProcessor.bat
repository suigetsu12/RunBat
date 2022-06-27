title FileIntegrityCheckProcessor
CD ..
call app_config.bat

CD %fileIntegrityCheckProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolNet6Path% host start -c Local --port 7077 

pause 