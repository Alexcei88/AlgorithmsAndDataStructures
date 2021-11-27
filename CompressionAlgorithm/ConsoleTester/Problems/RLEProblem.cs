using System;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleTester.Problems
{
    public class RLEProblem
        : ICompressionProblem
    {
        public void Encoding(Stream input, Stream output)
        {
            byte prevSymbol = (byte)input.ReadByte();
            byte count = 1;

            void WriteRepeatedSymbol(byte symbol)
            {
                output.WriteByte(count);
                output.WriteByte(prevSymbol);
                count = 1;
            }
            
            while (input.Position < input.Length)
            {
                byte currentSymbol = (byte)input.ReadByte();

                if (prevSymbol == currentSymbol)
                {
                    if (count > byte.MaxValue - 2)
                        WriteRepeatedSymbol(prevSymbol);
                    else
                        ++count;
                }
                else
                {
                    WriteRepeatedSymbol(prevSymbol);
                    prevSymbol = currentSymbol;
                    count = 1;
                }
            }
            
            WriteRepeatedSymbol(prevSymbol);
        }

        public void Decoding(Stream input, Stream output)
        {
            Span<byte> currentSymbols = stackalloc byte[2];
            while (input.Position < input.Length)
            {
                input.Read(currentSymbols);
                byte number = currentSymbols[0];
                byte symbol = currentSymbols[1];
                for (byte i = 0; i < number; ++i)
                    output.WriteByte(symbol);
            }

            output.Position = 0;
        }
    }
}