title publish_WpGenerationProcessor
CD ..
call app_config.bat
@echo on
@echo Publishing workingpaper project....


@echo Publishing ComponentCreationProcessorOutputUrl...

CD %WpGenerationProcessorUrl%
dotnet restore
dotnet publish -c Local -o %WpGenerationProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause
