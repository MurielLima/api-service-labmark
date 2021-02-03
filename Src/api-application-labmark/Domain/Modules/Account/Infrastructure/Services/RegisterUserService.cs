using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Mappers;
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

            Usuario usuario = UserDtoMapToUsuario.Map(new Usuario(), userDto);
            Pessoa pessoa = UserDtoMapToPessoa.Map(new Pessoa(), userDto);

            var userCreated = await _userMgr.CreateAsync(usuario);
            if (!userCreated.Succeeded)
            {
                throw new AppError($"Não foi possível cadastrar o usuário. ({userCreated.Errors.First().Description})", 401);
            }
            var passwordUpdated = await _userMgr.AddPasswordAsync(usuario, userDto.Password);
            if (!passwordUpdated.Succeeded)
            {
                await _userMgr.DeleteAsync(usuario);
                throw new AppError($"Não foi possível cadastrar a senha para o usuário. ({passwordUpdated.Errors.First().Description})", 401);
            }
            _pessoaRepository.Insert(pessoa);
            await _pessoaRepository.Commit();
            usuario.FkPessoaId = pessoa.Id;
            usuario.EmailConfirmed = true;
            var pessoaUpdated = await _userMgr.UpdateAsync(usuario);
            if (!pessoaUpdated.Succeeded)
            {
                await _userMgr.DeleteAsync(usuario);
                throw new AppError($"Não foi possível criar os dados para o usuário. ({pessoaUpdated.Errors.First().Description})", 401);
            }
            userDto.Password = "**********";
            userDto.ConfirmPassword = "**********";
            return userDto;
        }

    }
}
