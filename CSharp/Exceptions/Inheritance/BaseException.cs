using System;

namespace CSharp.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException() : base()
        {
            "Constructor of base exception".Out();
        }

        public override string Message => "Base exception";
    }
}