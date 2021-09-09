using System;
using System.IO;

namespace BigBinaryFileGenerator
{
    static class Program
    {
        static void Main(string[] args)
        {
            string path= @"2.bin";
            long maxNumbers = (long)Math.Pow(10, 2);
            var random = new Random();
            using BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            for (long i = 0; i < maxNumbers; ++i)
            {
                ushort number = Convert.ToUInt16(random.Next(0, ushort.MaxValue));
                writer.Write(number);
            }
        }
    }
}