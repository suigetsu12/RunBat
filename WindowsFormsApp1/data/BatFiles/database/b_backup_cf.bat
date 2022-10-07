Title Backup_CF
call a_configcf.bat
SET INPUT="script_backup_cf.sql"

ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -v path ="N'%PATH%\'" -i %INPUT%

@pause
exit
