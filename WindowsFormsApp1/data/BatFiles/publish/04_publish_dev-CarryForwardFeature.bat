title publish_Carry_Forward_Feature
CD ..
call app_config.bat
@echo on
@echo .... PUBLISHING CARRYFORWARD FEATURE ....

@echo -----------------------------------------------

rem @echo 1/  PUBLISH Carryfoward Processor...
rem @echo 2/  PUBLISH Carryfoward Content Processor ...
rem @echo 3/  PUBLISH Carryfoward Copy ENG Processor ...
rem @echo 4/  PUBLISH Carryfoward File Transfer Processor ...

@echo Publishing CarryfowardProcessor...
cd %carryforwardProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing CarryfowardContentProcessor...
cd %carryforwardContentProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardContentProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing CarryfowardCopyENGProcessor...
cd %carryforwardCopyEngProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardCopyEngProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

@echo Publishing CarryfowardFileTransferProcessor...
cd %carryforwardFileTransferProcessorSourceUrl%
dotnet restore
dotnet publish -c Local -o %carryforwardFileTransferProcessorOutputUrl%  
@echo Publish successfully
@echo -----------------------------------------------

pause