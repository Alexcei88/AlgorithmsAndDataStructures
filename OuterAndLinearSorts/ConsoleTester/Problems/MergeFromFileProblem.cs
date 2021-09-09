using System.IO;

namespace ConsoleTester.Problems
{
    public class MergeFromFileProblem
        : ISortFromFileProblem
    {
        private readonly string _tempBinaryFile;

        public MergeFromFileProblem(string inputFilePath, string outputFile)
        {
            _tempBinaryFile = outputFile;
            File.Copy(inputFilePath, _tempBinaryFile, true);
        }

        public string ResultFile => _tempBinaryFile;

        public void Sort()
        {
            long length;
            {
                using var inputStream = File.Open(_tempBinaryFile, FileMode.Open);
                length = inputStream.Length / sizeof(ushort);
            }
            
            Sort(0, (int)length);
        }

        private void Sort(int l, int r)
        {
            if(l + 1 >= r)
                return;
            
            int x = (r + l) / 2;
            
            Sort(l, x);
            Sort(x, r);
            
            Merges(l, x, r);
        }
        
        private void Merges(int l, int mid, int r)
        {
            ushort[] tempArray = ReadFromFile(l, r);
           
            using var outputStream = File.Open(_tempBinaryFile, FileMode.Open);
            outputStream.Position = l * sizeof(ushort);
            using var writer = new BinaryWriter(outputStream);

            int idxL = 0;
            int idxR = mid - l;
            while (idxL < mid - l && idxR < r - l)
            {
                if (tempArray[idxL] < tempArray[idxR])
                {
                    writer.Write(tempArray[idxL++]);
                }
                else
                {
                    writer.Write(tempArray[idxR++]);
                }
            }

            for (int i = idxL; i < mid - l; ++i)
                writer.Write(tempArray[idxL++]);

            for (int i = idxR; i < r - l; ++i)
                writer.Write(tempArray[idxR++]);
        }
        
        private ushort[] ReadFromFile(int l, int r)
        {
            int length = r - l;
            ushort[] array = new ushort[length];
            // 1. read from file
            {
                using var inputStream = File.Open(_tempBinaryFile, FileMode.Open);
                inputStream.Position = l * sizeof(ushort);
                using var reader = new BinaryReader(inputStream);
                for (int i = 0; i < length; ++i)
                {
                    array[i] = reader.ReadUInt16();
                }
            }
            return array;
        }

    }
}