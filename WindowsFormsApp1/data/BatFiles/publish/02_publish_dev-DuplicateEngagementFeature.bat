title publish_Duplicate_Engagement_Feature
CD ..
call app_config.bat
@echo on
@echo .... PUBLISHING DUPLICATE FEATURE ....

@echo -----------------------------------------------

rem @echo 1/  PUBLISH Auvenir Duplicate Eng Common...
rem @echo 2/  PUBLISH Auvenir Duplicate Eng Processor ...
rem @echo 3/  PUBLISH Auvenir Duplicate File Processor ...

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

pause