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
    public class UpdateUserService : IUpdateUserService
    {
        private readonly ILogger<IUpdateUserService> _logger;
        private readonly UserManager<Usuario> _userMgr;
        private readonly SignInManager<Usuario> _signInMgr;
        private readonly IPessoaRepository _pessoaRepository;
        public UpdateUserService(ILogger<IUpdateUserService> logger, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _userMgr = userManager;
            _signInMgr = signInManager;
            _pessoaRepository = pessoaRepository;
        }
        public async Task<UserDto> Execute(UserDto userDto)
        {
            Usuario usuario = await _userMgr.FindByEmailAsync(userDto.Mail);
            Pessoa pessoa = PessoaFactory(await _pessoaRepository.GetByID(usuario.FkPessoaId), userDto);

            var userUpdated = await _userMgr.UpdateAsync(usuario);
            if (!userUpdated.Succeeded)
            {
                throw new AppError($"Não foi possível atualizar o usuário. ({userUpdated.Errors.First().Description})", 401);
            }
            _pessoaRepository.Save(pessoa);
            await _pessoaRepository.Commit();

            userDto.Password = "**********";
            userDto.ConfirmPassword = "**********";
            return userDto;
        }
        private Pessoa PessoaFactory(Pessoa pessoa, UserDto userDto)
        {
            pessoa.Nome = userDto.Name;
            pessoa.Email = userDto.Mail;
            pessoa.Bairro = userDto.Neighborhood;
            pessoa.Cep = userDto.Cep;
            pessoa.Logradouro = userDto.Street;
            pessoa.Numero = userDto.Number;
            return pessoa;
        }
    }
}
