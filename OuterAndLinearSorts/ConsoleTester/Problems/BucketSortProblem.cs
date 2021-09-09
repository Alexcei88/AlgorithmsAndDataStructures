using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleTester.Sorts;

namespace ConsoleTester.Problems
{
    public class BucketSortProblem
        : ISortFromFileProblem
    {
        private readonly string _tempBinaryFile;

        public BucketSortProblem(string inputFilePath, string outputFile)
        {
            _tempBinaryFile = outputFile;
            File.Copy(inputFilePath, _tempBinaryFile, true);
        }

        public void Sort()
        {
            var input = ReadArrayFromBinaryFile(_tempBinaryFile);
            var bucketSort = new BucketSort();
            input = bucketSort.Sort(input);
            WriteArrayToBinaryFile(_tempBinaryFile, input);
        }

        public string ResultFile => _tempBinaryFile;

        private ushort[] ReadArrayFromBinaryFile(string path)
        {
            List<ushort> array = new();
            using var inputStream = File.Open(path, FileMode.Open);
            using var reader = new BinaryReader(inputStream);
            while (inputStream.Position != inputStream.Length)
            {
                ushort number = reader.ReadUInt16();
                array.Add(number);
            }

            return array.ToArray();
        }
        
        private void WriteArrayToBinaryFile(string path, ushort[] input)
        {
            using var reader = new BinaryWriter(File.Open(path, FileMode.Open));
            foreach (var a in input)
            {
                reader.Write(a);
            }
        }
        
    }
}