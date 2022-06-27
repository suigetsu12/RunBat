title publish_FileInterityCheck
CD ..
call app_config.bat
@echo on
@echo Publishing File Integrity check Processor...
cd %fileIntegrityCheckProcessorUrl%
dotnet restore
dotnet publish -c Local -o %fileIntegrityCheckProcessorOutputUrl%  
@echo -----------------------------------------------
@echo Publishing File Integrity check Processor...

pause
