using RunBatForm.Constans;
using RunBatForm.Enums;
using RunBatForm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.Helpers
{
    public static class RenderScriptHelper
    {
        public static string DeployOrMigrate(ServerConfigurationModel model, ScriptType type, bool hasCatalog, bool hasCore, bool hasWorkingpaper)
        {
            string str = string.Empty;
            if (model != null)
            {
                string mainOrCf = (type == ScriptType.DEPLOY_MAIN || type == ScriptType.MIGRATE_MAIN) ? "Main" : "CF";
                string cleanData = (type == ScriptType.DEPLOY_MAIN || type == ScriptType.DEPLOY_CF) ? "True" : "False";
                str += $"\nPublish {mainOrCf} Database from DACPAC";
                str += ConfigServer(model, ((type == ScriptType.DEPLOY_MAIN || type == ScriptType.MIGRATE_MAIN) ? ServerType.MAIN : ServerType.CF));
                str += $"\n@ECHO OFF";
                str += $"\nREM *** Prepare parameters for executing ***";
                str += $"\nSET WipeData={cleanData}";
                str += $"\n:: Drop & create new database or just migration True/False";
                str += $"\nSET CreateNewDatabase={cleanData}";
                if (type == ScriptType.MIGRATE_MAIN || type == ScriptType.MIGRATE_CF)
                    str += $"\nSET BlockOnPossibleDataLoss=False";
                str += $"\nREM *** End Prepare parameters for executing ***";
                str += $"\nECHO Begin build SQL Server solution";
                str += $"\n%MSBuild% %SQLServerSolution% -nologo -nr:false -t:rebuild -p:Configuration=Local";
                str += $"\nECHO End build SQL Server Projects";
                if (hasCatalog)
                {
                    str += $"\nECHO Begin publish to Catalog DB";
                    str += $"\n%SqlPackage% /TargetDatabaseName:Catalog /TargetServerName:%SQLServerInstance% /TargetUser:%SQLServerUsername% /TargetPassword:%SQLServerPassword% /Action:Publish /Properties:CreateNewDatabase=%CreateNewDatabase% /SourceFile:%Catalog_DACPAC% /Variables:deployenv=%deployenv% /Variables:container=%UserContainerCode% /Variables:geo=%Geo% /Variables:WipeData=%WipeData%";
                    if (type == ScriptType.MIGRATE_MAIN || type == ScriptType.MIGRATE_CF)
                        str += $"/p:BlockOnPossibleDataLoss=%BlockOnPossibleDataLoss%";
                    str += $"\nECHO End publish to Catalog DB";
                }
                if (hasCore)
                {
                    str += $"\nECHO Begin publish to Core DB";
                    str += $"\n%SqlPackage% /TargetDatabaseName:{model.ContainerCode}Core /TargetServerName:%SQLServerInstance% /TargetUser:%SQLServerUsername% /TargetPassword:%SQLServerPassword% /Action:Publish /Properties:CreateNewDatabase=%CreateNewDatabase% /SourceFile:%Core_DACPAC% /Variables:container=%UserContainerCode% /Variables:WipeData=%WipeData%";
                    if (type == ScriptType.MIGRATE_MAIN || type == ScriptType.MIGRATE_CF)
                        str += $"/p:BlockOnPossibleDataLoss=%BlockOnPossibleDataLoss%";
                    str += $"\nECHO End publish to Core DB";
                }
                if (hasWorkingpaper)
                {
                    str += $"\nECHO Begin publish to WorkingPaper DB";
                    str += $"\n%SqlPackage% /TargetDatabaseName:{model.ContainerCode}WorkingPaper /TargetServerName:%SQLServerInstance% /TargetUser:%SQLServerUsername% /TargetPassword:%SQLServerPassword% /Action:Publish /Properties:CreateNewDatabase=%CreateNewDatabase% /SourceFile:%WorkingPaper_DACPAC% /Variables:container=%UserContainerCode% /Variables:WipeData=%WipeData%";
                    if (type == ScriptType.MIGRATE_MAIN || type == ScriptType.MIGRATE_CF)
                        str += $"/p:BlockOnPossibleDataLoss=%BlockOnPossibleDataLoss%";
                    str += $"\nECHO End publish to WorkingPaper DB";
                }
                if (hasCore && (type == ScriptType.DEPLOY_MAIN || type == ScriptType.DEPLOY_CF))
                {
                    str += Config(model, (type == ScriptType.DEPLOY_MAIN) ? ServerType.MAIN : ServerType.CF);
                    str += $"\nSET INPUT=\"{CommonConstans.ScriptEntityFile}\"";
                    str += $"\nECHO Begin add default entity to Core DB";
                    str += $"\n%SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -i %INPUT%";
                    str += $"\nECHO End add default entity to Core DB";
                }
                str += $"\n@PAUSE";
                str += $"\nEXIT";
            }
            return str;
        }

        private static string Config(ServerConfigurationModel model, ServerType type)
        {
            string str = string.Empty;
            if (model != null)
            {
                var server = (type == ServerType.MAIN) ? model.Main : model.CF;
                str += $"\nSET SQLCMD=\"{model.SQLCMD}\"";
                str += $"\nSET PATH={model.Path}";
                str += $"\nSET SERVER=\"{server.Server}\"";
                str += $"\nSET DB=\"{server.DB}\"";
                str += $"\nSET LOGIN=\"{server.Login}\"";
                str += $"\nSET PASSWORD=\"{server.Password}\"";
            }
            return str;
        }

        private static string ConfigServer(ServerConfigurationModel model, ServerType type)
        {
            string str = string.Empty;
            if (model != null)
            {
                var server = (type == ServerType.MAIN) ? model.Main : model.CF;
                str += $"\nSET deployenv=\"{model.DeployEnv}\"";
                str += $"\nSET MSBuild=\"{model.MsBuild}\"";
                str += $"\nSET SQLServerSolution=\"{model.SQLServerSolution}\"";
                str += $"\nSET Catalog_DACPAC=\"{model.CatalogDACPAC}\"";
                str += $"\nSET Core_DACPAC=\"{model.CoreDACPAC}\"";
                str += $"\nSET WorkingPaper_DACPAC=\"{model.WorkingPaperDACPAC}\"";
                str += $"\n\n:: Reference to url for more information https://docs.microsoft.com/en-us/sql/tools/sqlpackage?view=sql-server-ver15#publish-parameters-properties-and-sqlcmd-variables";
                str += $"\nSET SqlPackage=\"{model.SQLPackage}\"";
                str += $"\n\n:: Geo information to create login user for Catalog database";
                str += $"\nSET Geo={model.GEO}";
                str += $"\nSET Geo_Login_Password={model.GEOPassword}";
                str += $"\n\n:: Container code information to create login user for Core & WorkingPaper database";
                str += $"\nSET UserContainerCode={model.UserContainerCode}";
                str += $"\nSET Contaner_Login_Password={model.ContainerPassword}";
                str += $"\n\n:: Container code to create prefix database";
                str += $"\nSET ContainerCode={model.ContainerCode}";
                str += $"\n\n:: SQL Server information";
                str += $"\nSET SQLServerInstance={server.Server},{server.Port}";
                str += $"\nSET SQLServerUsername={server.Login}";
                str += $"\nSET SQLServerPassword={server.Password}";
            }
            return str;
        }

        public static string ScriptInsertEntity(ServerConfigurationModel model)
        {
            string str = string.Empty;
            if (model != null)
            {
                str += $"\nUSE [{model.ContainerCode}Core]";
                str += $"\nGO ";
                str += $"\nINSERT INTO Entity(Id, Name, IsActive, SiteCollectionUrl)";
                str += $"\nSELECT NEWID(), '{model.Entity.Name}', 1, '{model.Entity.SiteCollectionUrl}'";
                str += $"\nWHERE NOT EXISTS";
                str += $"\n(SELECT 1 FROM Entity WHERE name='{model.Entity.Name}')";
            }
            return str;
        }

        public static string Backup(ServerConfigurationModel model, ScriptType type)
        {
            string str = string.Empty;
            if (model != null)
            {
                str += $"\nTitle Backup_{(type == ScriptType.BACKUP_MAIN ? "Main" : "CF")}";
                str += Config(model, (type == ScriptType.BACKUP_MAIN) ? ServerType.MAIN : ServerType.CF);
                str += $"\nSET INPUT=\"{CommonConstans.ScriptBackupFile}\"";
                str += $"\nECHO %SQLCMD% -S %SERVER% -d %DB% -U %LOGIN% -P %PASSWORD% -v path =\"N'%PATH%\'\" -i %INPUT%";
                str += $"\n@pause";
                str += $"\nexit";
            }
            return str;
        }

        public static string ScriptBackup(ServerConfigurationModel model, ServerType serverType)
        {
            string str = string.Empty;
            if (model != null)
            {
                str += $"\nDECLARE @name VARCHAR(50) -- database name ";
                str += $"\nDECLARE @path VARCHAR(256) -- path for backup files  ";
                str += $"\nDECLARE @fileName VARCHAR(256) -- filename for backup  ";
                str += $"\nDECLARE @fileDate VARCHAR(20) -- used for file name";
                str += $"\nSET @path = $(path)";
                str += $"\nDECLARE db_cursor CURSOR READ_ONLY FOR ";
                str += $"\nSELECT name ";
                str += $"\nFROM master.sys.databases ";
                str += $"\nWHERE name  IN ('Catalog','{model.ContainerCode}Core','{model.ContainerCode}WorkingPaper')  -- exclude these databases";
                str += $"\nOPEN db_cursor";
                str += $"\nFETCH NEXT FROM db_cursor INTO @name";
                str += $"\nWHILE @@FETCH_STATUS = 0";
                str += $"\nBEGIN";
                str += $"\nSET @fileName = @path + @name + '{(serverType == ServerType.CF ? "CF" : "")}.BAK'";
                str += $"\nBACKUP DATABASE @name TO DISK = @fileName";
                str += $"\nFETCH NEXT FROM db_cursor INTO @name";
                str += $"\nEND";
                str += $"\nCLOSE db_cursor ";
                str += $"\nDEALLOCATE db_cursor";
            }
            return str;
        }
    }
}
