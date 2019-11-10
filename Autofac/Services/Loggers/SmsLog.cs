using System;

namespace Autofac.Services.Loggers
{
    public class SmsLog : ILogger
    {
        private string _phoneNumber;

        public SmsLog(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public void Log(string message)
        {
            Console.WriteLine($"{message} send to phone {_phoneNumber}");
        }
    }
}
