using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Account.Services
{
    public interface IListUserService
    {
        public Task<IList<EmployeeDto>> Execute(int? employeeId);
    }
}
