title publish_Planning
CD ..
call app_config.bat
@echo Publishing PlanningStep ...
CD %pm_psSourceUrl%
dotnet restore
dotnet publish -c Local -o %pm_psOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------


pause
