using System.Linq.Expressions;

namespace VismaSpcs.Recruitment.ChatService.Repositories.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    }
}