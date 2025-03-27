using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Text;

namespace ExamLibrary.Helper
{
    public class GZip
    {
        public static byte[] CompressJson(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return Array.Empty<byte>();
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(byteArray, 0, byteArray.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static string DecompressJson(byte[] compressedBytes)
        {
            if (compressedBytes == null || compressedBytes.Length == 0)
            {
                return string.Empty;
            }

            using (var memoryStream = new MemoryStream(compressedBytes))
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(gzipStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}