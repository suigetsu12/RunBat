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
            string str = string.Empty;
            if (model != null)
            {
                str += $"set deployenv=\"{model.DeployEnv}\"";
                str += $"\nset MSBuild=\"{model.MsBuild}\"";
                str += $"\nset SQLServerSolution=\"{model.SQLServerSolution}\"";
                str += $"\nset Catalog_DACPAC=\"{model.CatalogDACPAC}\"";
                str += $"\nset Core_DACPAC=\"{model.CoreDACPAC}\"";
                str += $"\nset WorkingPaper_DACPAC=\"{model.WorkingPaperDACPAC}\"";
                str += $"\n\n:: Reference to url for more information https://docs.microsoft.com/en-us/sql/tools/sqlpackage?view=sql-server-ver15#publish-parameters-properties-and-sqlcmd-variables";
                str += $"\nset SqlPackage=\"{model.SQLPackage}\"";
                str += $"\n\n:: Geo information to create login user for Catalog database";
                str += $"\nset Geo={model.GEO}";
                str += $"\nset Geo_Login_Password={model.GEOPassword}";
                str += $"\n\n:: Container code information to create login user for Core & WorkingPaper database";
                str += $"\nset UserContainerCode={model.UserContainerCode}";
                str += $"\nset Contaner_Login_Password={model.ContainerPassword}";
                str += $"\n\n:: Container code to create prefix database";
                str += $"\nset ContainerCode={model.ContainerCode}";
                str += $"\n\n:: SQL Server information";
                str += $"\nset SQLServerInstance={model.Server},{model.Port}";
                str += $"\nset SQLServerUsername={model.Login}";
                str += $"\nset SQLServerPassword={model.Password}";
            }
            return str;
        }

        public static string ConfigShortServer(ServerConfigurationModel model, string path)
        {
            string str = string.Empty;
            if (model != null)
            {
                str += $"SET SQLCMD=\"{model.SQLCMD}\"";
                str += $"\nSET PATH={path}";
                str += $"\nSET SERVER=\"{model.Server}\"";
                str += $"\nSET DB=\"master\"";
                str += $"\nSET LOGIN=\"{model.Login}\"";
                str += $"\nSET PASSWORD=\"{model.Password}\"";
            }
            return str;
        }
    }
}
