using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Exceptions.StackTrace
{
    // stack trace suppressed, each exception is different
    public class SetInnerException
    {
        public void Method_1()
        {
            try
            {
                Method_2();
            }
            catch (Exception ex)
            {
                throw new Exception("In method 1", ex);
            }
        }

        public void Method_2()
        {
            try
            {
                Method_3();
            }
            catch (Exception ex)
            {
                throw new Exception("In method 2", ex);
            }
        }

        public void Method_3()
        {
            try
            {
                throw new Exception("Exception appears in Method_3");
            }
            catch (Exception ex)
            {
                throw new Exception("In method 3", ex);
            }
        }
    }
}
