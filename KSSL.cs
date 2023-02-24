using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace KSSL
{
    internal class KSSL
    {
        private static void Main(string[] args)
        {
            string fileName = "../KSP2_x64.exe";
            //Uncomment if desired
            //Environment.SetEnvironmentVariable("MONO_THREADS_PER_CPU", "1");
            string text = "";
            foreach (string str in args)
            {
                text = text + " " + str;
            }
            if (!KSSL.launched)
            {
                new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        WorkingDirectory = KSSL.HomeDir + "/../",
                        FileName = fileName,
                        CreateNoWindow = true,
                        Arguments = text
                    }
                }.Start();
                KSSL.launched = true;
            }
        }

        public static string HomeDir
        {
            get
            {
                if (KSSL.homeDir == null)
                {
                    KSSL.homeDir = Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path);
                    KSSL.homeDir = Path.GetDirectoryName(KSSL.homeDir);
                }
                return KSSL.homeDir;
            }
        }

        public static bool launched;

        private static string homeDir;
    }
}
