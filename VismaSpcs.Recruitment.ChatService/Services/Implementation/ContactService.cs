using VismaSpcs.Recruitment.ChatService.Repositories.Interface;
using VismaSpcs.Recruitment.ChatService.Services.Interface;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public async Task AddContactRequest(Guid userId, Guid contactUserId)
        { 
            await _contactRepository.AddContactRequest(userId, contactUserId);
        }
    }
}