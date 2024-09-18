using System.Net;
using Microsoft.AspNetCore.Mvc;
using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Services.Interface;

namespace VismaSpcs.Recruitment.ChatService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;
        private readonly ILogger<ConversationController> _logger;

        public ConversationController(IConversationService conversationService, ILogger<ConversationController> logger)
        {
            _conversationService = conversationService;
            _logger = logger;
        }
        
        [HttpPost("private")]
        public async Task<ActionResult<ConversationDto>> CreatePrivateConversation([FromBody] List<Guid> userIds)
        {
            try
            {
                var conversation = await _conversationService.CreateConversation("", false, userIds);
                return Ok(conversation);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        
        [HttpPost("group")]
        public async Task<ActionResult<ConversationDto>>  CreateGroupConversation([FromBody] GroupRequestDto groupDto)
        {
            try
            {
                var conversation = await _conversationService.CreateConversation(groupDto.Name, true, groupDto.ParticipantsIds);
                return Ok(conversation);
            } catch(Exception ex)
            {
                return NotFound();
            }
            
        }

        [HttpPost("send-message")]
        public async Task<ActionResult> SendMessage([FromBody] MessageDto message)
        {
            try
            {
                await _conversationService.SendMessage(message.ConversationId, message);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending the message.");
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while processing your request. " + ex.Message);       
            } 
        }
    }
}