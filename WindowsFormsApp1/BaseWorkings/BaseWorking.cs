using RunBatForm.Extensions;
using RunBatForm.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.BaseWorkings
{
    public abstract class BaseWorking
    {
        public string path { get; set; }
        public abstract string Generate();

        public void Create(string data)
        {
            if (path.NotNullOrEmpty() && data.NotNullOrEmpty())
            {
                FileHelper.WriteNewFile(path, data);
            }
        }
    }
}
