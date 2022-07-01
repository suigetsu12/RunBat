using RunBatForm.Constans;
using RunBatForm.Extensions;
using RunBatForm.Helpers;
using RunBatForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunBatForm
{
    static class Program
    {
        public static DataModel data;
        private static JsonSerializerOptions options;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ReadConfig();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void ReadConfig()
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            Global.RootAppFolderPath = Directory.GetCurrentDirectory();
            string path = Global.RootAppFolderPath;
            string _configurationPath = Path.Combine(path, FilePath.Configuration);
            string jsonString = FileHelper.ReadFile(_configurationPath);
            if(jsonString.NotNullOrEmpty())
            {
                Global.Configuration = JsonHelper.Deserialize<ConfigModel>(jsonString);
            }
        }
    }
}
