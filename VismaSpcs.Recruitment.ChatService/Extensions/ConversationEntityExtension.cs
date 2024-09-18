using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Extensions
{
    public static class ConversationEntityExtension
    {
        public static ConversationDto MapToDto(this ConversationEntity conversationEntity)
        {
            return new ConversationDto
            {
                Id = conversationEntity.Id,
                Created = conversationEntity.Created,
                Name = conversationEntity.Name,
                Participants = conversationEntity.Participants.Select(p => p.MapToDto()).ToList(),
                //Todo; Implement message ToDto 
            };
        }
    }
}