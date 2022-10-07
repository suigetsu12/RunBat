Title Migrate CF Database from DACPAC
call config_server_cf.bat
@ECHO OFF

REM *** Prepare parameters for executing ***



set WipeData=False

:: Drop & create new database or just migration True/False

set CreateNewDatabase=False

set BlockOnPossibleDataLoss=False

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


@pause

exit