using System;

namespace Autofac.Services
{
    public class Car
    {
        private Engine _engine;
        private ILogger _logger;

        public Car(Engine engine)
        {
            _engine = engine;
        }

        public Car(Engine engine, ILogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public void CheckCreatedCar()
        {
            Console.WriteLine($"Car is registered");
        }

        public ILogger GetLogger()
        {
            return _logger;
        }
    }
}
