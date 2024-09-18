using VismaSpcs.Recruitment.ChatService.Context;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Repositories.Interface;

namespace VismaSpcs.Recruitment.ChatService.Repositories.Implementation;

public class ContactRepository : GenericRepository<ContactEntity>, IContactRepository
{
    private readonly ChatServiceDbContext _dbContext;

    public ContactRepository(ChatServiceDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddContactRequest(Guid userId, Guid contactUserId)
    {
        var contactEntity = new ContactEntity()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            ContactUserId = contactUserId,
            IsAccepted = false,
            Created = DateTime.UtcNow,
        };

        await _dbContext.Set<ContactEntity>().AddAsync(contactEntity);
        await _dbContext.SaveChangesAsync();
    }
}