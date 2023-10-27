title AnnualSnapshotProcessor
CD ..
call app_config.bat
echo %AuvenirAnnualSnapshotProcessorOutputUrl%
CD %AuvenirAnnualSnapshotProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
set AzureWebJobsStorage=UseDevelopmentStorage=true
set AzureWebJobsDashboard=UseDevelopmentStorage=true

%azureFunctionToolPath% host start --port 8081 -c Local
pause 
