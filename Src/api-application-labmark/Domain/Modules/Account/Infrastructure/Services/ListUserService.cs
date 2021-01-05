﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{
    public class ListUserService : IListUserService
    {
        private readonly ILogger<IRegisterUserService> _logger;
        private readonly IPessoaRepository _pessoaRepository;
        public ListUserService(ILogger<IRegisterUserService> logger, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }
        public async Task<IList<EmployeeDto>> Execute(int? employeeId)
        {
            IList<EmployeeDto> employeesDto = new List<EmployeeDto>();
            IList<Pessoa> pessoas = new List<Pessoa>();

            if (employeeId > 0)
            {
                Pessoa pessoa = await _pessoaRepository.GetByID((int)employeeId);
                if (pessoa != null)
                {
                    pessoas.Add(pessoa);
                }
            }
            else
            {
                pessoas = await _pessoaRepository.Get();
            }
            if (pessoas.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhum funcionário.", 404);
            }
            foreach (Pessoa x in pessoas)
                employeesDto.Add(EmployeeDtoFactory(x));

            return employeesDto;
        }
        private EmployeeDto EmployeeDtoFactory(Pessoa pessoa)
        {
            EmployeeDto employeeDto = new EmployeeDto();
            employeeDto.Id = pessoa.Id;
            employeeDto.Name = pessoa.Nome;
            employeeDto.Mail = pessoa.Email;
            employeeDto.Address = new AddressDto();
            employeeDto.Address.Neighborhood = pessoa.Bairro;
            employeeDto.Address.Cep = pessoa.Cep;
            employeeDto.Address.Street = pessoa.Logradouro;
            employeeDto.Address.Number = pessoa.Numero;
            Telefone telefone = pessoa.Telefones.First();
            employeeDto.Phone = new PhoneDto(telefone.Ddd, telefone.Numero);
            return employeeDto;
        }
    }
}
