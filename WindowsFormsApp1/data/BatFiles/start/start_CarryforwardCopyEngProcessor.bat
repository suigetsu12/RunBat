title CarryforwardCopyEngProcessor
CD ..
call app_config.bat

CD %carryforwardCopyEngProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolPath% host start --port 7074
pause 
