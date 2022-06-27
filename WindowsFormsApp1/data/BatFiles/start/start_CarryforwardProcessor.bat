title CarryforwardProcessor
CD ..
call app_config.bat

CD %carryforwardProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolNet6Path% host start --port 7072 
pause 
