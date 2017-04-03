using System.Diagnostics;
using System.IO;
using System.Reflection;
using bv.common.Configuration;
using bv.common.Core;
using eidss.avr.db.Common;

namespace eidss.avr.db.DBService
{
    public static class AccessExporter
    {
        public static AvrAccessExportResult ExportAnyCPU(long queryId, string filePath)
        {
            var result = ExportX86(queryId, filePath);
            if (!result.IsOk)
            {
                result = ExportX64(queryId, filePath);
            }
            return result;
        }

        public static AvrAccessExportResult ExportX86(long queryId, string filePath)
        {
            return Export(queryId, filePath, true);
        }

        public static AvrAccessExportResult ExportX64(long queryId, string filePath)
        {
            return Export(queryId, filePath, false);
        }

        private static AvrAccessExportResult Export(long queryId, string filePath, bool isX86Mode)
        {
            string exeFileName = isX86Mode
                ? BaseSettings.AvrExportUtilX86
                : BaseSettings.AvrExportUtilX64;
            Assembly asm = Assembly.GetExecutingAssembly();
            string exeFilePath = Utils.GetFilePathNearAssembly(asm, exeFileName);
            var process = new Process
            {
                StartInfo =
                {
                    // Redirect the output stream of the child process.
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    Arguments = string.Format(@"{0} ""{1}""", queryId, filePath),
                    FileName = exeFilePath,
                    WorkingDirectory = Directory.GetCurrentDirectory(),
                },
            };

            process.Start();
            // Read the output stream first and then wait.
            string output = process.StandardOutput.ReadToEnd();
            AvrAccessExportResult result = AvrAccessExportResult.Deserialize(output);
            process.WaitForExit();

            return result;
        }
    }
}