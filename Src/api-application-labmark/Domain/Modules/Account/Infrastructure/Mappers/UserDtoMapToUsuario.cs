using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Account.Infrastructure.Mappers
{
    public static class UserDtoMapToUsuario
    {
        public static Usuario Map(Usuario usuario, UserDto userDto)
        {
            usuario.NormalizedUserName = usuario.UserName = usuario.Email = usuario.NormalizedEmail = userDto.Mail;
            return usuario;
        }
    }
}
