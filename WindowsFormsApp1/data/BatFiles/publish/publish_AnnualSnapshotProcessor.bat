title publish_AnnualSnapshotProcessor
CD ..
call app_config.bat
@echo on
@echo Publishing AnnualSnapshotProcessor project....


@echo Publishing AuvenirAnnualSnapshotProcessorOutputUrl...

CD %AuvenirAnnualSnapshotProcessorUrl%
dotnet restore
dotnet publish -c Local -o %AuvenirAnnualSnapshotProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause
