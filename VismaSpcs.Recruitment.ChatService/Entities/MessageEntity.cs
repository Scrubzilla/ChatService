namespace VismaSpcs.Recruitment.ChatService.Entities
{
    public class MessageEntity : BaseEntity<Guid>
    {
        public Guid ConversationId { get; set; }
        public Guid SenderId { get; set; }
        public string Content { get; set; }
        public virtual ConversationEntity Conversation { get; set; }
        public virtual UserEntity Sender { get; set; }
    }
}