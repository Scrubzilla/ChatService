using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Repositories.Interface
{
    public interface IConversationRepository : IGenericRepository<ConversationEntity>
    {
        Task<ConversationEntity> AddConversation(ConversationEntity conversation);
        Task AddMessageToConversation(MessageEntity message);
    }
}