using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{
    public class LogoutUserService : ILogoutUserService
    {
        private readonly ILogger<ILogoutUserService> _logger;
        private readonly UserManager<Usuario> _userMgr;
        private readonly SignInManager<Usuario> _signInMgr;
        public LogoutUserService(ILogger<ILogoutUserService> logger, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _logger = logger;
            _userMgr = userManager;
            _signInMgr = signInManager;
        }
        public async Task<UserDto> Execute()
        {
            await _signInMgr.SignOutAsync();
            return new UserDto();
        }
    }
}
