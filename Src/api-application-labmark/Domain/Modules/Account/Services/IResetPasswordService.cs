using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Account.Services
{
    public interface IResetPasswordService
    {
        public Task<bool> Execute(string email);
    }
}
