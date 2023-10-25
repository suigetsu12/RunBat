using System.Text.Json.Serialization;

namespace RunBatForm.Models
{
    public class ServerConfigurationModel
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("sqlcmd")]
        public string SQLCMD { get; set; }

        [JsonPropertyName("geo")]
        public string GEO { get; set; }

        [JsonPropertyName("geo_password")]
        public string GEOPassword { get; set; }

        [JsonPropertyName("user_container_code")]
        public string UserContainerCode { get; set; }

        [JsonPropertyName("container_password")]
        public string ContainerPassword { get; set; }

        [JsonPropertyName("container_code")]
        public string ContainerCode { get; set; }

        [JsonPropertyName("sql_server_solution")]
        public string SQLServerSolution { get; set; }

        [JsonPropertyName("catalog_dacpac")]
        public string CatalogDACPAC { get; set; }

        [JsonPropertyName("core_dacpac")]
        public string CoreDACPAC { get; set; }

        [JsonPropertyName("workingpaper_dacpac")]
        public string WorkingPaperDACPAC { get; set; }

        [JsonPropertyName("sql_package")]
        public string SQLPackage { get; set; }

        [JsonPropertyName("deployenv")]
        public string DeployEnv { get; set; }

        [JsonPropertyName("msbuild")]
        public string MsBuild { get; set; }

        [JsonPropertyName("main")]
        public ServerModel Main { get; set; }

        [JsonPropertyName("cf")]
        public ServerModel CF { get; set; }

        [JsonPropertyName("entity")]
        public EntityModel Entity { get; set; }
    }

    public class ServerModel
    {
        [JsonPropertyName("server")]
        public string Server { get; set; }

        [JsonPropertyName("db")]
        public string DB { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }
    }

    public class EntityModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("siteCollectionUrl")]
        public string SiteCollectionUrl { get; set; }
    }
}
