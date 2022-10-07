title publish_Full_Flow
CD ..
call app_config.bat
@echo on
@echo .... PUBLISHING AUVENIR PROJECT ....

@echo -----------------------------------------------

rem @echo 1/  PUBLISH Core Service...
rem @echo 2/  PUBLISH Planning Step...
rem @echo 3/  PUBLISH Non Account Working Paper Service...
rem @echo 4/  PUBLISH Common Tool Service...
rem @echo 5/  PUBLISH Account Working Paper Service...
rem @echo 6/  PUBLISH File Services...
rem @echo 7/  PUBLISH SPO Processor...
rem @echo 8/  PUBLISH File Integrity check Processor...
rem @echo 9/  PUBLISH Archive Webjob...
rem @echo 10/ PUBLISH SPO API...
rem @echo 11/ PUBLISH ContentProcessor...
rem @echo 12/ PUBLISH ArchiveAPI...
rem @echo 13/ PUBLISH CarryfowardProcessor...
rem @echo 14/ PUBLISH CarryfowardContentProcessor...
rem @echo 15/ PUBLISH CarryfowardCopyENGProcessor...
rem @echo 16/ PUBLISH CarryfowardFileTransferProcessor...
rem @echo 17/ PUBLISH AuvenirDuplicateEngCommon...
rem @echo 18/ PUBLISH AuvenirDuplicateEngProcessor...
rem @echo 19/ PUBLISH AuvenirDuplicateFileProcessor...
rem @echo 23/ PUBLISH IntegrationHubService...
rem @echo 24/ PUBLISH AuvenirIntegrationHubProcessor...

@echo Publishing CoreService ...
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

@echo Publishing SPOAPI ...
CD %spoApiSourceUrl%
dotnet restore
dotnet publish -c Local -o %spoApiOutputUrl%  
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

@echo Publishing CarryfowardProcessor...
cd %carryforwardProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing CarryfowardContentProcessor...
cd %carryforwardContentProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardContentProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing CarryfowardCopyENGProcessor...
cd %carryforwardCopyEngProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardCopyEngProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing CarryfowardFileTransferProcessor...
cd %carryforwardFileTransferProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardFileTransferProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing AuvenirDuplicateEngCommon ...
cd %AuvenirDuplicateEngCommonUrl%
dotnet restore
dotnet publish -c Local -o %AuvenirDuplicateEngCommonOutputUrl% /property:langversion=latest
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing AuvenirDuplicateEngProcessor ...
CD %AuvenirDuplicateEngProcessorUrl%
dotnet restore
dotnet publish -c Local -o %AuvenirDuplicateEngProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing AuvenirDuplicateFileProcessor ...
CD %AuvenirDuplicateFileProcessorUrl%
dotnet restore
dotnet publish -c Local -o %AuvenirDuplicateFileProcessorOutputUrl%  
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