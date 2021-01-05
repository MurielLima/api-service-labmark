using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Factories;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly ILogger<IRegisterUserService> _logger;
        private readonly UserManager<Usuario> _userMgr;
        private readonly SignInManager<Usuario> _signInMgr;
        private readonly IPessoaRepository _pessoaRepository;
        public RegisterUserService(ILogger<IRegisterUserService> logger, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _userMgr = userManager;
            _signInMgr = signInManager;
            _pessoaRepository = pessoaRepository;
        }
        public async Task<UserDto> Execute(UserDto userDto)
        {
            if (userDto.Password != userDto.ConfirmPassword)
            {
                throw new AppError($"Não foi possível atualizar o usuário. (Campo Confirmar senha informado, não corresponde com o campo Nova senha)", 401);
            }

            Usuario usuario = UsuarioFactory.Factory(new Usuario(), userDto);
            Pessoa pessoa = PessoaFactory.Factory(new Pessoa(), userDto);

            _pessoaRepository.Insert(pessoa);
            await _pessoaRepository.Commit();
            usuario.FkPessoaId = pessoa.Id;

            var userCreated = await _userMgr.CreateAsync(usuario);
            if (!userCreated.Succeeded)
            {
                _pessoaRepository.Delete(pessoa);
                await _pessoaRepository.Commit();
                throw new AppError($"Não foi possível cadastrar o usuário. ({userCreated.Errors.First().Description})", 401);
            }
            var passwordUpdated = await _userMgr.AddPasswordAsync(usuario, userDto.Password);
            if (!passwordUpdated.Succeeded)
            {
                await _userMgr.DeleteAsync(usuario);
                _pessoaRepository.Delete(pessoa);
                await _pessoaRepository.Commit();
                throw new AppError($"Não foi possível cadastrar a senha para o usuário. ({passwordUpdated.Errors.First().Description})", 401);
            }
            userDto.Password = "**********";
            return userDto;
        }

    }
}
