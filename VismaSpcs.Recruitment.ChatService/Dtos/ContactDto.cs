namespace VismaSpcs.Recruitment.ChatService.Dtos
{
    public class ContactDto : BaseDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ContactUserId { get; set; }
        public bool IsAccepted { get; set; }
    }
}