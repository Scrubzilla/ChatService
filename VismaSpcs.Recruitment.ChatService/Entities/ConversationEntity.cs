namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class ConversationEntity : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public bool IsGroup { get; set; }
        public virtual ICollection<UserEntity> Participants { get; set; } = new List<UserEntity>();
        public virtual ICollection<MessageEntity> Messages { get; set; } = new List<MessageEntity>();
    }
}