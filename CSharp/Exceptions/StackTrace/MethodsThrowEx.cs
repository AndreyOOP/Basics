using System;

namespace CSharp.Exceptions.StackTrace
{
    public class MethodsThrowEx
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
                throw ex;
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
                throw ex;
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
                "Catch block of Method_3".Out();
                throw ex;
            }
        }
    }
}
