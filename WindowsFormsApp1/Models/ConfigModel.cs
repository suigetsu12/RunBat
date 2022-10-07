using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RunBatForm.Models
{
    public class ConfigModel
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("publish_folder")]
        public string PublishFolder { get;set; }

        [JsonPropertyName("backup_data_folder")]
        public string BackupDataFolder { get; set; }

        [JsonPropertyName("app_config")]
        public string AppConfig { get; set; }

        [JsonPropertyName("project_folder")]
        public string ProjectFolder { get; set; }

        [JsonPropertyName("database_project_folder")]
        public string DatabaseProjectFolder { get; set; }

        [JsonPropertyName("VsDevCmd_path")]
        public string VsDevCmdPath { get; set; }

        [JsonPropertyName("MsBuils_path")]
        public string MSBuildPath { get; set; }

        [JsonPropertyName("azureFuncTool_path")]
        public string AzureFuncToolPath { get; set; }
    }
}
