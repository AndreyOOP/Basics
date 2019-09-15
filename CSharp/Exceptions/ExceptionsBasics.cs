using CSharp.Exceptions.StackTrace;
using NUnit.Framework;
using System;

namespace CSharp.Exceptions
{
    [TestFixture]
    public class ExceptionsBasics
    {
        [Test]
        public void Basic_ExceptionInCatchBlock_ThrowException()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                "In catch block".Out();

                var zero = 0;
                var n = 1 / zero;
            }
        }

        [Test]
        public void Finally_ExceptionInCatchBlockAndFinally_FinallyExecutedThrowException()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                "In catch block".Out();

                var zero = 0;
                var n = 1 / zero;

                throw; //it will not accessed
            }
            finally
            {
                "Finally block".Out();
            }

            "After try block".Out();
        }

        [Test]
        public void Finally_ReturnInTryBlock_FinallyExecuted()
        {
            try
            {
                return;
            }
            finally
            {
                "Finally block message".Out();
            }

            "Message after try block".Out();
        }

        [Test]
        public void Finally_ThrowExceptionInTryBlock_FinallyExecuted()
        {
            try
            {
                throw new Exception();
            }
            finally
            {
                "Finally block message".Out();
            }

            "Message after try block".Out();
        }

        [Test]
        public void Finally_ThrowExceptionInTryBlock_CatchAndFinallyExecuted()
        {
            try
            {
                throw new Exception();
            }
            catch(Exception ex)
            {
                "Catch block".Out();
            }
            finally
            {
                "Finally block message".Out();
            }

            "Message after try block".Out();
        }

        [Test]
        public void Inheritance_ThrowExceptionInTryBlock_ExceptionCatchedIntoCatchBlockExecutionContinues()
        {
            try
            {
                throw new Exception("Some exception");
                "Code after exception throw".Out();
            }catch(Exception ex)
            {
                "Exception handling".Out();
            }

            "Message after try block".Out();
        }

        [Test]
        public void Inheritance_ThrowCustomException_CustomExceptionCatched()
        {
            try
            {
                throw new CustomException();
            }
            catch(CustomException ex)
            {
                "Custom exception catched".Out();
            }
            catch(BaseException ex)
            {
                "Base exception catched".Out();
            }

            "Code outside of try block".Out();
        }

        [Test]
        public void Inheritance_ThrowCustomExceptionSetBaseExceptionBeforeCustomException_CompilationError()
        {
            try
            {
                throw new CustomException();
            }
            catch (BaseException ex)
            {
                "Base exception catched".Out();
            }
            //catch (CustomException ex)
            //{
            //    "Custom exception catched".Out();
            //}
            
            "Code outside of try block".Out();
        }

        [Test]
        public void Inheritance_ThrowCustomExceptionInExceptionBaseVariable_CustomExceptionCatched()
        {
            try
            {
                BaseException exceptionBase = new CustomException();

                throw exceptionBase;
            }
            catch (CustomException ex)
            {
                "Custom exception catched".Out();
            }
            catch (BaseException ex)
            {
                "Base exception catched".Out();
            }

            "Code outside of try block".Out();
        }

        [Test]
        public void Inheritance_ThrowBaseException_BaseExceptionCatched()
        {
            try
            {
                throw new BaseException();
            }
            catch (CustomException ex)
            {
                "Custom exception catched".Out();
            }
            catch (BaseException ex)
            {
                "Base exception catched".Out();
            }

            "Code outside of try block".Out();
        }

        [Test]
        public void Inveritance_ThrowExceptionWhichNotCatched_ThrowException()
        {
            try
            {
                throw new Exception();
            }
            catch (CustomException ex)
            {
                "Custom exception catched".Out();
            }
            catch (BaseException ex)
            {
                "Base exception catched".Out();
            }

            "Code outside of try block".Out();
        }

        [Test]
        public void StackTrace_Throw_CompleteStacktrace()
        {
            var methodsThrow = new MethodsThrow();

            try
            {
                methodsThrow.Method_1();
            }
            catch(Exception ex)
            {
                "Catch block of test method".Out();
                $"Exception Message = {ex.Message}".Out();
                ex.StackTrace.Out();
            }
        }

        [Test]
        public void StackTrace_ThrowEx_IncompleteStackTrace() //looks like exception has been throwed in Method_1
        {
            var methods = new MethodsThrowEx();

            try
            {
                methods.Method_1();
            }
            catch (Exception ex)
            {
                "Catch block of test method".Out();
                $"Exception Message = {ex.Message}".Out();
                ex.StackTrace.Out();
            }
        }

        [Test]
        public void StackTrace_JustCatch_HandleExceptionInMethod_2()
        {
            var methods = new MethodsJustCatch();

            try
            {
                methods.Method_1();
            }
            catch (Exception ex)
            {
                "Catch block of test method".Out();
                $"Exception Message = {ex.Message}".Out();
                ex.StackTrace.Out();
            }
        }

        [Test]
        public void StackTrace_ThrowWithoutExceptionVariable_CompleteStacktrace() //stacktrace looks the same as StackTrace_Throw_CompleteStacktrace
        {
            var methodsThrow = new ThrowWithoutExceptionVariable();

            try
            {
                methodsThrow.Method_1();
            }
            catch (Exception ex)
            {
                "Catch block of test method".Out();
                $"Exception Message = {ex.Message}".Out();
                ex.StackTrace.Out();
            }
        }

        
    }
}