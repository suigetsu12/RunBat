title publish_ComponentCreationProcessor
CD ..
call app_config.bat
@echo on
@echo Publishing workingpaper project....


@echo Publishing ComponentCreationProcessorOutputUrl...

CD %ComponentCreationProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %ComponentCreationProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause
