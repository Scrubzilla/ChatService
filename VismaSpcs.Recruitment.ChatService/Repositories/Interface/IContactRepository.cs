using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enums;

namespace VismaSpcs.Recruitment.ChatService.Repositories.Interface
{
    public interface IContactRepository : IGenericRepository<ContactEntity>
    {
        Task AddContactRequest(Guid userId, Guid contactUserId);
    }
}