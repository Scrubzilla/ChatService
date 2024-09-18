using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Entities;

namespace VismaSpcs.Recruitment.ChatService.Extensions
{
    public static class ContactEntityExtension
    {
        public static ContactDto MapToDto(this ContactEntity contactEntity)
        {
            return new ContactDto
            {
                Id = contactEntity.Id,
                UserId = contactEntity.UserId,
                ContactUserId = contactEntity.ContactUserId,
                IsAccepted = contactEntity.IsAccepted,
            };
        }
    }
}