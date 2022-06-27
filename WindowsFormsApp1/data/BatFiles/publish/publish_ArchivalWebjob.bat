title publish__ArchiveWebjob 
CD ..
call app_config.bat

@echo Publishing ArchiveWebjob ...
cd %archiveSourceUrl%
dotnet restore
dotnet publish -c Local -o %archiveOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing ArchiveAPI ...
cd %archiveApiSourceUrl%
call %msbuildPath%
msbuild Auvenir.Archiving.WebAPI.csproj /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=%archiveApiOutputUrl%
@echo Publish successfully
@echo -----------------------------------------------
pause
