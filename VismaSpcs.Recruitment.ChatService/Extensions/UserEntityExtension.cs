using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Extensions
{
    public static class UserEntityExtension
    {
        public static UserDto MapToDto(this UserEntity userEntity)
        {
            return new UserDto
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                LastOnline = userEntity.LastOnline,
                StatusMessage = userEntity.StatusMessage,
                Status = userEntity.Status,
                Contacts = userEntity.Contacts.Select(c => c.MapToDto()).ToList(),
                Conversations = userEntity.Conversations.Select(c => c.MapToDto()).ToList(),
            };
        }
    }
}