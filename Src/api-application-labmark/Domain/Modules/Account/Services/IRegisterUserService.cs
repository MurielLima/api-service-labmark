using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Interfaces;

namespace Labmark.Domain.Modules.Account.Services
{
    public interface IRegisterUserService : IService<UserDto>
    {
        public Task<UserDto> Execute(UserDto userDto);
    }
}
