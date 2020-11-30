using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Infrastructure.Services;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Labmark.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ILoginUserService _loginUserService;
        private readonly ILogoutUserService _logoutUserService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IConfirmAccountService _confirmAccountService;
        private readonly ISendEmailConfirmationService _sendEmailConfirmationService;

        public AccountController(ILogger<AccountController> logger, ILoginUserService loginUserService, ILogoutUserService logoutUserService, IRegisterUserService registerUserService, IConfirmAccountService confirmAccountService, ISendEmailConfirmationService sendEmailConfirmationService)
        {
            _logger = logger;
            _loginUserService = loginUserService;
            _logoutUserService = logoutUserService;
            _registerUserService = registerUserService;
            _confirmAccountService = confirmAccountService;
            _sendEmailConfirmationService = sendEmailConfirmationService;
        }
        [HttpPost]
        public virtual async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            userDto = await _loginUserService.Execute(userDto);

            return Ok(userDto);
        }
        [HttpPut]
        public virtual async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            userDto = await _registerUserService.Execute(userDto);
            return Ok(userDto);
        }
        [HttpGet("{userId}/{token}")]
        public virtual async Task<IActionResult> ConfirmAccount([FromRoute] string userId,[FromRoute]string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            UserDto userDto = await _confirmAccountService.Execute(userId, token);
            return Ok(userDto);
        }
        [HttpPost]
        public virtual async Task<IActionResult> SendEmailConfirmation([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            userDto = await _sendEmailConfirmationService.Execute(userDto);
            return Ok(userDto);
        }
        [HttpPost]
        public virtual async Task<IActionResult> Logout([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            userDto = await _logoutUserService.Execute(userDto);
            return Ok(new ResponseDto("success", "Successfully logged out."));
        }
    }
}
