using System;
using System.Collections.Generic;
using System.Text;

namespace RunBatForm.Models
{
    public static class Global
    {
        public static string RootAppFolderPath { get; set; }
        public static ConfigModel Configuration { get; set; }
        public static List<ItemModel> StartItem { get; set; }
    }
}
