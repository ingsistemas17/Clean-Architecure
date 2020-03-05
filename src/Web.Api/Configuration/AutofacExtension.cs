using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Web.Api.Core;
using Web.Api.Infrastructure;

namespace Web.Api.Configuration
{
    /// <summary>
    ///this extension is obsolete for net core 2.2
    /// </summary>
    internal static class AutofacExtension
    {

        internal static IServiceCollection AddAutofact(this IServiceCollection services, ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new InfrastructureModule());

            // Presenters
            //builder.RegisterType<RegisterUserPresenter>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();

            builder.Populate(services);

            return services;
        }

        internal static IApplicationBuilder UseAutofact(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "[Name]  API V1");
            });

            return app;
        }

    }
}
