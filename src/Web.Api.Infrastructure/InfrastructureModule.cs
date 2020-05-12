using Autofac;
using System;
using System.Collections.Generic;

using System.Text;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.Services;
using Web.Api.Infrastructure.Auth;
using Web.Api.Infrastructure.Data.Repository;

namespace Web.Api.Infrastructure
{
    public class InfrastructureModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();

            builder.RegisterType<Repository>().As<IRepository>().InstancePerLifetimeScope();
        }
    }
}
