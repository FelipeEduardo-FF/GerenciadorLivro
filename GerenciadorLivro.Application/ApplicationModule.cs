using GerenciadorLivro.Application.HostedServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection service)
        {
            service.AddMediator();
            service.AddHosted();

            return service;
        }        
        public static IServiceCollection AddMediator(this IServiceCollection service)
        {

            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return service;
        }

        public static IServiceCollection AddHosted(this IServiceCollection service)
        {

            service.AddHostedService<NotiificationHostedService>();
            return service;
        }
    }
}
