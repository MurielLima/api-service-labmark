using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Labmark.Domain.Shared.Models.Dtos
{
    public class AuthMessageSenderOptionsDto
    {
        private readonly IConfiguration _configuration;
        public readonly string SendGridUser;
        public readonly string SendGridKey;
        public AuthMessageSenderOptionsDto(IConfiguration configuration)
        {
            SendGridUser = configuration["SendGrid:Email"];
            SendGridKey = configuration["SendGrid:Key"];
        }

    }
}
