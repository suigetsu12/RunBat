
Publish Main Database from DACPAC
SET deployenv="DEV"
SET MSBuild="C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
SET SQLServerSolution="D:\Projects\SM\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\DatabaseDeployment.sln"
SET Catalog_DACPAC="D:\Projects\SM\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\Catalog\bin\Local\Catalog.dacpac"
SET Core_DACPAC="D:\Projects\SM\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\Core\bin\Local\Core.dacpac"
SET WorkingPaper_DACPAC="D:\Projects\SM\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\WorkingPaper\bin\Local\WorkingPaper.dacpac"

:: Reference to url for more information https://docs.microsoft.com/en-us/sql/tools/sqlpackage?view=sql-server-ver15#publish-parameters-properties-and-sqlcmd-variables
SET SqlPackage="C:\Program Files\Microsoft SQL Server\150\DAC\bin\SqlPackage.exe"

:: Geo information to create login user for Catalog database
SET Geo=ema
SET Geo_Login_Password=xx!

:: Container code information to create login user for Core & WorkingPaper database
SET UserContainerCode=ca
SET Contaner_Login_Password=xx!

:: Container code to create prefix database
SET ContainerCode=AAAAAA

:: SQL Server information
SET SQLServerInstance=localhost,1433
SET SQLServerUsername=sa
SET SQLServerPassword=xx!
@ECHO OFF
REM *** Prepare parameters for executing ***
SET WipeData=True
:: Drop & create new database or just migration True/False
SET CreateNewDatabase=True
REM *** End Prepare parameters for executing ***
ECHO Begin build SQL Server solution
%MSBuild% %SQLServerSolution% -nologo -nr:false -t:rebuild -p:Configuration=Local
ECHO End build SQL Server Projects
ECHO Begin publish to Catalog DB
%SqlPackage% /TargetDatabaseName:Catalog /TargetServerName:%SQLServerInstance% /TargetUser:%SQLServerUsername% /TargetPassword:%SQLServerPassword% /Action:Publish /Properties:CreateNewDatabase=%CreateNewDatabase% /SourceFile:%Catalog_DACPAC% /Variables:deployenv=%deployenv% /Variables:container=%UserContainerCode% /Variables:geo=%Geo% /Variables:WipeData=%WipeData%
ECHO End publish to Catalog DB
ECHO Begin publish to Core DB
%SqlPackage% /TargetDatabaseName:AAAAAACore /TargetServerName:%SQLServerInstance% /TargetUser:%SQLServerUsername% /TargetPassword:%SQLServerPassword% /Action:Publish /Properties:CreateNewDatabase=%CreateNewDatabase% /SourceFile:%Core_DACPAC% /Variables:container=%UserContainerCode% /Variables:WipeData=%WipeData%
ECHO End publish to Core DB
ECHO Begin publish to WorkingPaper DB
%SqlPackage% /TargetDatabaseName:AAAAAAWorkingPaper /TargetServerName:%SQLServerInstance% /TargetUser:%SQLServerUsername% /TargetPassword:%SQLServerPassword% /Action:Publish /Properties:CreateNewDatabase=%CreateNewDatabase% /SourceFile:%WorkingPaper_DACPAC% /Variables:container=%UserContainerCode% /Variables:WipeData=%WipeData%
ECHO End publish to WorkingPaper DB
SET SQLCMD="C:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\SQLCMD.EXE"
SET PATH=C:\Projects\Commercial\6.0\database
SET SERVER="localhost"
SET DB="master"
SET LOGIN="sa"
SET PASSWORD="xx!"
SET INPUT="entity_script.sql"
ECHO Begin add default entity to Core DB
%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -i %INPUT%
ECHO End add default entity to Core DB
@PAUSE
EXIT