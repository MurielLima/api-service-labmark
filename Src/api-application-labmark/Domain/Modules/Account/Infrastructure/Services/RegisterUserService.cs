using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Labmark.Domain.Modules.Account.Infrastructure.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly ILogger<IRegisterUserService> _logger;
        private readonly UserManager<Usuario> _userMgr;
        private readonly SignInManager<Usuario> _signInMgr;
        public RegisterUserService(ILogger<IRegisterUserService> logger, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _logger = logger;
            _userMgr = userManager;
            _signInMgr = signInManager;
        }
        public async Task<UserDto> Execute(UserDto userDto)
        {
            Usuario usuario = UsuarioFactory(userDto);
            var userCreated = await _userMgr.CreateAsync(usuario);
            if (!userCreated.Succeeded)
            {
                throw new AppError(userCreated.Errors.Select(x => x.Description), 401);
            }
            var passwordUpdated = await _userMgr.AddPasswordAsync(usuario, userDto.Password);
            if (!passwordUpdated.Succeeded)
            {
                throw new AppError(passwordUpdated.Errors.Select(x => x.Description), 401);
            }
            userDto.Password = "**********";
            return userDto;
        }
        private Usuario UsuarioFactory(UserDto userDto)
        {
            Usuario usuario = new Usuario();
            usuario.NormalizedUserName = usuario.UserName = usuario.Email = usuario.NormalizedEmail = userDto.Email;
            usuario.FkPessoaId = userDto.IdPessoa;
            return usuario;
        }
        private Pessoa PessoaFactory(UserDto userDto)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = userDto.Nome;
            pessoa.Email = userDto.Email;
            pessoa.Bairro = userDto.Bairro;
            pessoa.Cep = userDto.Cep;
            pessoa.Logradouro = userDto.Logradouro;
            pessoa.Numero = userDto.Numero;
            //Pessoa pessoa = new Pessoa(
            //{
            //    Nome = userDto.Nome,
            //    Email = userDto.Email,
            //    Bairro = userDto.Bairro,
            //    Cep = userDto.Cep,
            //    Logradouro = userDto.Logradouro,
            //    Numero = userDto.Numero
            //});
            return pessoa;
        }
    }
}
