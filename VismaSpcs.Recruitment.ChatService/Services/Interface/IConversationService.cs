using VismaSpcs.Recruitment.ChatService.Dtos;

namespace VismaSpcs.Recruitment.ChatService.Services.Interface;

public interface IConversationService
{
    Task<ConversationDto> CreateConversation(string groupName, bool isGroup, List<Guid> userIds);
    Task SendMessage(Guid conversationId, MessageDto message);
}