title publish__ArchiveAPI
CD ..
call app_config.bat
cd..
cd %archiveApiSourceUrl%
dotnet restore
dotnet publish -c Local -o %archiveApiOutputUrl%
pause
