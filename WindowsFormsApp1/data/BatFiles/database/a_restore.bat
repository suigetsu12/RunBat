Title Restore_Main

call a_config.bat

SET INPUT="script_restore.sql"

ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -v path ="N'%PATH%\'" -i %INPUT%

@pause
exit
