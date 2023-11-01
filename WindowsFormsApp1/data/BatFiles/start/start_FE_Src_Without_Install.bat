title FE
CD ..
call app_config.bat

CD %feSourceUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet run -c local --urls "https://devca.auvenir.com/"
pause