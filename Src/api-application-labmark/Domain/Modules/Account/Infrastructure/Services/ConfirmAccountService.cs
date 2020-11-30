using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{

    public class ConfirmAccountService : IConfirmAccountService
    {
        private readonly ILogger<IConfirmAccountService> _logger;
        private readonly UserManager<Usuario> _userMgr;
        private readonly SignInManager<Usuario> _signInMgr;
        public ConfirmAccountService(ILogger<IConfirmAccountService> logger, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _logger = logger;
            _userMgr = userManager;
            _signInMgr = signInManager;
        }
        public async Task<UserDto> Execute(string userId, String token)
        {
            Usuario usuario = await _userMgr.FindByIdAsync(userId.ToString());
            if(usuario == null)
            {
                throw new AppError($"User with id: '{userId}' not found", 401);
            }
            token = Base64UrlEncoder.Decode(token);
            var confirmAccount = await _userMgr.ConfirmEmailAsync(usuario, token);
            if (!confirmAccount.Succeeded)
            {
                throw new AppError($"Token ['{token}'] has expired, request a new one", 401);
            }
            return UserDtoFactory(usuario);
        }
        private UserDto UserDtoFactory(Usuario usuario)
        {
            UserDto userDto = new UserDto();
            userDto.Email = usuario.Email;
            userDto.Password = "*********";
            userDto.IdPessoa = (int)usuario.FkPessoaId;
            return userDto;
        }
    }
}
