using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample1
{
    [TestClass]
    public class IteratorSample
    {
        [TestMethod]
        public void SimpleIterator()
        {
            foreach (var i in GetSqueres())
            {
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public async Task AsyncIterator()
        {
            await foreach (var i in GetCubesAsync())
            {
                Console.WriteLine(i);
            }
        }

        private IEnumerable<int> GetSqueres()
        {
            for (int i = 0; i < 10; i++)
            {
                var x = i * i;
                if (x >= 25) yield break;
                // yield means that it works like satte machine & each time when called MoveNext
                // new Current vaule is calculated 
                yield return x;
            }
        }

        private async IAsyncEnumerable<int> GetCubesAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);
                var n = (int)Math.Pow(i, 3);
                yield return n;
            }
        }


    }


}
