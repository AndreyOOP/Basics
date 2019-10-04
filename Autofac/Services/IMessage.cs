namespace Autofac.Services
{
    public interface IMessage
    {
        void Publish(string message);
    }
}
