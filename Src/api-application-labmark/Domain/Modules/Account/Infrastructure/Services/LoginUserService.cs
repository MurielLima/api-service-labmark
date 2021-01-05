using System;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{
    public class LoginUserService : ILoginUserService
    {
        private readonly ILogger<ILoginUserService> _logger;
        private readonly UserManager<Usuario> _userMgr;
        private readonly SignInManager<Usuario> _signInMgr;
        public LoginUserService(ILogger<ILoginUserService> logger, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _logger = logger;
            _userMgr = userManager;
            _signInMgr = signInManager;
        }
        public async Task<UserLoginDto> Execute(UserLoginDto userLoginDto)
        {
            Usuario usuario;
            try
            {
                usuario = await _userMgr.FindByNameAsync(userLoginDto.Mail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new AppError($"Combinação email/senha incorretos.", 401);
            }
            if (usuario == null)
            {
                throw new AppError($"Combinação email/senha incorretos.", 401);
            }
            bool isConfirmAccount = await _userMgr.IsEmailConfirmedAsync(usuario);
            if (!isConfirmAccount)
            {
                throw new AppError("O administrador ainda não aprovou o email com seu cadastro.", 401);
            }
            var signIn = await _signInMgr.PasswordSignInAsync(userLoginDto.Mail, userLoginDto.Password, false, false);
            if (!signIn.Succeeded)
            {
                throw new AppError("Combinação email/senha incorretos.", 401);
            }
            userLoginDto.Password = "*********";
            return userLoginDto;
        }
    }
}
