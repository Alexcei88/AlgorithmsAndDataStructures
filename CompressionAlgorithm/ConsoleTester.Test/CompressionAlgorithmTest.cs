using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using ConsoleTester.Problems;
using NUnit.Framework;

namespace ConsoleTester.Test
{
    [TestFixture(typeof(RLEProblem))]
    [TestFixture(typeof(ImprovedRLEProblem))]
    public class Tests
    {
        private Stopwatch _stopWatch;
        
        [OneTimeSetUp]
        public void Init()
        {
            _stopWatch = Stopwatch.StartNew();   
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _stopWatch.Stop();
            TestContext.Out.WriteLine("Execution time for {0} - {1} ms",
                TestContext.CurrentContext.Test.Name,
                _stopWatch.ElapsedMilliseconds);
            // ... add your code here
        }
        
        private readonly ICompressionProblem _problem;
        
        public Tests(Type problemType)
        {
            _problem = (ICompressionProblem)Activator.CreateInstance(problemType);
        }
        
        [Test]
        public void RLECompressDecompress_String_Success()
        {
            string input = @"I am toooooo long texxt and I willllll be compressssssed and decompresssssed. Понимаешь. \r\n Яћ нич!!!!апв:%вцюыДава543раб2559104ал*`";
            
            using var inputStream = GenerateStreamFromString(input);
            using var encodingStream = new MemoryStream();
            
            _problem.Encoding(inputStream, encodingStream);
            using var decodingStream = new MemoryStream();
            
            encodingStream.Position = 0;
            _problem.Decoding(encodingStream, decodingStream);
            Assert.AreEqual(input, StreamToString(decodingStream));
        }
        
        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}