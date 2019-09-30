using Autofac.Services;
using CSharp;
using NUnit.Framework;
using System;

namespace Autofac
{
    [TestFixture]
    public class AutofacBasics
    {
        [Test]
        public void SampleOfUsage_RegisterType()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleLog>();

            var container = builder.Build();

            var consoleLog = container.Resolve<ConsoleLog>();
            consoleLog.Log("Hello");
        }

        [Test]
        public void SampleOfUsage_RegisterInterface()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileLog>().As<ILogger>();

            var container = builder.Build();

            ILogger fileLog = container.Resolve<ILogger>();

            fileLog.Log("Hello");

            Assert.That(fileLog.GetType(), Is.EqualTo(typeof(FileLog)));
        }

        [Test]
        public void SampleOfUsage_RegisterTypeAndInterface()
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
        public void SampleOfUsage_FewTypeResolves_OnEachResolveDifferentObject()
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
        public void SampleOfUsage_SingleInstance()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileLog>().SingleInstance();

            var container = builder.Build();

            var logger1 = container.Resolve<FileLog>();
            var logger2 = container.Resolve<FileLog>();

            logger1.Log("Hello from Logger 1");
            logger2.Log("Hello from Logger 2");

            Assert.That(logger1.UniqueId, Is.EqualTo(logger2.UniqueId));
        }

        [Test]
        public void SampleOfUsage_CarRegistration()
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
    }
}
