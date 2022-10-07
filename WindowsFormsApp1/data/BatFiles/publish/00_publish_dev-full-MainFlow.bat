title publish_Full_Main_Flow
CD ..
call app_config.bat
@echo on
@echo .... PUBLISHING AUVENIR PROJECT ....

@echo -----------------------------------------------

rem @echo 1/  PUBLISH CORE Service...
rem @echo 2/  PUBLISH Planning Step...
rem @echo 3/  PUBLISH Non Account Working Paper Service...
rem @echo 4/  PUBLISH Common Tool Service...
rem @echo 5/  PUBLISH Account Working Paper Service...
rem @echo 7/  PUBLISH File Services...
rem @echo 8/  PUBLISH SPO Processor...
rem @echo 9/  PUBLISH File Integrity check Processor...
rem @echo 10/ PUBLISH Archive Webjob...
rem @echo 12/ PUBLISH Component Creation Processor...
rem @echo 13/ PUBLISH SPO API...

@echo Publishing CORE ...
cd %coreSourceUrl%
dotnet restore
dotnet publish -c Local -o %coreOutputUrl% /property:langversion=latest
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing PlanningStep ...
CD %pm_psSourceUrl%
dotnet restore
dotnet publish -c Local -o %pm_psOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing NonAccountWorkingPaperService ...
CD %pm_vsaSourceUrl%
dotnet restore
dotnet publish -c Local -o %pm_vsaOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing CommonToolService ...
CD %pm_snSourceUrl%
dotnet restore
dotnet publish -c Local -o %pm_snOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing AccountWorkingPaperService ...
CD %wpSourceUrl%
dotnet restore
dotnet publish -c Local -o %wpOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing FileServices ...
CD %fsSourceUrl%
dotnet restore
dotnet publish -c Local -o %fsOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing SPO Processor ...
cd %spo_SPOSetupProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %spo_SPOSetupProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing File Integrity Check Processor ...
cd %fileIntegrityCheckProcessorUrl%
dotnet restore
dotnet publish -c Local -o %fileIntegrityCheckProcessorOutputUrl% /property:langversion=latest
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing ArchiveWebjob ...
cd %archiveSourceUrl%
dotnet restore
dotnet publish -c Local -o %archiveOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing ComponentCreationProcessor ...
CD %ComponentCreationProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %ComponentCreationProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing SPOAPI ...
CD %spoApiSourceUrl%
dotnet restore
dotnet publish -c Local -o %spoApiOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing EngagementCreationProcessor ...
CD %EngagementCreationProcessorUrl%
dotnet restore
dotnet publish -c Local -o %EngagementCreationProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing WpGenerationProcessor ...
CD %WpGenerationProcessorUrl%
dotnet restore
dotnet publish -c Local -o %WpGenerationProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing ContentProcessor...
CD %contentProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %contentProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing ArchiveAPI ...
cd %archiveApiSourceUrl%
dotnet restore
dotnet publish -c Local -o %archiveApiOutputUrl%
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing IntegrationHubService ...
CD %IntegrationHubServiceUrl%
dotnet restore
dotnet publish -c Local -o %integrationHubOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing AuvenirIntegrationHubProcessor ...
CD %AuvenirIntegrationHubProcessorUrl%
dotnet restore
dotnet publish -c Local -o %AuvenirIntegrationHubProcessorOutputUrl%  
@echo Publish successfully---------------------------------------

pause