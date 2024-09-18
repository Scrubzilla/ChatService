namespace VismaSpcs.Recruitment.ChatService.Services.Interface
{
    public interface IContactService
    {
        Task AddContactRequest(Guid userId, Guid contactUserId);
    }
}