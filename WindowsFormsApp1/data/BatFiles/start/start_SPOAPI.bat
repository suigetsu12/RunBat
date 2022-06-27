title SPOApi
CD ..
call app_config.bat

CD %spoApiOutputUrl%
set ASPNETCORE_ENVIRONMENT=Local
dotnet SPOApi.dll run --urls "http://cacaudspoapi.auvnpd02.ase.dmchosting.ca:900"
pause