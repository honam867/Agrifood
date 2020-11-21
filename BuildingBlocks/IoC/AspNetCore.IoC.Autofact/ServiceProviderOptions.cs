using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AspNetCore.IoC.Autofact
{
    public class ServiceProviderOptions
    {
        protected ContainerBuilder builder;
        public ServiceProviderOptions(ContainerBuilder builder)
        {
            this.builder = builder;
        }
        public void AddAsImplementedInterfaces(Assembly assembly, bool preserveExistingDefaults = true)
        {
            var register = this.builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            if (preserveExistingDefaults)
            {
                register.PreserveExistingDefaults();
            }
        }
        public void AddAsImplementedInterfaces(Type handlerAssemblyMarkerType, bool preserveExistingDefaults = true)
        {
            AddAsImplementedInterfaces(handlerAssemblyMarkerType.GetTypeInfo().Assembly, preserveExistingDefaults);

        }
    }
}

