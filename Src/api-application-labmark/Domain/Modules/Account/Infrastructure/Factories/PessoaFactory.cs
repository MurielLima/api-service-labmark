using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Account.Infrastructure.Factories
{
    public static class PessoaFactory
    {
        public static Pessoa Factory(Pessoa pessoa, UserDto userDto)
        {
            pessoa.Nome = userDto.Name;
            pessoa.Email = userDto.Mail;
            pessoa.Bairro = userDto.Address.Neighborhood;
            pessoa.Cep = userDto.Address.Cep;
            pessoa.Logradouro = userDto.Address.Street;
            pessoa.Numero = userDto.Address.Number;
            pessoa.Telefones.Add(new Telefone { Id = userDto.Phone.Id, Ddd = userDto.Phone.Ddd, Numero = userDto.Phone.Number });
            return pessoa;
        }
    }
}
