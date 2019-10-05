using CSharp;
using System;

namespace Autofac.Services
{
    public class FileLog : ILogger
    {
        public Guid UniqueId { get; }

        public FileLog()
        {
            "File log constructor without parameters".Out();
            UniqueId = Guid.NewGuid();
        }

        public void Log(string message)
        {
            Console.WriteLine($"File log message: {message}. Instance id: {UniqueId}");
        }
    }
}
