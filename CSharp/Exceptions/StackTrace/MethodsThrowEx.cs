﻿using System;

namespace CSharp.Exceptions.StackTrace
{
    // into each catch block ex is the same object => e1 == e2 == e3
    public class MethodsThrowEx
    {
        public object e1;
        public object e2;
        public object e3;

        public void Method_1()
        {
            try
            {
                Method_2();
            }
            catch (Exception ex)
            {
                //e3 = ex;
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
                //e2 = ex;
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
                //e1 = ex;
                "Catch block of Method_3".Out();
                throw ex;
            }
        }
    }
}
