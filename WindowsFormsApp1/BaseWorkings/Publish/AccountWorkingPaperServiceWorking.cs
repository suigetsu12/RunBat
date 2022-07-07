using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.BaseWorkings.Publish
{
    public class AccountWorkingPaperServiceWorking : BaseWorking
    {
        public AccountWorkingPaperServiceWorking()
        {
            
        }
        public override string Generate()
        {
            string str = string.Empty;
            str += "title publish_AccountWorkingPaperService";
            str += "\nCD ..";
            str += "\ncall app_config.bat";
            str += "\n@echo Publishing AccountWorkingPaperService ...";
            str += "\nCD %wpSourceUrl%";
            str += "\ndotnet restore";
            str += "\ndotnet publish -c Local -o %wpOutputUrl%";
            str += "\n@echo Publish successfully";
            str += "\n@echo -----------------------------------------------";
            return str;
        }
    }
}
