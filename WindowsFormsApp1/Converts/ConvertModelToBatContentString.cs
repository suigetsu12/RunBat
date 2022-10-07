using RunBatForm.Extensions;
using RunBatForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static string PathFile(ConfigModel model)
        {
            string str = string.Empty;
            if (model != null)
            {
                string publishPath = Path.Combine(model.Path, model.PublishFolder);
                var _vsArr = model.VsDevCmdPath.Split("\\");
                var _rpsArr = publishPath.Split("\\");
                var _rppArr = model.ProjectFolder.Split("\\");
                var _aftpArr = model.AzureFuncToolPath.Split("\\");
                string msbuildPath = string.Empty;
                string rootPathStart = string.Empty;
                string rootPathProject = string.Empty;
                string azureFunctionToolPath = string.Empty;
                foreach (var _vs in _vsArr)
                {
                    msbuildPath = ConcatStringPath(msbuildPath, _vs);
                }
                foreach (var _rps in _rpsArr)
                {
                    rootPathStart = ConcatStringPath(rootPathStart, _rps);
                }
                foreach (var _rpp in _rppArr)
                {
                    rootPathProject = ConcatStringPath(rootPathProject, _rpp);
                }
                foreach (var _aftp in _aftpArr)
                {
                    azureFunctionToolPath = ConcatStringPath(azureFunctionToolPath, _aftp);
                }
                str += $"@echo off ";
                str += $"\n:: --------------------------- The PATH of project  ----------------------------------------";
                str += $"\nSET rootPathProject={model.ProjectFolder}";
                str += $"\n:: --------------------------- The PATH of Visual Studio  ----------------------------------------";
                str += $"\nSET msbuildPath={msbuildPath}";
                str += $"\n:: --------------------------- The PATH you want to build to   ----------------------------------------";
                str += $"\nSET rootPathStart={rootPathStart}\\";
                str += $"\n:: --------------------------- The PATH of azure function tool   ----------------------------------------";
                str += $"\nSET azureFunctionToolPath={azureFunctionToolPath}";
            }
            return str;
        }

        private static string ConcatStringPath(string root, string newStr)
        {
            if (newStr.Contains(" "))
                root = (root.NotNullOrEmpty()) ? (root + "\\\"" + newStr + "\"") : ("\"" + newStr + "\"");
            else
                root = (root.NotNullOrEmpty()) ? (root + "\\" + newStr) : newStr;
            return root;
        }
    }
}
