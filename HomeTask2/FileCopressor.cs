using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace HomeTask2
{
    public class FileCopressor
    {
        public static void Compress(string inFile, string outFile)
        {
            if (File.Exists(outFile))
            {
                File.Delete(outFile);
                throw new IOException("file exists");
            }

            try
            {
                var bytes = File.ReadAllBytes(inFile);
                using (FileStream fs = new FileStream(outFile, FileMode.CreateNew))
                {
                    using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                    {
                        zipStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error on compressing file");
            }
            
        }
    }
}
