using System;

namespace CSharp.Exceptions.StackTrace
{
    public class ThrowWithoutExceptionVariable
    {
        public void Method_1()
        {
            try
            {
                Method_2();
            }
            catch (Exception)
            {
                "Catch block of Method_1".Out();
                throw;
            }
        }

        public void Method_2()
        {
            try
            {
                Method_3();
            }
            catch (Exception)
            {
                "Catch block of Method_2".Out();
                throw;
            }
        }

        public void Method_3()
        {
            try
            {
                throw new Exception("Exception appears in Method_3");
            }
            catch (Exception)
            {
                "Catch block of Method_3".Out();
                throw;
            }
        }
    }
}
