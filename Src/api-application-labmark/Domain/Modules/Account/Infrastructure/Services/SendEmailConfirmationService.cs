using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Domain.Shared.Providers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{
    public class SendEmailConfirmationService : ISendEmailConfirmationService
    {
        private readonly ILogger<IRegisterUserService> _logger;
        private readonly UserManager<Usuario> _userMgr;
        private readonly SignInManager<Usuario> _signInMgr;
        private readonly IMailProvider _mailProvider;
        private readonly ITemplateMailProvider _templateMailProvider;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public SendEmailConfirmationService(ILogger<IRegisterUserService> logger, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IMailProvider mailProvider, ITemplateMailProvider templateMailProvider, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _userMgr = userManager;
            _signInMgr = signInManager;
            _mailProvider = mailProvider;
            _templateMailProvider = templateMailProvider;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<UserDto> Execute(UserDto userDto)
        {
            Usuario usuario = await _userMgr.FindByNameAsync(userDto.Mail);
            if (usuario == null)
            {
                throw new AppError($"Usuário não foi encontrado (Email: '{userDto.Mail}').", 401);
            }
            string token = await _userMgr.GenerateEmailConfirmationTokenAsync(usuario);
            if (string.IsNullOrEmpty(token))
            {
                throw new AppError($"O token de verificação não pôde ser gerado.", 401);
            }
            string body = createMail(userDto, token, usuario.Id);

            bool isSendConfirmationEmail = await _mailProvider.Execute("Confirmação de conta", body, userDto.Mail);
            if (!isSendConfirmationEmail)
            {
                throw new AppError($"Não foi possível enviar o email de confirmação. Tente novamente mais tarde.", 401);
            }
            return userDto;
        }
        private string createMail(UserDto userDto, string token, int userId)
        {
            token = Base64UrlEncoder.Encode(token);
            string baseUrl = _hostingEnvironment.WebRootPath;
            string body = _templateMailProvider.GetTemplateHtml("MailDefault");
            body = body.Replace("#ReceiverName#", userDto.Name);
            body = body.Replace("#Message#", @$"Recebemos a solicitação de criar um novo usuario para:
                                                Email: {userDto.Mail}");
            body = body.Replace("#Description#", "Por medidas de segurança precisamos que confirme o cadastro para que possamos liberar o acesso.");
            body = body.Replace("#Url#", $"{baseUrl}/api/v1/Account/ConfirmAccount/{userId}/{token}");
            return body;
        }
    }
}
