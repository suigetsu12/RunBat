title CarryforwardContentProcessor
CD ..
call app_config.bat

CD %carryforwardContentProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolNet6Path% host start --port 7073 -c Local
pause 
