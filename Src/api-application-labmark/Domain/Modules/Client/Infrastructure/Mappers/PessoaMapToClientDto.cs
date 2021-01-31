using System.Collections.Generic;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Client.Infrastructure.Mappers
{
    public static class PessoaMapToClientDto
    {
        public static ClientDto Map(ClientDto clientDto, Pessoa pessoa)
        {
            clientDto.Name = pessoa.Nome;
            clientDto.Mail = pessoa.Email;
            clientDto.Address = new AddressDto();
            clientDto.Address.Neighborhood = pessoa.Bairro;
            clientDto.TypePerson = pessoa.TipoPessoa.ToString();
            if (clientDto.TypePerson == "F")
            {
                clientDto.Cpf = pessoa.fkPessoaFisica.Cpf;
            }
            else if (clientDto.TypePerson == "J")
            {
                clientDto.Cnpj = pessoa.fkPessoaJuridica.Cnpj;
                clientDto.StateRegistration = pessoa.fkPessoaJuridica.InscricaoEstadual;
                clientDto.TechnicalManager = pessoa.fkPessoaJuridica.ResponsavelTecnico;
            }
            clientDto.Address.Cep = pessoa.Cep;
            clientDto.Address.Street = pessoa.Logradouro;
            clientDto.Address.Number = pessoa.Numero;
            clientDto.Phones = new List<PhoneDto>();
            clientDto.Id = pessoa.Id;
            foreach (var phone in pessoa.fkTelefones)
            {
                clientDto.Phones.Add(new PhoneDto { Id = phone.Id, Ddd = phone.Ddd, Number = phone.Numero });
            }

            return clientDto;
        }
    }
}
