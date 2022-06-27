namespace RunBatForm.Constans
{
    public class FilePath
    {
        public const string RootConfig = "data\\configs";
        public const string Configuration = RootConfig + "\\config.json";
        public const string DataStartPath = RootConfig + "\\dataStart.json";
        public const string DataPublishPath = RootConfig + "\\dataPublish.json";
        public const string DataDatabasePath = RootConfig + "\\dataDatabase.json";
    }

    public class BatPath
    {
        public const string RootFolder = "data\\BatFiles";
        public const string PathBat = RootFolder + "\\_path.bat";
        public const string StartFolderPath = RootFolder + "\\start";
        public const string PublishFolderPath = RootFolder + "\\publish";
        public const string DatabaseFolderPath = RootFolder + "\\database";
    }
}
