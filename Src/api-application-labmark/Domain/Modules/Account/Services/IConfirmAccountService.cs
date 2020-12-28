using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Account.Services
{
    public interface IConfirmAccountService
    {
        public Task<UserDto> Execute(string userId, string token);
    }
}
