title FE Publish
CD ..
call app_config.bat

CD %feOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet AuvenirNetCore.dll run --urls "https://dev.caauvenir.com"
pause