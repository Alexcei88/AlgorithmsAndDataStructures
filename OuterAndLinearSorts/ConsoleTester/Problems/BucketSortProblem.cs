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
            var input = ReadArrayFromBinaryFile(_tempBinaryFile).ToArray();
            var bucketSort = new BucketSort();
            input = bucketSort.Sort(input);
            WriteArrayToBinaryFile(_tempBinaryFile, input);
        }
        
        private IEnumerable<ushort> ReadArrayFromBinaryFile(string path)
        {
            using var reader = new BinaryReader(File.Open(path, FileMode.Open));
            while (reader.PeekChar() > -1)
            {
                ushort number = reader.ReadUInt16();
                yield return number;
            }
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