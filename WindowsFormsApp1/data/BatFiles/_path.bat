@echo off 

:: --------------------------- The PATH of project  ----------------------------------------
set rootPathProject=C:\Projects\Commercial\6.0\AuvCommercial.Application\
:: --------------------------- The PATH of Visual Studio  ----------------------------------------
set msbuildPath=C:\"Program Files"\"Microsoft Visual Studio"\2022\Enterprise\Common7\Tools\VsDevCmd.bat
:: --------------------------- The PATH you want to build to   ----------------------------------------
set rootPathStart=C:\Projects\Commercial\6.0\publish\
:: --------------------------- The PATH Azure function tool   ----------------------------------------
set azureFunctionToolPath=C:\Users\ADMIN\AppData\Local\AzureFunctionsTools\Releases\4.24.0\cli_x64\func.exe