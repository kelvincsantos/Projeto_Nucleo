using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Base.Comum
{
    public static class Processos
    {
        public static string Executar(string driveExePath, string args)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = driveExePath;
                process.StartInfo.Arguments = args;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output;
            }
        }
    }
}
