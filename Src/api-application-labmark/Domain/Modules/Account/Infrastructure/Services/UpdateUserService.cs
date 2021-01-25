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
            Pessoa pessoa = UserDtoMapToPessoa.Map(await _pessoaRepository.GetByID(usuario.FkPessoaId), userDto);

            bool isEditUser = IsEditUser(userDto, usuario);
            if (isEditUser)
            {
                if (userDto.Password != userDto.ConfirmPassword)
                {
                    throw new AppError($"Não foi possível atualizar o usuário. (Campo Confirmar senha informado, não corresponde com o campo Nova senha)", 401);
                }
                if (string.IsNullOrEmpty(userDto.OldPassword))
                {
                    throw new AppError($"Não foi possível atualizar o usuário. (Campo Senha anterior não foi informado)", 401);
                }
                bool isOldPassword = await _userMgr.CheckPasswordAsync(usuario, userDto.OldPassword);
                if (!isOldPassword)
                {
                    throw new AppError($"Não foi possível atualizar o usuário. (Campo senha anterior informada, não corresponde com a senha do usuário)", 401);
                }
                var userUpdated = await _userMgr.UpdateAsync(usuario);
                if (!userUpdated.Succeeded)
                {
                    throw new AppError($"Não foi possível atualizar o usuário. ({userUpdated.Errors.First().Description})", 401);
                }
            }
            _pessoaRepository.Save(pessoa);
            await _pessoaRepository.Commit();

            userDto.Password = "**********";
            userDto.ConfirmPassword = "**********";
            return userDto;
        }

        private bool IsEditUser(UserDto userDto, Usuario usuario)
        {
            if (userDto.Mail != usuario.Email)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                return true;
            }

            return false;
        }
    }
}
