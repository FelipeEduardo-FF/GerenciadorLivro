using System.Threading.Tasks;

namespace GerenciadorLivro.Infrastructure.Services
{
    public interface INotificationService
    {
        Task SendAsync(string subject, string content, string toEmail, string toName);
    }
}