using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample1
{
    [TestClass]
    public class PatternsSample
    {
        [TestMethod]
        public void IsWithPropertiesCheck()
        {
            var str = "abcd";
            Assert.IsTrue(str is string { Length: 4 });
        }

        [TestMethod]
        public void ConstantPattern()
        {
            object x = 3;
            Assert.IsTrue(x is 3);
            Assert.IsTrue(3.Equals(x));
        }

        [TestMethod]
        public void RelationalPattern()
        {
            object x = 5;
            Assert.IsTrue(x is < 10);
        }

        [TestMethod]
        public void TuplePattern()
        {
            var p = (2, 3); // Tuple<int, int>

            int a = 1, b = 3;
            var r = (a, b) switch
            {
                (1, 3) => "result 1",
                (0, 10) => "result 2",
                _ => throw new Exception()
            };
        }
    }
}
