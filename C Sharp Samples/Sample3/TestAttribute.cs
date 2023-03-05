using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample3
{
    public class ReverseAttribute : Attribute { }

    public class AttrSample
    {
        [Reverse] // test with & without attribute
        public override string ToString()
        {
            var str = base.ToString();
            if (MethodInfo.GetCurrentMethod().GetCustomAttribute<ReverseAttribute>() != null)
                return new string(str.Reverse().ToArray());
            return str;
        }
    }

    [TestClass]
    public class AttributeTestClass
    {
        [TestMethod]
        public void TestAttributeMethod()
        {
            // without attribute
            //Assert.AreEqual("C_Sharp_Samples.Sample3.AttrSample", new AttrSample().ToString());
            
            // with attribute
            Assert.AreEqual("elpmaSrttA.3elpmaS.selpmaS_prahS_C", new AttrSample().ToString());
        }
    }
}
