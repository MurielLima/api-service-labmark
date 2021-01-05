using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Models;

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
            pessoa.Telefones.Add(new Telefone(userDto.Phone.Substring(0,2), userDto.Phone.Substring(2)));
            pessoa.TipoPessoa = "F";
            return pessoa;
        }
    }
}
