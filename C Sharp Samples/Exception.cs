using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Samples
{
    [TestClass]
    public class ExceptionSample
    {
        [TestMethod]
        public void CatchWhen()
        {
            try
            {
                //throw new ArgumentException() { Source = "test" };
                throw new ArgumentException("msg");
                //throw new Exception();
            }
            catch (ArgumentException ex) when (ex.Source == "test")
            {
            }
            catch (ArgumentException ex) when (ex.Message == "msg")
            {
            }
            catch (ArgumentException ex) 
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // The only things that can defeat a finally block are an infinite loop or the process
                // ending abruptly
            }
        }

        [TestMethod]
        public void ThrowVsThrowEx()
        {
            try
            {
                Throw();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                ThrowEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Throw()
        {
            try
            {
                var x = 0;
                Console.WriteLine(1 / x);
            }
            catch (Exception ex)
            {
                // 1. Define more specific exception
                // 2. Do some action (e.g logging) before rethrowing
                throw; // correctly point stacktrace to (1/x line)
            }
        }

        private void ThrowEx()
        {
            try
            {
                var x = 0;
                Console.WriteLine(1 / x);
            }
            catch (Exception ex)
            {
                throw ex; // stacktrace points that error appears here (instead of 1/x line)
            }
        }
    }
}