title ContentProcessor
CD ..
call app_config.bat

CD %contentProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolNet6Path% host start --port 7079 -c Local
pause 
