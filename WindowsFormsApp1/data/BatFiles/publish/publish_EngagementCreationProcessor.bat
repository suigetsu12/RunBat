title publish_EngagementCreationProcessor
CD ..
call app_config.bat
@echo on
@echo Publishing workingpaper project....


@echo Publishing EngagementCreationProcessorOutputUrl...

CD %EngagementCreationProcessorUrl%
dotnet restore
dotnet publish -c Local -o %EngagementCreationProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause
