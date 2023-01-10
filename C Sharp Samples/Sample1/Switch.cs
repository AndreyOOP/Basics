using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Samples.Sample1
{
    // See samples:
    //   https://habr.com/ru/post/523552/
    //   https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/pattern-matching
    [TestClass]
    public class Switch
    {
        [TestMethod]
        [DataRow(0, "zero")]
        [DataRow(1, "one")]
        [DataRow(-1, "undefined")]
        public void SwitchOperator(int i, string expected)
        {
            var result = default(string);
            switch (i)
            {
                case 0:
                    result = "zero";
                    break;
                case 1:
                    result = "one";
                    break;
                default:
                    result = "undefined";
                    break;
            }

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(0, "zero")]
        [DataRow(1, "one")]
        [DataRow(-1, "undefined")]
        public void SwitchExpression(int i, string expected)
        {
            var result = i switch
            {
                0 => "zero",
                1 => "one",
                _ => "undefined" // discard pattern
            };

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SwitchExpression_MatchByType()
        {
            object type = "";
            //object type = (int)1;

            var result = type switch
            {
                string _ => "string",
                int _ => "int",
                _ => "object"
            };

            Assert.AreEqual("string", result);
        }

        [TestMethod]
        [DataRow(true, true, "a & b - true")]
        [DataRow(true, true, "a & b - true")]
        [DataRow(true, false, "default")]
        [DataRow(false, true, "default")]
        public void SwitchExpression_Cortages(bool a, bool b, string expected)
        {
            var result = (a, b) switch
            {
                (true, true) => "a & b - true",
                (false, false) => "a & b - false",
                (_, _) => "default"
            };

            Assert.AreEqual(expected, result);
        }

        class Weater
        {
            public int Temperature { get; set; }
            public int Pressure { get; set; }
        }

        [TestMethod]
        [DataRow(20, 750, "divide")]
        [DataRow(-1, 700, "sum")]
        [DataRow(-10, 710, "default")]
        public void SwitchExpression_PatternMatching(int t, int p, string expected)
        {
            var weater = new Weater { Temperature = t, Pressure = p };

            var result = weater switch
            {
                Weater w when w.Pressure / w.Temperature > 0 => "divide",
                Weater w when w.Pressure + w.Temperature == 699 => "sum",
                _ => "default"
            };

            Assert.AreEqual(expected, result);
        }
    }
}
