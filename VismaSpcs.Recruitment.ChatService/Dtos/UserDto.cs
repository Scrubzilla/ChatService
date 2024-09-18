using VismaSpcs.Recruitment.ChatService.Enums;

namespace VismaSpcs.Recruitment.ChatService.Dtos
{
    public class UserDto:BaseDto<Guid>
    {
        public string UserName { get; set; }
        public DateTime LastOnline { get; set; }
        public string StatusMessage { get; set; }
        public UserStatusEnum Status { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public List<ConversationDto> Conversations { get; set; }
    }
}