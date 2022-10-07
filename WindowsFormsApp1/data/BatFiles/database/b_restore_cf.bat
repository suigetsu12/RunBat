Title Restore_CF

call a_configcf.bat

SET INPUT="script_restore_cf.sql"

ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -v path ="N'%PATH%\'" -i %INPUT%

@pause
exit
