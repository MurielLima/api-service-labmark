using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Account.Infrastructure.Mappers
{
    public static class UserDtoMapToPessoa
    {
        public static Pessoa Map(Pessoa pessoa, UserDto userDto)
        {
            pessoa.Nome = userDto.Name;
            pessoa.Email = userDto.Mail;
            pessoa.Bairro = userDto.Address.Neighborhood;
            pessoa.CEP = userDto.Address.Cep;
            pessoa.Logradouro = userDto.Address.Street;
            pessoa.Numero = userDto.Address.Number;
            pessoa.Telefone = userDto.Phone.Number;
            pessoa.DDD = userDto.Phone.Ddd;
            pessoa.TipoPessoa = "F";
            return pessoa;
        }
    }
}
