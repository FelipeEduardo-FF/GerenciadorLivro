using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;


namespace GerenciadorLivro.Infrastructure.Services
{

    public class From
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class Recipient
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class EmailPayload
    {
        public From From { get; set; }
        public Recipient[] To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
    }
    public class NotificationService : INotificationService
    {
        private readonly HttpClient httpclient;

        private EmailPayload emailPayload;
        private const string url = "https://api.mailersend.com/v1/email";
        public NotificationService(HttpClient httpclient, MailConfig config)
        {
            this.httpclient = httpclient;
            httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer "+config.ApiToken);

            emailPayload = new EmailPayload {
                From = new From
                {
                    Email = config.FromEmail,
                    Name = config.FromName
                }
            };
        }

        public async Task SendAsync(string subject, string content, string toEmail, string toName){
            emailPayload.Html = content;
            emailPayload.Subject = subject;
            emailPayload.To = new[] {
                new Recipient
                {
                    Email = toEmail,
                    Name = toName
                } 
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var jsonPayload = JsonConvert.SerializeObject(emailPayload, settings);
            var contentEmail = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await httpclient.PostAsync(url, contentEmail);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

        }
    }
}