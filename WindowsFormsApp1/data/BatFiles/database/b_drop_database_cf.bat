call a_configcf.bat
SET INPUT="script_drop.sql"
ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -i %INPUT%

@pause
exit
