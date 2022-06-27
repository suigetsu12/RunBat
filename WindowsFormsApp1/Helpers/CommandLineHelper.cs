using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RunBatForm.Helpers
{
    public static class CommandLineHelper
    {
        public static Process Run(string workingDirectoryPath, string processPath)
        {
            ProcessStartInfo processBat = new ProcessStartInfo(processPath);
            processBat.WindowStyle = ProcessWindowStyle.Normal;
            processBat.ErrorDialog = true;
            processBat.WorkingDirectory = workingDirectoryPath;
            var process = Process.Start(processBat);
            return process;
        }
    }
}
