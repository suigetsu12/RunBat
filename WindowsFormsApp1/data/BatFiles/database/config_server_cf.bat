set deployenv="DEV"

set MSBuild="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"

set SQLServerSolution="C:\Projects\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\DatabaseDeployment.sln"

set Catalog_DACPAC="C:\Projects\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\Catalog\bin\Local\Catalog.dacpac"

set Core_DACPAC="C:\Projects\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\Core\bin\Local\Core.dacpac"

set WorkingPaper_DACPAC="C:\Projects\Commercial\6.0\AuvCommercial.SQLDB\DatabaseDeployment\WorkingPaper\bin\Local\WorkingPaper.dacpac"
:: Reference to url for more information https://docs.microsoft.com/en-us/sql/tools/sqlpackage?view=sql-server-ver15#publish-parameters-properties-and-sqlcmd-variables

set SqlPackage="C:\Program Files\Microsoft SQL Server\150\DAC\bin\SqlPackage.exe"

:: Geo information to create login user for Catalog database

set Geo=ema

set Geo_Login_Password=xx!

:: Container code information to create login user for Core & WorkingPaper database

set UserContainerCode=ca

set Contaner_Login_Password=xx!

:: Container code to create prefix database

set ContainerCode=AAAAAA

:: SQL Server information

set SQLServerInstance=localhost,1434

set SQLServerUsername=sa

set SQLServerPassword=xx!