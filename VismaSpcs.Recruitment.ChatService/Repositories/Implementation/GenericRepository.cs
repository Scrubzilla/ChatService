using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VismaSpcs.Recruitment.ChatService.Context;
using VismaSpcs.Recruitment.ChatService.Repositories.Interface;

namespace VismaSpcs.Recruitment.ChatService.Repositories.Implementation
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ChatServiceDbContext _dbContext;

        public GenericRepository(ChatServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var res = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return res;
        }
    }
}