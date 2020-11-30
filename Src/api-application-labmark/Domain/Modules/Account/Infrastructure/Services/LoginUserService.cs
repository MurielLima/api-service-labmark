using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<UserDto> Execute(UserDto userDto)
        {
            Usuario usuario = await _userMgr.FindByNameAsync(userDto.Email);
            if (usuario == null)
            {
                throw new AppError($"User with email: '{userDto.Email}' not found", 401);
            }
            bool isConfirmAccount = await _userMgr.IsEmailConfirmedAsync(usuario);
            if (!isConfirmAccount)
            {
                throw new AppError("User cannot sign in without a confirmed account.", 401);
            }
            var signIn = await _signInMgr.PasswordSignInAsync(userDto.Email, userDto.Password, false, false);
            if (!signIn.Succeeded)
            {
                throw new AppError("Incorrect email/password combination.", 401);
            }
            return userDto;
        }
    }
}
