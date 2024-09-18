using VismaSpcs.Recruitment.ChatService.Enums;

namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class UserEntity : BaseEntity<Guid>
    {
        public string UserName { get; set; }
        public DateTime LastOnline { get; set; }
        public string StatusMessage { get; set; }
        public UserStatusEnum Status { get; set; }
        public virtual ICollection<ContactEntity> Contacts { get; set; }
        public virtual ICollection<ConversationEntity> Conversations { get; set; }
    }
}