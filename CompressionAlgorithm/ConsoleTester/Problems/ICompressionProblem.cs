using System.IO;

namespace ConsoleTester.Problems
{
    public interface ICompressionProblem
    {
        void Encoding(Stream input, Stream output);
        void Decoding(Stream input, Stream output);
    }
}