using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample2
{
    [TestClass]
    public class RefInOut
    {
        [TestMethod]
        public void ByValueSample()
        {
            var v = new StringBuilder("test");
            ByValue(v);
            Console.WriteLine(v);
            Assert.IsNotNull(v);

            void ByValue(StringBuilder sb)
            {
                sb.Append("_byvalue");
                sb = null;
            }
        }


        [TestMethod]
        public void ByRefSample()
        {
            var v = new StringBuilder("test");
            ByValue(ref v);
            Assert.IsNull(v);

            void ByValue(ref StringBuilder sb)
            {
                sb.Append("_byvalue");
                sb = null;
            }
        }

        [TestMethod]
        public void InReadonlyStruct()
        {
            var s = new SomeStruct
            {
                A = 2
            };

            UsingIn(in s);

            void UsingIn(in SomeStruct str)
            {
                var x = s.A;
                //s.A = 10; // compile time error
            }
        }

    }

    // without readonly will be created defense copy, because get is a method which potentially can 
    // mutate state
    readonly struct SomeStruct
    {
        public int A { get; init; }
    }
}
