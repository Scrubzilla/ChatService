using Microsoft.AspNetCore.Mvc;
using VismaSpcs.Recruitment.ChatService.Services.Interface;

namespace VismaSpcs.Recruitment.ChatService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IUserService _userService;

        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService contactService,IUserService  userService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _userService = userService;
            _logger = logger;
        }
        
        [HttpPost("request")]
        public async Task<ActionResult>  AddContactRequest([FromBody] Guid userId, Guid contactUserId)
        {
            var user = await _userService.GetUserProfile(userId);
            if(user == null) return NotFound();

            var contactUser = await _userService.GetUserProfile(contactUserId);
            if(contactUser == null) return NotFound();
            
            await _contactService.AddContactRequest(userId, contactUserId);
            
            return Ok();
        }
    }
}