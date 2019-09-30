using System;

namespace Autofac.Services
{
    public class Car
    {
        private Engine _engine;
        private ILogger _logger;

        public Car(Engine engine, ILogger logger)
        {
            engine = _engine;
            logger = _logger;
        }

        public void CheckCreatedCar()
        {
            Console.WriteLine($"Car is registered");
        }
    }
}
