CD ..
call app_config.bat
@echo Publishing AccountWorkingPaperService ...
CD %wpSourceUrl%
dotnet restore
dotnet publish -c Local -o %wpOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause
