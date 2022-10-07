using RunBatForm.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.Helpers
{
    public static class StringHelper
    {
        public static string RefactorPathContainSpace(string pathStr)
        {
            string newPathStr = string.Empty;
            var strArr = pathStr.Split('\\');
            foreach (var str in strArr)
            {
                string newString = str;
                if (newString.Contains(" "))
                {
                    newString = $"\"{newString}\"";
                }
                if (!newPathStr.NotNullOrEmpty())
                    newPathStr = newString;
                else
                    newPathStr = newPathStr + "\\" + newString;
            }
            return newPathStr;
        }
    }
}
