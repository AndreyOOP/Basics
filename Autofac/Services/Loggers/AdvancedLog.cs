using System;

namespace Autofac.Services
{
    public class AdvancedLog : ILogger, IMessage
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Publish(string message)
        {
            Console.WriteLine(message);
        }
    }
}
