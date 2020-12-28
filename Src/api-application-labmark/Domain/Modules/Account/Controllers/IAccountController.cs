using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Controllers
{
    public interface IAccountController
    {
        Task<IActionResult> ConfirmAccount([FromRoute] string userId, [FromRoute] string token);
        Task<IActionResult> Login([FromBody] UserLoginDto userDto);
        Task<IActionResult> Logout();
        Task<IActionResult> Register([FromBody] UserDto userDto);
        Task<IActionResult> List([FromRoute] int? employeeId);
        Task<IActionResult> Update([FromBody] UserDto userDto);
        Task<IActionResult> SendEmailConfirmation([FromBody] UserDto userDto);
    }
}