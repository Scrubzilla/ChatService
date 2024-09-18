using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VismaSpcs.Recruitment.ChatService.Context;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enums;
using VismaSpcs.Recruitment.ChatService.Repositories.Implementation;
using VismaSpcs.Recruitment.ChatService.Repositories.Interface;

namespace VismaSpcs.Recruitment.ChatService.Repositories;

public class UserRepository  : GenericRepository<UserEntity>, IUserRepository
{
    private readonly ChatServiceDbContext _dbContext; 
    
    public UserRepository(ChatServiceDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<UserEntity?> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        return await _dbContext.Set<UserEntity>()
            .Include(u => u.Contacts)
            .FirstOrDefaultAsync(predicate);
    }
    public async Task UpdateStatusMessage(Guid id, string statusMessage)
    {
        var user = await _dbContext.Set<UserEntity>().FirstOrDefaultAsync(u => u.Id == id);
        
        if (user != null)
        {
            user.StatusMessage = statusMessage;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateStatus(Guid id, UserStatusEnum newStatus)
    {
        var user = await _dbContext.Set<UserEntity>().FirstOrDefaultAsync(u => u.Id == id);
        
        if (user != null)
        {
            user.Status = newStatus;
            _dbContext.Update(user);

            await _dbContext.SaveChangesAsync();
        }
    }
    
    public  async Task<List<UserEntity>> GetManyAsync(List<Guid> ids)
    {
        return await _dbContext.Set<UserEntity>().Where(u => ids.Contains(u.Id)).ToListAsync();
    }
}