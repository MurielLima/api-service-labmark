using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;
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
            if(pessoas.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhum funcionário.",404);
            }
            foreach(Pessoa x in pessoas)
                employeesDto.Add(EmployeeDtoFactory(x));

            return employeesDto;
        }
        private EmployeeDto EmployeeDtoFactory(Pessoa pessoa)
        {
            EmployeeDto employeeDto = new EmployeeDto();
            employeeDto.Id = pessoa.Id;
            employeeDto.Name = pessoa.Nome;
            employeeDto.Mail = pessoa.Email;
            employeeDto.Neighborhood = pessoa.Bairro;
            employeeDto.Cep = pessoa.Cep;
            employeeDto.Street = pessoa.Logradouro;
            employeeDto.Number = pessoa.Numero;
            employeeDto.Phone = pessoa.Telefone;
            return employeeDto;
        }
    }
}
