using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Extensions;
using VismaSpcs.Recruitment.ChatService.Repositories.Interface;
using VismaSpcs.Recruitment.ChatService.Services.Interface;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IUserService _userService;
        private readonly IConversationRepository _conversationRepository;
        
        public ConversationService(IConversationRepository conversationRepository, IUserService userService)
        {
            _conversationRepository = conversationRepository;
            _userService = userService;
        }
        
        public async Task<ConversationDto> CreateConversation(string groupName, bool isGroup, List<Guid> userIds)
        {
            var participants = await _userService.GetUsersById(userIds);
            
            if (participants == null || !participants.Any())
            {
                throw new ArgumentException("Participants cannot be null or empty");
            }

            var conversation = new ConversationEntity()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Name = groupName,
                IsGroup = isGroup,
                Participants = participants
            };
            
            var result = await _conversationRepository.AddConversation(conversation);
            
            return result.MapToDto();
        }
        
        public async Task SendMessage(Guid conversationId, MessageDto message)
        {
            var entity = new MessageEntity()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                ConversationId = conversationId,
                SenderId = message.SenderId,
                Content = message.Content,
            };
            
            await _conversationRepository.AddMessageToConversation(entity);
        }
    }
}