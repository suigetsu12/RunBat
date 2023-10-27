namespace RunBatForm.Constans
{
    public class ScriptPath
    {
        public const string ScriptDatabase = "data\\scripts\\database";
        public const string ScriptPublish = "data\\scripts\\publish";
        public const string ScriptStart = "data\\scripts\\start";
        public class Database
        {
            public const string ScriptRun = ScriptDatabase + "\\script_run.bat";

            public const string InsertEntity = ScriptDatabase + "\\entity_script.sql";

            public const string Backup = ScriptDatabase + "\\backup_script.sql";

            public const string Restore = ScriptDatabase + "\\restore_script.sql";

            public const string Drop = ScriptDatabase + "\\drop_script.sql";
        }

        public class Publish
        {
            public const string AppConfig = ScriptPublish + "\\app_config.bat";
        }

        public class Start
        {
            public const string AppConfig = ScriptStart + "\\app_config.bat";
        }
    }

    public class FilePath
    {
        public const string RootConfig = "data\\configs";
        public const string Configuration = RootConfig + "\\config.json";
        public const string DataStartPath = RootConfig + "\\dataStart.json";
        public const string DataPublishPath = RootConfig + "\\dataPublish.json";
        public const string DataDatabasePath = RootConfig + "\\dataDatabase.json";
        public const string ConfigDatabasePath = RootConfig + "\\configDatabase.json";
    }

    public class DatabaseSolution
    {
        public const string Root = "DatabaseDeployment";
        public const string Solution = Root + "\\DatabaseDeployment.sln";
        public const string CatalogDACPAC = Root + "\\Catalog\\bin\\Local\\Catalog.dacpac";
        public const string CoreDACPAC = Root + "\\Core\\bin\\Local\\Core.dacpac";
        public const string WorkingPaperDACPAC = Root + "\\WorkingPaper\\bin\\Local\\WorkingPaper.dacpac";
    }

    public class BatPath
    {
        public const string RootFolder = "data\\BatFiles";
        public const string PathBat = RootFolder + "\\_path.bat";
        public const string StartFolderPath = RootFolder + "\\start";
        public const string PublishFolderPath = RootFolder + "\\publish";
        public const string DatabaseFolderPath = RootFolder + "\\database";

        public class Config
        {
            public const string ConfigServerMain = DatabaseFolderPath + "\\config_server_main.bat";
            public const string ConfigServerCF = DatabaseFolderPath + "\\config_server_cf.bat";
            public const string ConfigServerShortMain = DatabaseFolderPath + "\\a_config.bat";
            public const string ConfigServerShortCF = DatabaseFolderPath + "\\a_configcf.bat";
        }
    }

    public class RootPath
    {
        public const string Root = "data";

        public class Configs
        {
            public const string RootConfigFolder = Root + "\\configs";
            public const string Config = RootConfigFolder + "\\config.json";
            public const string DataDatabasePublish = RootConfigFolder + "\\dataDatabasePublish.json";
            public const string DataPublish = RootConfigFolder + "\\dataPublish.json";
            public const string DataStart = RootConfigFolder + "\\dataStart.json";
        }

        public class BatFiles
        {
            public const string RootBatFolder = Root + "\\bat_files";
            public const string Path = RootBatFolder + "\\_path.bat";
            public const string AppConfig = RootBatFolder + "\\app_config.bat";
            public class Database
            {
                public const string RootDatabaseFolder = RootBatFolder + "\\database";

                public const string MainServerConfig = RootDatabaseFolder + "\\0_main_sv_config.bat";//config_server_main.bat
                public const string CFServerConfig = RootDatabaseFolder + "\\0_cf_sv_config.bat";//config_server_cf.bat

                public const string MainConfig = RootDatabaseFolder + "\\1_main_config.bat";//a_config.bat
                public const string CFConfig = RootDatabaseFolder + "\\1_cf_config.bat";//a_configcf.bat

                public const string BackupFull = RootDatabaseFolder + "\\2_backup_full.bat";//00_backup.bat
                public const string RestoreFull = RootDatabaseFolder + "\\2_restore_full.bat";//00_restore_db.bat

                public const string MainBackup = RootDatabaseFolder + "\\3_main_backup.bat";//a_backup.bat
                public const string CFBackup = RootDatabaseFolder + "\\3_cf_backup.bat";//b_backup_cf.bat

                public const string MainRestore = RootDatabaseFolder + "\\4_main_restore.bat";//a_restore.bat
                public const string CFRestore = RootDatabaseFolder + "\\4_cf_restore.bat";//b_restore_cf.bat

                public const string MainDeploy = RootDatabaseFolder + "\\5_main_deploy.bat";//deploy_main_db.bat
                public const string CFDeploy = RootDatabaseFolder + "\\5_cf_deploy.bat";//deploy_cf_db.bat

                public const string MainMigrate = RootDatabaseFolder + "\\6_main_deploy.bat";//migrate_main_db.bat
                public const string CFMigrate = RootDatabaseFolder + "\\6_cf_deploy.bat";//migrate_cf_db.bat

                public const string MainDrop = RootDatabaseFolder + "\\7_main_drop.bat";//a_drop_database.bat
                public const string CFDrop = RootDatabaseFolder + "\\7_cf_drop.bat";//b_drop_database_cf.bat

                public const string MainScriptBackup = RootDatabaseFolder + "\\main_script_backup.sql";//script_backup.sql
                public const string CFScriptBackup = RootDatabaseFolder + "\\cf_script_backup.sql";//script_backup_cf.sql

                public const string MainScriptRestore = RootDatabaseFolder + "\\main_script_restore.sql";//script_restore.sql
                public const string CFScriptRestore = RootDatabaseFolder + "\\cf_script_restore.sql";//script_restore_cf.sql

                public const string ScriptDrop = RootDatabaseFolder + "\\script_drop.sql";//script_drop.sql
            }

            public class Publish
            {
                public const string RootPublishFolder = RootBatFolder + "\\publish";
                public const string PreFix = "publish_";
                public const string AccountWorkingPaperService = RootPublishFolder + "\\" + PreFix + "AccountWorkingPaperService.bat";
                public const string ArchiveAPI = RootPublishFolder + "\\" + PreFix + "ArchiveAPI.bat";
                public const string SPOAPI = RootPublishFolder + "\\" + PreFix + "SPOAPI.bat";
                public const string ArchivalWebjob = RootPublishFolder + "\\" + PreFix + "ArchivalWebjob.bat";
                public const string CommonToolService = RootPublishFolder + "\\" + PreFix + "CommonToolService.bat";
                public const string ComponentCreationProcessor = RootPublishFolder + "\\" + PreFix + "ComponentCreationProcessor.bat";
                public const string ContentProcessor = RootPublishFolder + "\\" + PreFix + "ContentProcessor.bat";
                public const string Core = RootPublishFolder + "\\" + PreFix + "Core.bat";
                public const string EngagementCreationProcessor = RootPublishFolder + "\\" + PreFix + "EngagementCreationProcessor.bat";
                public const string FE = RootPublishFolder + "\\" + PreFix + "FE.bat";
                public const string FileInterityCheck = RootPublishFolder + "\\" + PreFix + "FileInterityCheck.bat";
                public const string FileService = RootPublishFolder + "\\" + PreFix + "FileService.bat";
                public const string NonAccountWp = RootPublishFolder + "\\" + PreFix + "NonAccountWp.bat";
                public const string Planning = RootPublishFolder + "\\" + PreFix + "Planning.bat";
                public const string SPO = RootPublishFolder + "\\" + PreFix + "SPO.bat";
                public const string WpGenerationProcessor = RootPublishFolder + "\\" + PreFix + "WpGenerationProcessor.bat";
            }

            public class Start
            {
                public const string RootStartFolder = RootBatFolder + "\\start";
                public const string PreFix = "start_";
                public const string AccountWorkingPaperService = RootStartFolder + "\\" + PreFix + "AccountWorkingPaperService.bat";
                public const string ArchivalWebAPI = RootStartFolder + "\\" + PreFix + "ArchivalWebAPI.bat";
                public const string ArchivalWebjob = RootStartFolder + "\\" + PreFix + "ArchivalWebjob.bat";
                public const string DuplicateEngCommon = RootStartFolder + "\\" + PreFix + "DuplicateEngCommon.bat";
                public const string DuplicateEngProcessor = RootStartFolder + "\\" + PreFix + "DuplicateEngProcessor.bat";
                public const string DuplicateFileProcessor = RootStartFolder + "\\" + PreFix + "DuplicateFileProcessor.bat";
                public const string CarryforwardContentProcessor = RootStartFolder + "\\" + PreFix + "CarryforwardContentProcessor.bat";
                public const string CarryforwardCopyEngProcessor = RootStartFolder + "\\" + PreFix + "CarryforwardCopyEngProcessor.bat";
                public const string CarryforwardFileTransferProcessor = RootStartFolder + "\\" + PreFix + "CarryforwardFileTransferProcessor.bat";
                public const string CarryforwardProcessor = RootStartFolder + "\\" + PreFix + "CarryforwardProcessor.bat";
                public const string CommonToolService = RootStartFolder + "\\" + PreFix + "CommonToolService.bat";
                public const string ComponentCreationProcessor = RootStartFolder + "\\" + PreFix + "ComponentCreationProcessor.bat";
                public const string ContentProcessor = RootStartFolder + "\\" + PreFix + "ContentProcessor.bat";
                public const string Core = RootStartFolder + "\\" + PreFix + "Core.bat";
                public const string EngagementCreationProcessor = RootStartFolder + "\\" + PreFix + "EngagementCreationProcessor.bat";
                public const string FE = RootStartFolder + "\\" + PreFix + "FE.bat";
                public const string FESrc = RootStartFolder + "\\" + PreFix + "FESrc.bat";
                public const string FileIntegrityCheckProcessor = RootStartFolder + "\\" + PreFix + "FileIntegrityCheckProcessor.bat";
                public const string FileService = RootStartFolder + "\\" + PreFix + "FileService.bat";
                public const string HouseKeeper = RootStartFolder + "\\" + PreFix + "HouseKeeper.bat";
                public const string NonAccountWorkingPaperService = RootStartFolder + "\\" + PreFix + "NonAccountWorkingPaperService.bat";
                public const string Planning = RootStartFolder + "\\" + PreFix + "Planning.bat";
                public const string SPOAPI = RootStartFolder + "\\" + PreFix + "SPOAPI.bat";
                public const string SPOSetupProcessor = RootStartFolder + "\\" + PreFix + "SPOSetupProcessor.bat";
                public const string WpGenerationProcessor = RootStartFolder + "\\" + PreFix + "WpGenerationProcessor.bat";
            }
        }
    }
}
