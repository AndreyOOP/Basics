using CSharp;
using System;

namespace Autofac.Services
{
    public class ConsoleLog : ILogger
    {
        public ConsoleLog()
        {
            "Console log constructor without parameters".Out();
        }

        public void Log(string message)
        {
            Console.WriteLine($"Console log message: {message}");
        }
    }
}
