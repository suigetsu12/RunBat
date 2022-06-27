title publish_core
CD ..
call app_config.bat
@echo on
@echo Publishing core project....

@echo -----------------------------------------------

@echo Publishing CORE...
cd %coreSourceUrl%
dotnet restore
dotnet publish -c Local -o %coreOutputUrl% /property:langversion=latest
@echo Publish successfully
@echo -----------------------------------------------
pause
