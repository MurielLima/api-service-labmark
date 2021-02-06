using System.Collections.Generic;
using System.Linq;
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
            pessoa.CEP = clientDto.Address.Cep;
            pessoa.Logradouro = clientDto.Address.Street;
            pessoa.Numero = clientDto.Address.Number;
            pessoa.TipoPessoa = clientDto.TypePerson;
            pessoa.Complemento = clientDto.Address.Additional;


            if (pessoa.TipoPessoa == "F")
            {
                pessoa.PessoaFisica = pessoa.PessoaFisica ?? new PessoaFisica();
                pessoa.PessoaFisica.CPF = clientDto.Cpf;
                pessoa.PessoaJuridica = null;
            }
            else if (pessoa.TipoPessoa == "J")
            {
                pessoa.PessoaJuridica = pessoa.PessoaJuridica ?? new PessoaJuridica();
                pessoa.PessoaJuridica.CNPJ = clientDto.Cnpj;
                pessoa.PessoaJuridica.InscricaoEstadual = clientDto.StateRegistration;
                pessoa.PessoaJuridica.ResponsavelTecnico = clientDto.TechnicalManager;
                pessoa.PessoaFisica = null;
            }

            return pessoa;
        }
    }
}
