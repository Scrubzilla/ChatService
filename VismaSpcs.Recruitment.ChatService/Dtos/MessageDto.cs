namespace VismaSpcs.Recruitment.ChatService.Dtos
{
    public class MessageDto : BaseDto<Guid>
    {
        public Guid ConversationId { get; set; }
        public Guid SenderId { get; set; }
        public string Content { get; set; }
    }
}