using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GerenciadorLivro.Domain.Repositories;
using GerenciadorLivro.Infrastructure.Persistence.Repositories;
using GerenciadorLivro.Infrastructure.Services;
using System.Text.Json;


namespace GerenciadorLivro.Infrastructure
{
    public static class InfraModules
    {

        public static IServiceCollection AddInfraModules(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddDbContext(configuration);
            service.AddRepo();
            service.AddServices(configuration);  
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
            service.AddScoped<IBookRepository,BookRepository>();
            service.AddScoped<ILoanRepository,LoanRepository>();
            return service;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            var config = new MailConfig();

            configuration.GetSection("Notifications").Bind(config) ;


            service.AddSingleton<MailConfig>(m => config);

            service.AddScoped<INotificationService, NotificationService>();

            return service;
        }
    }
}
