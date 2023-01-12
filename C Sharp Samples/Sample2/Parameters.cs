using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample2
{
    [TestClass]
    public class ParametersSample
    {
        [TestMethod]
        public void ParamsTest()
        {
            string ListOfParams(params char[] letters){
                var sb = new StringBuilder();
                letters.ToList().ForEach(s => sb.Append(s));
                return sb.ToString();
            }
            Assert.AreEqual("abc", ListOfParams('a', 'b', 'c'));
            Assert.AreEqual("abcxyz", ListOfParams('a', 'b', 'c', 'x', 'y', 'z'));
        }

        [TestMethod]
        public void DefaultValues()
        {
            ValueTuple<bool, string> DefValues(bool b = true, string s = "def_value") => (b, s);
            
            Assert.AreEqual((true, "def_value"), DefValues());
            Assert.AreEqual((false, "abc"), DefValues(false, "abc"));
        }
        
    }
}
