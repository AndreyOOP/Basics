namespace Autofac.Services
{
    public class Engine
    {
        private ILogger _logger;

        public Engine(ILogger logger)
        {
            _logger = logger;
        }
    }
}
