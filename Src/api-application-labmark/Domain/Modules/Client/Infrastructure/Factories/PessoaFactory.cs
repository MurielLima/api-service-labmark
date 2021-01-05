using Labmark.Domain.Modules.Client.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Client.Infrastructure.Factories
{
    public static class PessoaFactory
    {
        public static Pessoa Factory(Pessoa pessoa, ClientDto clientDto)
        {
            pessoa.Nome = clientDto.Name;
            pessoa.Email = clientDto.Mail;
            pessoa.Bairro = clientDto.Address.Neighborhood;
            pessoa.Cep = clientDto.Address.Cep;
            pessoa.Logradouro = clientDto.Address.Street;
            pessoa.Numero = clientDto.Address.Number;
            foreach (var phone in clientDto.Phones)
                pessoa.Telefones.Add(new Telefone(phone.Ddd, phone.Number));
            pessoa.TipoPessoa = "F";
            return pessoa;
        }
    }
}
