using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.BaseWorkings.Publish
{
    public class ArchiveAPIWorking : BaseWorking
    {
        public override string Generate()
        {
            string str = string.Empty;
            str += "title publish_ArchiveAPI";
            str += "\nCD ..";
            str += "\ncall app_config.bat";
            str += "\ncd %archiveApiSourceUrl%";
            str += "\ndotnet restore";
            str += "\ndotnet publish -c Local -o %archiveApiOutputUrl%";
            str += "\n@echo Publish successfully";
            str += "\n@echo -----------------------------------------------";
            return str;
        }
    }
}
