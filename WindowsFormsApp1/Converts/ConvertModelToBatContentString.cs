using RunBatForm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.Converts
{
    public static class ConvertModelToBatContentString
    {
        public static string ConfigServer(ServerConfigurationModel model)
        {
            string result = string.Empty;
            if (model != null)
            {
                result += $"set deployenv=\"{model.DeployEnv}\"";
                result += $"\n set MSBuild=\"{model.MsBuild}\"";
                result += $"\n set SQLServerSolution=\"{model.SQLServerSolution}\"";
                result += $"\n set Catalog_DACPAC=\"{model.CatalogDACPAC}\"";
                result += $"\n set Core_DACPAC=\"{model.CoreDACPAC}\"";
                result += $"\n set WorkingPaper_DACPAC=\"{model.WorkingPaperDACPAC}\"";
                result += $"\n set SqlPackage=\"{model.SQLPackage}\"";
                result += $"\n set Geo={model.GEO}";
                result += $"\n set Geo_Login_Password={model.GEOPassword}";
                result += $"\n set UserContainerCode={model.UserContainerCode}";
                result += $"\n set Contaner_Login_Password={model.ContainerPassword}";
                result += $"\n set ContainerCode={model.ContainerCode}";
                result += $"\n set SQLServerInstance={model.Server},{model.Port}";
                result += $"\n set SQLServerUsername={model.Login}";
                result += $"\n set SQLServerPassword={model.Password}";
            }
            return result;
        }
    }
}
