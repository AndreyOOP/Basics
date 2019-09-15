using System;

namespace CSharp.Exceptions.StackTrace
{
    public class MethodsJustCatch
    {
        public void Method_1()
        {
            try
            {
                Method_2();
            }
            catch (Exception ex)
            {
                "Catch block of Method_1".Out();
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
                "Catch block of Method_2".Out();
                ex.StackTrace.Out();
            }
        }

        public void Method_3()
        {
            throw new Exception("Exception appears in Method_3");
        }
    }
}
