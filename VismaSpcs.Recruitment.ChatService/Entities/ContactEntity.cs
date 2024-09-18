namespace VismaSpcs.Recruitment.ChatService.Entities;

public class ContactEntity : BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ContactUserId { get; set; }
    public bool IsAccepted { get; set; }
    
    public virtual UserEntity User { get; set; }
    public virtual UserEntity ContactUser { get; set; }
}