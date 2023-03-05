using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples
{
    [TestClass]
    public class Streams
    {
        [TestMethod]
        public async Task ReadStreamFromFile()
        {
            // read single byte
            using (var fileStream = File.OpenRead("./Files/TestFile.txt")) {
                for(int b; (b = fileStream.ReadByte()) > -1;)
                    Console.WriteLine(b);
            }
            // read in cycle using buffer
            using (var fileStream2 = new FileStream("./Files/TestFile2.txt", FileMode.Open, FileAccess.Read))
            {
                int bytesRead = 0;
                int chunkSize = 1;
                var data = new byte[fileStream2.Length];
                while (bytesRead < data.Length && chunkSize > 0)
                    bytesRead += chunkSize = await fileStream2.ReadAsync(data, bytesRead, data.Length - bytesRead);
            }
            // read 
            using (var streamReader = File.OpenText("./Files/TestFile3.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    Console.WriteLine(streamReader.ReadLine()); 
                }
                streamReader.BaseStream.Position = 0;
                var data = await streamReader.ReadToEndAsync();
                Console.WriteLine("Reread after setting position to 0 => \n" + data);
            }
        }

        [TestMethod]
        public void MemoryStreamFromString()
        {
            // v1
            var str = "abcdef";
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(str));
            Assert.AreEqual(6, ms.Length);

            // v2
            var ms2 = new MemoryStream();
            using(var streamWriter = new StreamWriter(ms2))
            {
                streamWriter.WriteLine(str);
            }
            Assert.AreEqual(6, ms.Length);
        }

        [TestMethod]
        public void CopyStream()
        {
            var source = new MemoryStream(Encoding.ASCII.GetBytes("abcd"));
            var destination = new MemoryStream();
            source.CopyTo(destination); // note that position is at the end of the stream

            Assert.AreEqual(4, destination.Length);
        }

        [TestMethod]
        public void FileFromStream()
        {
            using (var ms = new MemoryStream(Encoding.ASCII.GetBytes("hello")))
            using (var fs = new FileStream("./Files/TestFile4.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                ms.CopyTo(fs);
                // flush happens automatically after stream close
            }
        }

        [TestMethod]
        public void ThreadSafeStream()
        {
            var fs = new FileStream("./Files/TestFile.txt", FileMode.OpenOrCreate);
            var fssync = Stream.Synchronized(fs);
        }

        [TestMethod]
        public void DecoratedStream_CompressionInMemory()
        {
            var ms = new MemoryStream();
            using (var zs = new GZipStream(ms, CompressionLevel.Optimal))
            using (var sw = new StreamWriter(zs))
            {
                sw.WriteLine("abc");
                sw.WriteLine("abc");
                sw.WriteLine("abc");
            }

            var compressed = ms.ToArray();

            var compressedMs = new MemoryStream(compressed);
            using(var zs = new GZipStream(compressedMs, CompressionMode.Decompress))
            using (var sr = new StreamReader(zs))
            {
                var result = sr.ReadToEnd();
                Assert.AreEqual("abc\r\nabc\r\nabc\r\n", result);
            }
        }
    }
}
