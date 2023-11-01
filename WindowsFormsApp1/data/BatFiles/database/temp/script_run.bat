Title Restore_Main
SET SQLCMD="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE"
SET PATH=C:\Projects\Commercial\6.0\database
SET SERVER="HIEU-VAN-0273\MAIN"
SET DB="master"
SET LOGIN="sa"
SET PASSWORD="xx!"
SET INPUT="restore_script.sql"
ECHO
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -v path ="N'%PATH%\'" -i %INPUT%
@pause
exit