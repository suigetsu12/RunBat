title WpGenerationProcessor
CD ..
call app_config.bat

CD %WpGenerationProcessorOutputUrl%

set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolPath% host start  --port 7086 -c Local
pause 