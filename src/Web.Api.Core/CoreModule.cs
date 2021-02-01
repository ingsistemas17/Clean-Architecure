using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Core.UseCases;

namespace Web.Api.Core
{
    public class CoreModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<VentaUseCase>().As<IVentaUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<FacturaUseCase>().As<IFacturaUseCase>().InstancePerLifetimeScope();
        }
            
    }
}
