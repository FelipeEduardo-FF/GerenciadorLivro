using GerenciadorLivro.Domain.Model;
using GerenciadorLivro.Domain.Repositories;
using GerenciadorLivro.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.HostedServices
{
    public class NotiificationHostedService: BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public NotiificationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var loans = await GetExpiredLoan();
                foreach (var loan in loans)
                {
                    await SendEmail(loan);
                }

                await Task.Delay(TimeSpan.FromDays(3), stoppingToken);
            }
        }
        private async Task<List<Loan>> GetExpiredLoan()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var loanRepository = scope.ServiceProvider.GetService<ILoanRepository>();
                return await loanRepository.GetExpired();
            }

        }

        private async Task<bool> SendEmail(Loan loan)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var emailService = scope.ServiceProvider.GetService<INotificationService>();

                var subject = "Livro atrasado";
                var content = "Seu livro esta pendente, realize a entrega";

                await emailService.SendAsync(subject, content, loan.User.Email, loan.User.Nome);

                return true;
            }
        }
    }
}
