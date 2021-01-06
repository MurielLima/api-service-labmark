using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
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
            pessoa.TipoPessoa = clientDto.TypePerson.ToCharArray()[0];
            
            if (pessoa.TipoPessoa == 'F')
            {
                pessoa.PessoaFisica = new PessoaFisica();
                pessoa.PessoaFisica.Cpf = clientDto.Cpf;
            }
            else if (pessoa.TipoPessoa == 'J')
            {
                pessoa.PessoaJuridica = new PessoaJuridica();
                pessoa.PessoaJuridica.Cnpj = clientDto.Cnpj;
                pessoa.PessoaJuridica.InscricaoEstadual = clientDto.StateRegistration;
                pessoa.PessoaJuridica.ResponsavelTecnico = clientDto.TechnicalManager;
            }

            foreach (var phone in clientDto.Phones)
                pessoa.Telefones.Add(new Telefone { Id = phone.Id, Ddd = phone.Ddd, Numero = phone.Number});
            
            return pessoa;
        }
    }
}
