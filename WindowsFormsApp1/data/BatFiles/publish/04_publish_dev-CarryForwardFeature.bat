title publish_Carry_Forward_Feature
CD ..
call app_config.bat
@echo on

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