title publish_SPO
CD ..
call app_config.bat
@echo on

@echo Publishing SPO Processor...
cd %spo_SPOSetupProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %spo_SPOSetupProcessorOutputUrl%  

pause
