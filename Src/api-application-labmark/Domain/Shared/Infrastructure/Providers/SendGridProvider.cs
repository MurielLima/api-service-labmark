using System.Threading.Tasks;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Domain.Shared.Providers;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Labmark.Domain.Shared.Infrastructure.Providers
{
    public class SendGridProvider : IMailProvider
    {
        private readonly AuthMessageSenderOptionsDto _options;//set only via Secret Manager
        public SendGridProvider(AuthMessageSenderOptionsDto options)
        {
            _options = options;
        }

        public async Task<bool> Execute(string subject, string message, string email)
        {
            SendGridClient client = new SendGridClient(_options.SendGridKey);
            EmailAddress from = new EmailAddress("luisgkingeski@gmail.com", "Laboratório de Microbiologia de Alimentos - LABMARK");
            EmailAddress to = new EmailAddress(email, email);
            string plainTextContent = message;
            string htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            Response response = await client.SendEmailAsync(msg);
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new AppError(response.Body, 401);
            }
            return true;
        }
    }
}
