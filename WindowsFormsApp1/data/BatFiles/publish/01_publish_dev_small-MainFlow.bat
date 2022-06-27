title publish_Small_Main_Flow
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


pause