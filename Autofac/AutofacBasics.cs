using Autofac.Services;
using CSharp;
using NUnit.Framework;

namespace Autofac
{
    [TestFixture]
    public class AutofacBasics
    {
        [Test]
        public void RegisterType_ResolveConcreteType()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleLog>();

            var container = builder.Build();

            var consoleLog = container.Resolve<ConsoleLog>();
            consoleLog.Log("Hello");
        }

        [Test]
        public void RegisterInterface_ResolveTypeByInterface()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileLog>().As<ILogger>();

            var container = builder.Build();

            ILogger fileLog = container.Resolve<ILogger>();

            fileLog.Log("Hello");

            Assert.That(fileLog.GetType(), Is.EqualTo(typeof(FileLog)));
        }

        [Test]
        public void RegisterTypeAndInterface_ResolveServiceFromTypeAndInterface()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileLog>().As<ILogger>();
            builder.RegisterType<FileLog>();

            var container = builder.Build();

            var fileLogFromInterface = container.Resolve<ILogger>();
            var fileLogFromType = container.Resolve<FileLog>();

            fileLogFromInterface.Log("Hello from Interface");
            fileLogFromType.Log("Hello from Type");
        }

        [Test]
        public void ResolveSameServiceFewTimes_OnEachResolveDifferentInstance()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileLog>();

            var container = builder.Build();

            var logger1 = container.Resolve<FileLog>();
            var logger2 = container.Resolve<FileLog>();

            logger1.Log("Hello from Logger 1");
            logger2.Log("Hello from Logger 2");

            Assert.That(logger1.UniqueId, Is.Not.EqualTo(logger2.UniqueId));
        }

        [Test]
        public void RegisterSingleInstance_OnEachResolveSameInstance()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileLog>().SingleInstance();

            var container = builder.Build();

            var logger1 = container.Resolve<FileLog>();
            var logger2 = container.Resolve<FileLog>();

            logger1.Log("Hello from Logger 1");
            logger2.Log("Hello from Logger 2");

            Assert.True(logger1 == logger2);
            Assert.That(logger1.UniqueId, Is.EqualTo(logger2.UniqueId));
        }

        [Test]
        public void CarRegistration_SuccessfullyRegistered()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Car>()
                .OnActivated(arg => "Car registerd".Out());

            builder.RegisterType<Engine>()
                .OnActivated(arg => "Engine registerd".Out());

            builder.RegisterType<FileLog>()
                .As<ILogger>()
                .SingleInstance()
                .OnActivated(arg => "FileLog registerd".Out());

            var container = builder.Build();

            var car = container.Resolve<Car>();

            car.CheckCreatedCar();
        }

        [Test]
        public void FewRegistrationsUnderSameInterface_LastOneResolved()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileLog>().As<ILogger>();
            builder.RegisterType<ConsoleLog>().As<ILogger>();

            var container = builder.Build();

            var logger = container.Resolve<ILogger>();

            Assert.That(logger.GetType(), Is.Not.EqualTo(typeof(ILogger)));
            Assert.That(logger.GetType(), Is.EqualTo(typeof(ConsoleLog)));
        }

        [Test]
        public void TypeRegisteredUnderMultipleInterfaces_ResolvedByAnyOfInterface()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AdvancedLog>()
                .As<ILogger>()
                .As<IMessage>()
                .AsSelf();

            var container = builder.Build();

            var logger1 = container.Resolve<ILogger>();
            var logger2 = container.Resolve<IMessage>();
            var logger3 = container.Resolve<AdvancedLog>();

            Assert.True(logger1 != logger2);
        }

        [Test]
        public void ChoosingBetweenFewConstructors_SelectedBasedOnUsingConstructorParameters()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<Car>(); //in this case resolved FileLog
            builder.RegisterType<Car>()
                .UsingConstructor(typeof(Engine));

            builder.RegisterType<Engine>();
            builder.RegisterType<FileLog>().As<ILogger>().SingleInstance();

            var container = builder.Build();

            var car = container.Resolve<Car>();

            Assert.That(car.GetLogger(), Is.Null);
        }

        [Test]
        public void InstanceRegistration_SameInstanceResolved()
        {
            var builder = new ContainerBuilder();

            var fileLog = new FileLog();
            builder.RegisterInstance(fileLog).As<ILogger>(); //now will be used instance of FileLog we register above

            var container = builder.Build();

            var resolvedFileLog = container.Resolve<ILogger>();
            var resolvedFileLog2 = container.Resolve<ILogger>();

            Assert.True(fileLog == resolvedFileLog);
            Assert.True(fileLog == resolvedFileLog2);
        }
    }
}
