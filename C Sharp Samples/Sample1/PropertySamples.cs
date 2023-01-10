using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Samples.Sample1
{
    [TestClass]
    public class PropertySamples
    {
        [TestMethod]
        public void InitProperty()
        {
            var a = new Properties { A = 10 };
            var b = new Properties(1, 2);
        }
    }

    public class Properties
    {
        public int A { get; init; }
        public int B { get; private set; }

        public Properties() { }

        public Properties(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}
