title SPOSetupProcessor
CD ..
call app_config.bat

CD %spo_SPOSetupProcessorOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
run.cmd
pause 