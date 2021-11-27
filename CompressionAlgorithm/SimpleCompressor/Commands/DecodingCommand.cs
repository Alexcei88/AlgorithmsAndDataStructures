using System.IO;
using ConsoleTester.Problems;
using ManyConsole;

namespace SimpleCompressor.Commands
{
    public class DecodingCommand
        : ConsoleCommand
    {
        private string _inputFile = string.Empty;
        private string _outputFile = "output";
        private bool _isImproveRLE;
  
        public DecodingCommand()
        {
            IsCommand("decompress", "Decompress file");
            HasRequiredOption("f|file=", "Input file", t =>
            {
                if (File.Exists(t))
                    _inputFile = t;
                else
                    throw new FileNotFoundException($"File {t} is not found");
            });
            
            HasOption("o|output=", "Output file", t => _outputFile = t);
            HasOption("i|improved=", "Use improved RLE instead of pure RLE", t => _isImproveRLE = bool.Parse(t));

        }

        public override int Run(string[] remainingArguments)
        {
            using var inputStream = File.Open(_inputFile, FileMode.Open);
            using var outputStream = File.Open(_outputFile, FileMode.Create);
            ICompressionProblem compress = _isImproveRLE ? new ImprovedRLEProblem() : new RLEProblem();
            compress.Decoding(inputStream, outputStream);
            return 0;
        }
    }
}