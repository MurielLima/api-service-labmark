using System.Collections.Generic;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Client.Infrastructure.Factories
{
    public static class ClientFactory
    {
        public static ClientDto Factory(Pessoa pessoa, ClientDto clientDto)
        {
            clientDto.Name = pessoa.Nome;
            clientDto.Mail = pessoa.Email;
            clientDto.Address = new AddressDto();
            clientDto.Address.Neighborhood = pessoa.Bairro;
            clientDto.TypePerson = pessoa.TipoPessoa.ToString();
            if (clientDto.TypePerson == "F")
            {
                clientDto.Cnpj = pessoa.PessoaFisica.Cpf;
            }
            else if (clientDto.TypePerson == "J")
            {
                clientDto.Cnpj = pessoa.PessoaJuridica.Cnpj;
                clientDto.StateRegistration = pessoa.PessoaJuridica.InscricaoEstadual;
                clientDto.TechnicalManager = pessoa.PessoaJuridica.ResponsavelTecnico;
            }
            clientDto.Address.Cep = pessoa.Cep;
            clientDto.Address.Street = pessoa.Logradouro;
            clientDto.Address.Number = pessoa.Numero;
            clientDto.Phones = new List<PhoneDto>();
            clientDto.Id = pessoa.Id;
            foreach (var phone in pessoa.Telefones)
                clientDto.Phones.Add(new PhoneDto { Id = phone.Id, Ddd = phone.Ddd, Number = phone.Numero });
            return clientDto;
        }
    }
}
