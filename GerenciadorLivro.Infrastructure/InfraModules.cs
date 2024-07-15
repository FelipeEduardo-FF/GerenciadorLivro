using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GerenciadorLivro.Domain.Repositories;
using GerenciadorLivro.Infrastructure.Persistence.Repositories;


namespace GerenciadorLivro.Infrastructure
{
    public static class InfraModules
    {

        public static IServiceCollection AddInfraModules(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddDbContext(configuration);
            service.AddRepo();
            return service;
        }

       public static IServiceCollection AddDbContext(this IServiceCollection service,IConfiguration configuration)
       {

            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return service;
       }

        public static IServiceCollection AddRepo(this IServiceCollection service)
        {

            service.AddScoped<IUserRepository,UserRepository>();
            return service;
        }
    }
}
