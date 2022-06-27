title CarryforwardFileTransferProcessor
CD ..
call app_config.bat

CD %carryforwardFileTransferProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolNet6Path% host start --port 7076
pause 
