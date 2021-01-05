using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Account.Infrastructure.Factories
{
    public static class UsuarioFactory
    {
        public static Usuario Factory(Usuario usuario, UserDto userDto)
        {
            usuario.NormalizedUserName = usuario.UserName = usuario.Email = usuario.NormalizedEmail = userDto.Mail;
            return usuario;
        }
    }
}
