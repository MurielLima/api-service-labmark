using System.Collections.Generic;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Client.Infrastructure.Mappers
{
    public static class ClientDtoMapToPessoa
    {
        public static Pessoa Map(Pessoa pessoa, ClientDto clientDto)
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
                pessoa.fkPessoaFisica = pessoa.fkPessoaFisica ?? new PessoaFisica();
                pessoa.fkPessoaFisica.Cpf = clientDto.Cpf;
                pessoa.fkPessoaJuridica = null;
            }
            else if (pessoa.TipoPessoa == 'J')
            {
                pessoa.fkPessoaJuridica = pessoa.fkPessoaJuridica ?? new PessoaJuridica();
                pessoa.fkPessoaJuridica.Cnpj = clientDto.Cnpj;
                pessoa.fkPessoaJuridica.InscricaoEstadual = clientDto.StateRegistration;
                pessoa.fkPessoaJuridica.ResponsavelTecnico = clientDto.TechnicalManager;
                pessoa.fkPessoaFisica = null;
            }
            pessoa.fkTelefones = pessoa.fkTelefones ?? new List<Telefone>();
            foreach (var phone in clientDto.Phones)
            {
                pessoa.fkTelefones.Add(new Telefone { Id = phone.Id, Ddd = phone.Ddd, Numero = phone.Number });
            }

            return pessoa;
        }
    }
}
