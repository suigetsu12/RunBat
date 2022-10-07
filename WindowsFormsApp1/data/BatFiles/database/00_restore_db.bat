Title Restore_DB

call a_config.bat
SET INPUT="script_drop.sql"
ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -i %INPUT%
@echo drop main success
@echo -----------------------------------------------
call a_configcf.bat
SET INPUT="script_drop.sql"
ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -i %INPUT%
@echo drop cf success
@echo -----------------------------------------------
call a_config.bat

SET INPUT="script_restore.sql"

ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -v path ="N'%PATH%\'" -i %INPUT%
@echo restore main success
@echo -----------------------------------------------

call a_configcf.bat

SET INPUT="script_restore_cf.sql"

ECHO 
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -v path ="N'%PATH%\'" -i %INPUT%
@echo restore cf success
@echo -----------------------------------------------
@pause
exit
