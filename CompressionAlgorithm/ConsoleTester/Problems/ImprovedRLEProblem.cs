using System;
using System.IO;

namespace ConsoleTester.Problems
{
    public class ImprovedRLEProblem
        : ICompressionProblem
    {
        public void Encoding(Stream input, Stream output)
        {
            Span<byte> singleSymbols = stackalloc byte[sbyte.MaxValue];
            byte prevSymbol = (byte)input.ReadByte();
            byte singleCount = 0;
            byte count = 1;

            bool WriteRepeatedSymbol(byte symbol)
            {
                if (count > 1)
                {
                    count |= 0x80;
                    output.WriteByte(count);
                    output.WriteByte(symbol);
                    count = 1;
                    return true;
                }

                return false;
            }
            
            void WriteSingleSymbols(Span<byte> singleSymbols)
            {
                if (singleCount > 0)
                {
                    output.WriteByte(singleCount);
                    output.Write(singleSymbols.Slice(0, singleCount));
                    singleCount = 0;
                }
            }

            while (input.Position < input.Length)
            {
                byte currentSymbol = (byte)input.ReadByte();
                if (prevSymbol == currentSymbol)
                {
                    if (count > sbyte.MaxValue - 2)
                        WriteRepeatedSymbol(prevSymbol);
                    else
                        ++count;
                    WriteSingleSymbols(singleSymbols);
                }
                else
                {
                    if(!WriteRepeatedSymbol(prevSymbol))
                        singleSymbols[singleCount++] = prevSymbol;

                    if (singleCount > sbyte.MaxValue - 2)
                        WriteSingleSymbols(singleSymbols);
                    
                    prevSymbol = currentSymbol;
                }
            }

            if(!WriteRepeatedSymbol(prevSymbol))
                singleSymbols[singleCount++] = prevSymbol;
               
            WriteSingleSymbols(singleSymbols);
        }

        public void Decoding(Stream input, Stream output)
        {
            Span<byte> currentSymbols = stackalloc byte[sbyte.MaxValue + 1];
            while (input.Position < input.Length)
            {
                input.Read(currentSymbols.Slice(0, 1));
                byte number = currentSymbols[0];
                if ((number & 0x80) > 0)
                {
                    // repeated
                    input.Read(currentSymbols.Slice(0, 1));
                    
                    byte positiveNumber = (byte)(number & 0x7F);
                    for (byte i = 0; i < positiveNumber; ++i)
                    {
                        output.WriteByte(currentSymbols[0]);
                    }
                }
                else
                {
                    // single
                    input.Read(currentSymbols.Slice(0, number));
                    
                    output.Write(currentSymbols.Slice(0, number));
                }
            }

            output.Position = 0;
        }
        
    }
}