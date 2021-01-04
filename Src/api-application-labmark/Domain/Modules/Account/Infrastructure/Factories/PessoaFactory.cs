using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            pessoa.Bairro = userDto.Neighborhood;
            pessoa.Cep = userDto.Cep;
            pessoa.Logradouro = userDto.Street;
            pessoa.Numero = userDto.Number;
            pessoa.Telefone = userDto.Phone;
            return pessoa;
        }
    }
}
