using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample3
{
    [TestClass]
    public class ClassAllMembersSamples
    {
        [TestMethod]
        public void DeconstructorTest()
        {
            var am = new AllMembers("Maya", "Diosa");
            var (fn, ln) = am; // deconstructor
            Assert.AreEqual("Maya", fn);
            Assert.AreEqual("Diosa", ln);
        }

        [TestMethod]
        public void OperatorOverloading()
        {
            var am = new AllMembers("Maya", "Diosa") + "_test"; // overloaded + sign
            var (fn, ln) = am;
            Assert.AreEqual(fn, "Maya_test");
            Assert.AreEqual(ln, "Diosa_test");
        }

        [TestMethod]
        public void Explicit()
        {
            var str = "abc bcd";
            var am = (AllMembers)str;
            // var am2 = str as AllMembers; not work
            Assert.AreEqual($"{am.FirstName} {am.LastName}", "abc bcd");
        }

        [TestMethod]
        public void Implicit()
        {
            var am = new AllMembers("Maya", "Diosa");
            string str = am;
            Assert.AreEqual("Maya Diosa", am);
            Assert.AreEqual("Maya Diosa", str);
            Assert.AreEqual("C_Sharp_Samples.Sample3.AllMembers", am.ToString());
        }
    }
}
