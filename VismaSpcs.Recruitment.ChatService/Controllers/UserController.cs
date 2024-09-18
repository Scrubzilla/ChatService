using Microsoft.AspNetCore.Mvc;
using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Enums;
using VismaSpcs.Recruitment.ChatService.Services;
using VismaSpcs.Recruitment.ChatService.Services.Interface;

namespace VismaSpcs.Recruitment.ChatService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserProfile(Guid id)
        {
            var user = await _userService.GetUserProfile(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}/status-message")]
        public async Task<IActionResult> UpdateStatusMessage(Guid id, [FromBody] string statusMessage)
        {
            await _userService.UpdateStatusMessage(id, statusMessage);
            return Ok();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UserStatusEnum status)
        {
            await _userService.UpdateStatus(id, status);
            return Ok();
        }
    }
}