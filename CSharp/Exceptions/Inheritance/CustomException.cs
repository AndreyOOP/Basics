namespace CSharp.Exceptions
{
    public class CustomException : BaseException
    {
        public CustomException()
        {
            "Constructor of custom exception".Out();
        }

        public override string Message => "Custom exception message";
    }
}
