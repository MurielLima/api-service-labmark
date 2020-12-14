using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Controllers
{
    public interface IAccountController
    {
        Task<IActionResult> ConfirmAccount([FromRoute] string userId, [FromRoute] string token);
        Task<IActionResult> Login([FromBody] UserDto userDto);
        Task<IActionResult> Logout([FromBody] UserDto userDto);
        Task<IActionResult> Register([FromBody] UserDto userDto);
        Task<IActionResult> SendEmailConfirmation([FromBody] UserDto userDto);
    }
}