title publish_Archive_Feature
CD ..
call app_config.bat
@echo on
@echo .... PUBLISHING ARCHIVE FEATURE ....

@echo -----------------------------------------------

rem @echo 1/  PUBLISH Archive Webjob...
rem @echo 2/  PUBLISH Archive API ...

@echo Publishing ArchiveWebjob...
cd %archiveSourceUrl%
dotnet restore
dotnet publish -c Local -o %archiveOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing ArchiveAPI ...
cd %archiveApiSourceUrl%
dotnet restore
dotnet publish -c Local -o %archiveApiOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------
pause


