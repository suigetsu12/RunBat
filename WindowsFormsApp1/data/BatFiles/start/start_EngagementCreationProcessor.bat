title EngagementCreationProcessor
CD ..
call app_config.bat

CD %EngagementCreationProcessorOutputUrl%

set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolPath% host start  --port 7085 -c Local
pause 