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
                clientDto.Cpf = pessoa.PessoaFisica.CPF;
            }
            else if (clientDto.TypePerson == "J")
            {
                clientDto.Cnpj = pessoa.PessoaJuridica.CNPJ;
                clientDto.StateRegistration = pessoa.PessoaJuridica.InscricaoEstadual;
                clientDto.TechnicalManager = pessoa.PessoaJuridica.ResponsavelTecnico;
            }
            clientDto.Address.Cep = pessoa.CEP;
            clientDto.Address.Street = pessoa.Logradouro;
            clientDto.Address.Number = pessoa.Numero;
            clientDto.Phones = new List<PhoneDto>();
            clientDto.Id = pessoa.Id;
            clientDto.Phones.Add(new PhoneDto { Ddd = pessoa.DDD, Number = pessoa.Telefone });

            return clientDto;
        }
    }
}
