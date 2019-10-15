using HomeTask2;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace SharpDump
{
    public class Program
    {
        // partially adapted from https://blogs.msdn.microsoft.com/dondu/2010/10/24/writing-minidumps-in-c/

        

        public static void Main(string[] args)
        {
            string systemRoot = Environment.GetEnvironmentVariable("SystemRoot");
            string dumpDir = String.Format("{0}\\Temp\\", systemRoot);
            if (!Directory.Exists(dumpDir))
            {
                Console.WriteLine(String.Format("\n[X] Dump directory \"{0}\" doesn't exist!\n", dumpDir));
                return;
            }

            if (args.Length == 0)
            {
                // dump LSASS by default
                FileDumper.Minidump();
            }
            else if (args.Length == 1)
            {
                int retNum;
                if (int.TryParse(Convert.ToString(args[0]), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum))
                {
                    // arg is a number, so we're specifying a PID
                    FileDumper.Minidump(retNum);
                }
                else
                {
                    Console.WriteLine("\nPlease use \"SharpDump.exe [pid]\" format\n");
                }
            }
            else if (args.Length == 2)
            {
                Console.WriteLine("\nPlease use \"SharpDump.exe [pid]\" format\n");
            }
        }
    }
}