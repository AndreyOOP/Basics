using System;
using Autofac.Core;

namespace Autofac
{
    public class AutofacLogModule : Module
    {
        // called on each component registration
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            //registration.Preparing
            //registration.Activating
            registration.Activated += LogComponentActivation;
            base.AttachToComponentRegistration(componentRegistry, registration);
        }

        private void LogComponentActivation(object sender, ActivatedEventArgs<object> activatedEventArgs)
        {
            Console.WriteLine($"{activatedEventArgs.Instance} - activated");
        }
    }
}
