using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enums;

namespace VismaSpcs.Recruitment.ChatService.Services.Interface
{
    public interface IUserService
    {
        public Task<UserDto?> GetUserProfile(Guid userId);
        public Task UpdateStatusMessage(Guid userId, string statusMessage);
        public Task UpdateStatus(Guid userId, UserStatusEnum status);
        public Task<List<UserEntity>> GetUsersById(List<Guid> userIds);

    }
}