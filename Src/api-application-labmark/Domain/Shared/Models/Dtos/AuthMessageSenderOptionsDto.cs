using Microsoft.Extensions.Configuration;

namespace Labmark.Domain.Shared.Models.Dtos
{
    public class AuthMessageSenderOptionsDto
    {
        public readonly string SendGridUser;
        public readonly string SendGridKey;
        public AuthMessageSenderOptionsDto(IConfiguration configuration)
        {
            SendGridUser = configuration["SendGrid:Email"];
            SendGridKey = configuration["SendGrid:Key"];
        }

    }
}
