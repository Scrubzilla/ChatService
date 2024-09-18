using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enums;

namespace VismaSpcs.Recruitment.ChatService.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task UpdateStatusMessage(Guid id, string statusMessage);
        Task UpdateStatus(Guid id, UserStatusEnum newStatus);
        Task<List<UserEntity>> GetManyAsync(List<Guid> ids);
    }
}