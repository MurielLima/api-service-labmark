using System;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Domain.Shared.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{
    public class ResetPasswordService : IResetPasswordService
    {
        private readonly UserManager<Usuario> _userMgr;
        private readonly ILogger<IResetPasswordService> _logger;
        private readonly ITemplateMailProvider _templateMailProvider;
        private readonly IMailProvider _mailProvider;
        private readonly IPessoaRepository _pessoaRepository;

        public ResetPasswordService(ILogger<IResetPasswordService> logger, UserManager<Usuario> userManager, ITemplateMailProvider templateMailProvider, IMailProvider mailProvider, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _userMgr = userManager;
            _mailProvider = mailProvider;
            _templateMailProvider = templateMailProvider;
            _pessoaRepository = pessoaRepository;
        }
        public async Task<bool> Execute(string email)
        {
            Usuario usuario = await _userMgr.FindByEmailAsync(email);
            if (usuario == null)
            {
                throw new AppError("Erro ao enviar email de renovação de senha (O usuário não foi encontrado)", 404);
            }

            string password = Guid.NewGuid().ToString().Substring(1, 3) + ".." + Guid.NewGuid().ToString().Substring(1, 3);
            var removePassword = await _userMgr.RemovePasswordAsync(usuario);
            if (!removePassword.Succeeded)
            {
                throw new AppError("Erro ao enviar email de renovação de senha (Não foi possível remover a senha anterior do usuário)", 401);
            }

            var addPassword = await _userMgr.AddPasswordAsync(usuario, password);
            if (!addPassword.Succeeded)
            {
                throw new AppError("Erro ao enviar email de renovação de senha (Não foi possível configurar a senha provisória do usuário)", 401);
            }

            Pessoa pessoa = await _pessoaRepository.FindByEmail(usuario.Email);
            string body = createMail(pessoa, password);

            bool isSendConfirmationEmail = await _mailProvider.Execute("Confirmação de conta", body, usuario.Email);
            if (!isSendConfirmationEmail)
            {
                throw new AppError($"Não foi possível enviar o email de confirmação. Tente novamente mais tarde.", 401);
            }
            return true;
        }
        private string createMail(Pessoa pessoa, string password)
        {
            password = Base64UrlEncoder.Encode(password);
            string baseUrl = "https://localhost:5001";
            string body = _templateMailProvider.GetTemplateHtml("MailDefault");
            body = body.Replace("#ReceiverName#", pessoa.Nome);
            body = body.Replace("#Message#", @$"Recebemos a solicitação de recuperação de senha para:
                                                Email: {pessoa.Email}");
            body = body.Replace("#Description#", @$"Estamos enviando uma senha provisória para seu acesso ao sistema.
                                                 Senha: {pessoa}
                                                 Por medidas de segurança precisamos que acesse o sistema com a senha informada e cadastre uma nova senha de sua confiança.");
            body = body.Replace("#Url#", $"{baseUrl}/Account/Login");
            return body;
        }
    }
}
