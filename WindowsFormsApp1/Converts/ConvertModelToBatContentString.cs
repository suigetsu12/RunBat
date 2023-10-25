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
