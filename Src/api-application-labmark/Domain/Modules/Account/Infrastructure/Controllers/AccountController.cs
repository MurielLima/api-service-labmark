using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Labmark.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AccountController : ControllerBase, IAccountController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ILoginUserService _loginUserService;
        private readonly ILogoutUserService _logoutUserService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IListUserService _listUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IConfirmAccountService _confirmAccountService;
        private readonly ISendEmailConfirmationService _sendEmailConfirmationService;
        private readonly IResetPasswordService _resetPasswordService;

        public AccountController(ILogger<AccountController> logger, ILoginUserService loginUserService, ILogoutUserService logoutUserService, IRegisterUserService registerUserService, IConfirmAccountService confirmAccountService, ISendEmailConfirmationService sendEmailConfirmationService, IListUserService listUserService, IUpdateUserService updateUserService, IResetPasswordService resetPasswordService)
        {
            _logger = logger;
            _listUserService = listUserService;
            _loginUserService = loginUserService;
            _logoutUserService = logoutUserService;
            _updateUserService = updateUserService;
            _registerUserService = registerUserService;
            _confirmAccountService = confirmAccountService;
            _sendEmailConfirmationService = sendEmailConfirmationService;
            _resetPasswordService = resetPasswordService;
        }
        [HttpPost]
        public virtual async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            userDto = await _registerUserService.Execute(userDto);
            userDto = await _sendEmailConfirmationService.Execute(userDto);
            return Ok(new ResponseDto("success", userDto));
        }
        [HttpPost]
        public virtual async Task<IActionResult> SendEmailConfirmation([FromBody] UserDto userDto)
        {
            userDto = await _sendEmailConfirmationService.Execute(userDto);
            return Ok(new ResponseDto("success", userDto));
        }
        [HttpGet("{userId}/{token}")]
        public virtual async Task<IActionResult> ConfirmAccount([FromRoute] string userId, [FromRoute] string token)
        {
            UserDto userDto = await _confirmAccountService.Execute(userId, token);
            return Ok(new ResponseDto("success", userDto));
        }
        [HttpPut]
        public virtual async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            userLoginDto = await _loginUserService.Execute(userLoginDto);
            return Ok(new ResponseDto("success", userLoginDto));
        }
        [HttpPut]
        public virtual async Task<IActionResult> Logout()
        {
            UserDto userDto = await _logoutUserService.Execute();
            return Ok(new ResponseDto("success", "Logout feito com sucesso!"));
        }
        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            userDto = await _updateUserService.Execute(userDto);
            return Ok(new ResponseDto("success", userDto));
        }
        [HttpGet("{employeeId:int?}")]
        public virtual async Task<IActionResult> List([FromRoute] int? employeeId)
        {
            IList<EmployeeDto> usersDto = await _listUserService.Execute(employeeId);
            return Ok(new ResponseDto("success", usersDto));
        }
        [HttpGet]
        public virtual async Task<IActionResult> ResetPassword([FromRoute] string email)
        {
            bool sendMail = await _resetPasswordService.Execute(email);
            return Ok(new ResponseDto("success", new { isSendMail = sendMail }));
        }
    }
}
