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
        private readonly UserManager<Usuario> _userMgr;
        public ListUserService(ILogger<IRegisterUserService> logger, IPessoaRepository pessoaRepository, UserManager<Usuario> userMgr)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
            _userMgr = userMgr;
        }
        public async Task<IList<EmployeeDto>> Execute(int? employeeId)
        {
            IList<EmployeeDto> employeesDto = new List<EmployeeDto>();
            IList<Pessoa> pessoas = new List<Pessoa>();

            if (employeeId > 0)
            {
                Pessoa pessoa = await _pessoaRepository.GetByID((int)employeeId);
                if (pessoa != null && pessoa.TipoAcesso.Equals('U'))
                {
                    pessoas.Add(pessoa);
                }
            }
            else
            {
                pessoas = await _pessoaRepository.ListAllUsers();
            }
            if (pessoas.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhum funcionário.", 404);
            }
            foreach (Pessoa x in pessoas)
            {
                employeesDto.Add(EmployeeDtoFactory(x));
            }

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
            Telefone telefone = pessoa.fkTelefones.First();
            employeeDto.Phone = new PhoneDto { Id = telefone.Id, Ddd = telefone.Ddd, Number = telefone.Numero };
            return employeeDto;
        }
    }
}
