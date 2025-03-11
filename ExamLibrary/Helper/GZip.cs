using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Text;

namespace ExamLibrary.Helper
{
    public class GZip
    {
        public static byte[] Compress(byte[] raw)
        {
            byte[] result;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                Stream stream = new GZipStream(memoryStream, CompressionMode.Compress);
                stream.Write(raw, 0, raw.Length);
                stream.Close();
                result = memoryStream.ToArray();
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static byte[] Decompress(byte[] compressedInput, int originSize)
        {
            byte[] array = new byte[originSize];
            new GZipStream(new MemoryStream(compressedInput), CompressionMode.Decompress).Read(array, 0, originSize);
            return array;
        }
    }
}